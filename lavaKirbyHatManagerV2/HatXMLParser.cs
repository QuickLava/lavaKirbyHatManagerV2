using System;
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
		const string headTag = "kirbyHatList";
		const string versionTag = "version";

		const string hatTag = "kirbyHat";
		const string nameTag = "name";
		const string fighterIDTag = "fighterID";
		const string numberTag = "num";
		const string valueTag = "value";
		const string writeCommandTag = "writeCMD";

		const string targetModuleIDTag = "TargetModuleID";
		const string targetOffsetTag = "TargetOffset";
		const string targetSectionTag = "TargetSection";

		const string table1EntryStringTag = "TopStatusKind";
		const string table2EntryStringTag = "AbilityProcesses";
		const string table3EntryStringTag = "AbilityInfo";
		const string table4EntryStringTag = "ConvertParams";

		const string tagSuffix1 = "_1";
		const string tagSuffix2 = "_2";
		const string tagSuffix3 = "_3";
		const string tagSuffix4 = "_4";

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

			if (commandIn.isValid() && writerIn.WriteState != WriteState.Error)
			{
				writerIn.WriteStartElement(writeCommandTag);
				writerIn.WriteAttributeString(nameTag, elementName);

				writeNumberElementToXML(writerIn, targetModuleIDTag, commandIn.TargetModuleID);
				writeNumberElementToXML(writerIn, targetOffsetTag, commandIn.TargetOffset);
				writeNumberElementToXML(writerIn, targetSectionTag, commandIn.TargetSection);

				writerIn.WriteEndElement();
				result = true;
			}

			return result;
		}

		public static void exportHatsToXML(KirbyHatManager managerIn, string filepath, uint[] FIDsIn)
		{
			bool result = false;

			XmlWriterSettings hatListSettings = new XmlWriterSettings();
			hatListSettings.Indent = true;
			hatListSettings.IndentChars = "    ";
			XmlWriter xmlOut = XmlWriter.Create(filepath, hatListSettings);
			xmlOut.WriteStartElement(headTag);
			xmlOut.WriteAttributeString(versionTag, Properties.Resources.Version);

			foreach (uint currID in FIDsIn)
			{
				if (managerIn.fighterIDToInfoPacks.ContainsKey(currID))
				{
					HatInfoPack currHat = managerIn.fighterIDToInfoPacks[currID];

					xmlOut.WriteStartElement(hatTag);
					xmlOut.WriteAttributeString(fighterIDTag, "0x" + currID.ToString("X2"));
					if (HatNames.getFIDHasName(currID))
					{
						xmlOut.WriteAttributeString(nameTag, HatNames.getNameFromFID(currID));
					}

					xmlOut.WriteComment(HatInfoPack.table1CatName);
					writeNumberElementToXML  (xmlOut, table1EntryStringTag, currHat.TopStatusKind);

					xmlOut.WriteComment(HatInfoPack.table2CatName);
					writeRELWriteCommandToXML(xmlOut, table2EntryStringTag, currHat.AbilityProcesses);

					xmlOut.WriteComment(HatInfoPack.table3CatName);
					writeRELWriteCommandToXML(xmlOut, table3EntryStringTag + tagSuffix1, currHat.AbilityInfo1);
					writeNumberElementToXML  (xmlOut, table3EntryStringTag + tagSuffix2, currHat.AbilityInfo2);
					writeNumberElementToXML  (xmlOut, table3EntryStringTag + tagSuffix3, currHat.AbilityInfo3);
					writeNumberElementToXML  (xmlOut, table3EntryStringTag + tagSuffix4, currHat.AbilityInfo4);

					xmlOut.WriteComment(HatInfoPack.table4CatName);
					writeRELWriteCommandToXML(xmlOut, table4EntryStringTag + tagSuffix1, currHat.ConvertParams1);
					writeRELWriteCommandToXML(xmlOut, table4EntryStringTag + tagSuffix2, currHat.ConvertParams2);
					writeRELWriteCommandToXML(xmlOut, table4EntryStringTag + tagSuffix3, currHat.ConvertParams3);
					writeRELWriteCommandToXML(xmlOut, table4EntryStringTag + tagSuffix4, currHat.ConvertParams4);

					xmlOut.WriteEndElement();
				}
			}

			xmlOut.WriteEndElement();
			xmlOut.Close();
			result = System.IO.File.Exists(filepath);
		}
	}
}
