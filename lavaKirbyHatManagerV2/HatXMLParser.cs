﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lKHM
{
	public static class HatXMLParser
	{
		// Tags
		const string rootTag = "kirbyHatList";
		const string versionTag = "version";

		const string hatTag = "kirbyHat";
		const string nameTag = "name";
		const string fighterIDTag = "fighterID";
		const string numberTag = "num";
		const string valueTag = "value";
		const string writeCommandTag = "writeCMD";
		const string partialHatTag = "partial";

		const string targetModuleIDTag = "TargetModuleID";
		const string targetOffsetTag = "TargetOffset";
		const string targetSectionTag = "TargetSection";

		const string table1EntryStringTag = "TopStatusKind";
		const string table2EntryStringTag = "AbilityProcesses";

		const string table3Entry1StringTag = "AbilityInfo_1";
		const string table3Entry2StringTag = "AbilityInfo_2";
		const string table3Entry3StringTag = "AbilityInfo_3";
		const string table3Entry4StringTag = "AbilityInfo_4";

		const string table4Entry1StringTag = "ConvertParams_1";
		const string table4Entry2StringTag = "ConvertParams_2";
		const string table4Entry3StringTag = "ConvertParams_3";
		const string table4Entry4StringTag = "ConvertParams_4";

		const string table5EntryStringTag = "NodeConvertIndex";

		private static bool getVersionFromString(string stringIn, out Version verOut)
		{
			bool result = false;

			result = Version.TryParse(stringIn, out verOut);
			if (!result && stringIn.StartsWith("v", true, System.Globalization.CultureInfo.CurrentCulture))
			{
				result = Version.TryParse(stringIn.Substring(1), out verOut);
			}

			return result;
		}

		private static bool getNamedAttrString(XmlNode nodeIn, string attributeName, out string stringOut)
		{
			bool result = false;

			stringOut = "";
			if (!String.IsNullOrEmpty(attributeName))
			{
				foreach (XmlAttribute attrItr in nodeIn.Attributes)
				{
					result = attrItr.Name == attributeName;
					if (result)
					{
						stringOut = attrItr.Value;
						break;
					}
				}
			}

			return result;
		}
		private static bool getNamedAttrAsUint(XmlNode nodeIn, string attributeName, out uint valueOut)
		{
			bool result = false;

			valueOut = uint.MaxValue;
			if (getNamedAttrString(nodeIn, attributeName, out string attrStr))
			{
				if (attrStr.StartsWith("0x"))
				{
					valueOut = Conversions.convertHexStringToNum(attrStr, valueOut);
					result = true;
				}
				else
				{
					result = uint.TryParse(attrStr, out valueOut);
				}
			}

			return result;
		}
		private static bool getNamedAttrAsBool(XmlNode nodeIn, string attributeName, out bool valueOut)
		{
			bool result = false;

			valueOut = false;
			if (getNamedAttrAsUint(nodeIn, attributeName, out uint numValOut))
			{
				valueOut = numValOut != 0;
				result = true;
			}
			else if (getNamedAttrString(nodeIn, attributeName, out string strValOut))
			{
				if (bool.TryParse(strValOut, out bool boolValOut))
				{
					valueOut = boolValOut;
					result = true;
				}
			}

			return result;
		}

		private static bool readNumberElementFromXML(XmlNode nodeIn, out uint valueOut)
		{
			bool result = false;

			valueOut = uint.MaxValue;
			if (nodeIn.Name == numberTag)
			{
				result = getNamedAttrAsUint(nodeIn, valueTag, out valueOut);
			}

			return result;
		}
		private static bool readRELWriteCommandFromXML(XmlNode nodeIn, out writeWordCmd commandOut)
		{
			bool result = false;

			commandOut = new writeWordCmd();
			if (nodeIn.Name == writeCommandTag)
			{
				foreach (XmlNode cmdField in nodeIn.ChildNodes)
				{
					if (!getNamedAttrString(cmdField, nameTag, out string retName)) continue;

					if (retName == targetModuleIDTag)
					{
						getNamedAttrString(cmdField, valueTag, out string moduleName);
						commandOut.TargetModuleID = moduleName;
						if (commandOut.targetModuleIDValid()) continue;
					}

					if (readNumberElementFromXML(cmdField, out uint retVal))
					{
						switch (retName)
						{
							case targetModuleIDTag: { commandOut._targetModuleID = retVal; break; }
							case targetOffsetTag: { commandOut._targetOffset = retVal; break; }
							case targetSectionTag: { commandOut._targetSection = (byte)retVal; break; }
							default: { break; }
						}
					}
				}

				result = true;
			}

			return result;
		}
		private static bool writeNumberElementToXML(XmlWriter writerIn, string elementName, string numStringIn)
		{
			bool result = false;

			if (writerIn.WriteState != WriteState.Error)
			{
				writerIn.WriteStartElement(numberTag);
				writerIn.WriteAttributeString(nameTag, elementName);
				writerIn.WriteAttributeString(valueTag, numStringIn);
				writerIn.WriteEndElement();

				result = true;
			}

			return result;
		}
		private static bool writeRELWriteCommandToXML(XmlWriter writerIn, string elementName, writeWordCmd commandIn)
		{
			bool result = false;

			if (writerIn.WriteState != WriteState.Error)
			{
				writerIn.WriteStartElement(writeCommandTag);
				writerIn.WriteAttributeString(nameTag, elementName);
				if (commandIn.isValid())
				{
					writeNumberElementToXML(writerIn, targetModuleIDTag, commandIn.TargetModuleID);
					writeNumberElementToXML(writerIn, targetOffsetTag, commandIn.TargetOffset);
					writeNumberElementToXML(writerIn, targetSectionTag, commandIn.TargetSection);
				}
				writerIn.WriteEndElement();
				result = true;
			}

			return result;
		}

		public static bool exportHatsToXML(string filepath, uint[] FIDsIn,
			SortedDictionary<uint, HatInfoPack> sourceHatDict, SortedDictionary<uint, string> sourceNameDict = null)
		{
			bool result = false;

			XmlWriterSettings hatListSettings = new XmlWriterSettings();
			hatListSettings.Indent = true;
			hatListSettings.IndentChars = "    ";
			XmlWriter xmlOut = XmlWriter.Create(filepath, hatListSettings);

			xmlOut.WriteStartElement(rootTag);
			xmlOut.WriteAttributeString(versionTag, KirbyHatManager.Version);
			if (System.IO.File.Exists(filepath) && sourceHatDict != null)
			{
				foreach (uint currID in FIDsIn)
				{
					if (sourceHatDict.ContainsKey(currID))
					{
						HatInfoPack currHat = sourceHatDict[currID];

						xmlOut.WriteStartElement(hatTag);
						xmlOut.WriteAttributeString(fighterIDTag, "0x" + currID.ToString("X2"));
						if (sourceNameDict != null && sourceNameDict.ContainsKey(currID))
						{
							xmlOut.WriteAttributeString(nameTag, HatNames.getNameFromFID(currID));
						}

						xmlOut.WriteComment(HatInfoPack.table1CatName);
						writeNumberElementToXML(xmlOut, table1EntryStringTag, currHat.TopStatusKind);

						xmlOut.WriteComment(HatInfoPack.table2CatName);
						writeRELWriteCommandToXML(xmlOut, table2EntryStringTag, currHat.AbilityProcesses);

						xmlOut.WriteComment(HatInfoPack.table3CatName);
						writeRELWriteCommandToXML(xmlOut, table3Entry1StringTag, currHat.AbilityInfo1);
						writeNumberElementToXML(xmlOut, table3Entry2StringTag, currHat.AbilityInfo2);
						writeNumberElementToXML(xmlOut, table3Entry3StringTag, currHat.AbilityInfo3);
						writeNumberElementToXML(xmlOut, table3Entry4StringTag, currHat.AbilityInfo4);

						xmlOut.WriteComment(HatInfoPack.table4CatName);
						writeRELWriteCommandToXML(xmlOut, table4Entry1StringTag, currHat.ConvertParams1);
						writeRELWriteCommandToXML(xmlOut, table4Entry2StringTag, currHat.ConvertParams2);
						writeRELWriteCommandToXML(xmlOut, table4Entry3StringTag, currHat.ConvertParams3);
						writeRELWriteCommandToXML(xmlOut, table4Entry4StringTag, currHat.ConvertParams4);

						xmlOut.WriteComment(HatInfoPack.table5CatName);
						writeNumberElementToXML(xmlOut, table5EntryStringTag, currHat.NodeConvertIndex);

						xmlOut.WriteEndElement();
					}
				}
				result = true;
			}
			xmlOut.WriteEndElement();
			xmlOut.Close();

			return result;
		}
		public static void parseHatsFromXML(string filepath,
			SortedDictionary<uint, HatInfoPack> destHatDict, SortedDictionary<uint, string> destNameDict = null)
		{
			if (!System.IO.File.Exists(filepath)) return;

			XmlDocument xmlIn = new System.Xml.XmlDocument();
			xmlIn.Load(filepath);
			XmlNodeList rootNodeList = xmlIn.GetElementsByTagName(rootTag);
			if (rootNodeList.Count == 0x00) return;

			XmlNode rootNode = rootNodeList[0];

			Version xmlLibraryVersion = KirbyHatManager.GetVersion();
			if (getNamedAttrString(rootNode, versionTag, out string versionAttr))
			{
				if (getVersionFromString(versionAttr, out Version xmlVer))
				{
					xmlLibraryVersion = xmlVer;
				}
			}

			foreach (XmlNode currHatNode in rootNode.ChildNodes)
			{
				if (currHatNode.Name != hatTag) continue;
				if (!getNamedAttrAsUint(currHatNode, fighterIDTag, out uint currFID)) continue;

				getNamedAttrString(currHatNode, nameTag, out string currName);
				getNamedAttrAsBool(currHatNode, partialHatTag, out bool currHatIsPartial);

				HatInfoPack newHat = new HatInfoPack();
				if (destHatDict.ContainsKey(currFID))
				{
					if (currHatIsPartial)
					{
						newHat.copyInfoFrom(destHatDict[currFID]);
					}
					else if (xmlLibraryVersion < KirbyHatManager.GetVersion())
					{
						HatVersionPromoter.inheritDataForPromotion(newHat, xmlLibraryVersion, destHatDict[currFID], Program.GetVersion());
					}
				}

				foreach (XmlNode hatField in currHatNode.ChildNodes)
				{
					if (hatField.NodeType != XmlNodeType.Element) continue;
					if (!getNamedAttrString(hatField, nameTag, out string retName)) continue;

					if (readNumberElementFromXML(hatField, out uint retVal))
					{
						switch (retName)
						{
							case table1EntryStringTag: { newHat.table1Entry = retVal; break; }
							case table3Entry2StringTag: { newHat.table3Entry2 = retVal; break; }
							case table3Entry3StringTag: { newHat.table3Entry3 = retVal; break; }
							case table3Entry4StringTag: { newHat.table3Entry4 = retVal; break; }
							case table5EntryStringTag: { newHat.table5Entry = (byte)retVal; break; }
						}
					}
					else if (readRELWriteCommandFromXML(hatField, out writeWordCmd retCmd))
					{
						switch (retName)
						{
							case table2EntryStringTag: { newHat.table2Entry = retCmd; break; }
							case table3Entry1StringTag: { newHat.table3Entry1 = retCmd; break; }
							case table4Entry1StringTag: { newHat.table4Entry1 = retCmd; break; }
							case table4Entry2StringTag: { newHat.table4Entry2 = retCmd; break; }
							case table4Entry3StringTag: { newHat.table4Entry3 = retCmd; break; }
							case table4Entry4StringTag: { newHat.table4Entry4 = retCmd; break; }
							default: { break; }
						}
					}
				}

				if (!destHatDict.ContainsKey(currFID))
				{
					destHatDict.Add(currFID, new HatInfoPack());
				}
				destHatDict[currFID].copyInfoFrom(newHat);

				if (destNameDict != null && !String.IsNullOrEmpty(currName))
				{
					destNameDict[currFID] = currName;
				}
			}

			return;
		}
		public static void importHatsFromXML(KirbyHatManager managerIn, string filepath)
		{
			SortedDictionary<uint, string> incomingNames = new SortedDictionary<uint, string>();
			parseHatsFromXML(filepath, managerIn.fighterIDToInfoPacks, incomingNames);

			foreach (var currPair in incomingNames)
			{
				HatNames.setFIDName(currPair.Key, currPair.Value, true);
			}
		}
		public static void importHatsFromXMLs(KirbyHatManager managerIn, string[] filepaths)
		{
			foreach (string currPath in filepaths)
			{
				importHatsFromXML(managerIn, currPath);
			}
		}
	}
}
