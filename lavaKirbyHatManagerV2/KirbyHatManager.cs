using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.ComponentModel;

namespace lKHM
{
	public static class Values
	{
		public enum LAVA_CHARA_FIGHTER_IDS
		{
			BOWSER = 0x0B,
			CAPTAIN_FALCON = 0x09,
			CHARIZARD = 0x1D,
			DEDEDE = 0x20,
			DIDDY_KONG = 0x1B,
			DONKEY_KONG = 0x01,
			FALCO = 0x13,
			FOX = 0x06,
			GANONDORF = 0x14,
			GIGA_BOWSER = 0x30,
			IKE = 0x22,
			IVYSAUR = 0x1F,
			JIGGLYPUFF = 0x25,
			KIRBY = 0x05,
			LINK = 0x02,
			LUCARIO = 0x21,
			LUCAS = 0x1A,
			LUIGI = 0x08,
			MARIO = 0x00,
			MARTH = 0x11,
			META_KNIGHT = 0x16,
			MR_GAME_AND_WATCH = 0x12,
			NANA = 0x10,
			NESS = 0x0A,
			OLIMAR = 0x19,
			PEACH = 0x0C,
			PIKACHU = 0x07,
			PIT = 0x17,
			POKEMON_TRAINER = 0x1C,
			POPO = 0x0F,
			ROB = 0x23,
			SAMUS = 0x03,
			SHEIK = 0x0E,
			SNAKE = 0x2E,
			SONIC = 0x2F,
			SOPO = 0x0F,
			SQUIRTLE = 0x1E,
			TOON_LINK = 0x29,
			WARIO = 0x15,
			WARIOMAN = 0x31,
			WOLF = 0x2C,
			YOSHI = 0x04,
			ZELDA = 0x0D,
			ZERO_SUIT_SAMUS = 0x18,
			RED_ALLOY = 0x32,
			BLUE_ALLOY = 0x33,
			YELLOW_ALLOY = 0x34,
			GREEN_ALLOY = 0x35,
			PM_MEWTWO = 0x26,
			PM_ROY = 0x27,
			PP_KNUCKLES = 0x2D,
			EX_RIDLEY = 0x2A,
			EX_WALUIGI = 0x28,
			EX_DARK_SAMUS = 0x40,
			EX_SCEPTILE = 0x62,
			EX_KRYSTAL = 0x41,
		}

		public const string defaultName = "UNRECOGNIZED";

		static SortedDictionary<uint, string> fighterIDsToCanonNames = new SortedDictionary<uint, string>();
		public static bool getFIDHasCanonName(uint fighterIDIn)
		{
			return fighterIDsToCanonNames.ContainsKey(fighterIDIn);
		}
		public static string getCanonNameFromFID(uint fighterIDIn)
		{
			string result = defaultName;

			if (getFIDHasCanonName(fighterIDIn))
			{
				result = fighterIDsToCanonNames[fighterIDIn];
			}

			return result;
		}

		static Values()
		{
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.CAPTAIN_FALCON] = "CAPTAIN";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.DEDEDE] = "DEDEDE";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.DIDDY_KONG] = "DIDDY";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.DONKEY_KONG] = "DONKEY";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.FALCO] = "FALCO";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.FOX] = "FOX";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.GANONDORF] = "GANON";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.MR_GAME_AND_WATCH] = "GAMEWATCH";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.GIGA_BOWSER] = "GKOOPA";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.IKE] = "IKE";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.KIRBY] = "KIRBY";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.BOWSER] = "KOOPA";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.LINK] = "LINK";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.LUCARIO] = "LUCARIO";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.LUCAS] = "LUCAS";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.LUIGI] = "LUIGI";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.MARIO] = "MARIO";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.MARTH] = "MARTH";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.META_KNIGHT] = "METAKNIGHT";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.NANA] = "NANA";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.NESS] = "NESS";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.PEACH] = "PEACH";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.PIKACHU] = "PIKACHU";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.OLIMAR] = "PIKMIN";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.PIT] = "PIT";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.IVYSAUR] = "POKEFUSHIGISOU";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.CHARIZARD] = "POKELIZARDON";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.POKEMON_TRAINER] = "POKETRAINER";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.SQUIRTLE] = "POKEZENIGAME";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.POPO] = "POPO";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.JIGGLYPUFF] = "PURIN";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.ROB] = "ROBOT";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.SAMUS] = "SAMUS";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.SHEIK] = "SHEIK";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.SNAKE] = "SNAKE";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.SONIC] = "SONIC";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.SOPO] = "SOPO";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.ZERO_SUIT_SAMUS] = "SZEROSUIT";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.TOON_LINK] = "TOONLINK";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.WARIO] = "WARIO";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.WARIOMAN] = "WARIOMAN";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.WOLF] = "WOLF";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.YOSHI] = "YOSHI";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.ZELDA] = "ZELDA";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.RED_ALLOY] = "RED_ALLOY";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.BLUE_ALLOY] = "BLUE_ALLOY";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.YELLOW_ALLOY] = "YELLOW_ALLOY";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.GREEN_ALLOY] = "GREEN_ALLOY";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.PM_MEWTWO] = "PM_MEWTWO";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.PM_ROY] = "PM_ROY";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.PP_KNUCKLES] = "P+_KNUCKLES";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.EX_RIDLEY] = "EX_RIDLEY";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.EX_WALUIGI] = "EX_WALUIGI";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.EX_DARK_SAMUS] = "EX_DARK_SAMUS";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.EX_SCEPTILE] = "EX_SCEPTILE";
			fighterIDsToCanonNames[(uint)LAVA_CHARA_FIGHTER_IDS.EX_KRYSTAL] = "EX_KRYSTAL";
		}
	}

	public class HatInfoPack
	{
		// Name
		public string name = "";

		// AbilityTopStatusKind
		public uint table1Entry = 0xFFFFFFFF;
		// AbilityProcesses
		public uint table2Entry = 0x00000000;
		// AbilityInfos
		public uint[] table3Entries = { 0x00000000, 0x00000001, 0x0000023B, 0x00000000};
		// AbilityConvertParams
		public uint[] table4Entries = { 0x00000000, 0x00000000, 0x00000000, 0x00000000};

		public void copyInfoFrom(HatInfoPack sourceHat, bool copyName = true)
		{
			if (copyName)
			{
				name = sourceHat.name;
			}

			table1Entry = sourceHat.table1Entry;
			table2Entry = sourceHat.table2Entry;
			sourceHat.table3Entries.CopyTo(table3Entries, 0);
			sourceHat.table4Entries.CopyTo(table4Entries, 0);
		}

		// Properties
		const string table1CatName = "Table 1";
		const string table2CatName = "Table 2";
		const string table3CatName = "Table 3";
		const string table4CatName = "Table 4";

		[Category("Miscellaneous")]
		public string Name
		{
			get => name;
			set
			{
				name = value.ToUpper();
			}
		}

		[Category(table1CatName)]
		public string TopStatusKind
		{
			get => "0x" + table1Entry.ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table1Entry = convertedInput;
				}
			}
		}

		[Category(table2CatName)]
		public string AbilityProcesses
		{
			get => "0x" + table2Entry.ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table2Entry = convertedInput;
				}
			}
		}

		[Category(table3CatName)]
		public string AbilityInfo1
		{
			get => "0x" + table3Entries[0].ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table3Entries[0] = convertedInput;
				}
			}
		}
		[Category(table3CatName)]
		public string AbilityInfo2
		{
			get => "0x" + table3Entries[1].ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table3Entries[1] = convertedInput;
				}
			}
		}
		[Category(table3CatName)]
		public string AbilityInfo3
		{
			get => "0x" + table3Entries[2].ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table3Entries[2] = convertedInput;
				}
			}
		}
		[Category(table3CatName)]
		public string AbilityInfo4
		{
			get => "0x" + table3Entries[3].ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table3Entries[3] = convertedInput;
				}
			}
		}

		[Category(table4CatName)]
		public string ConvertParams1
		{
			get => "0x" + table4Entries[0].ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table4Entries[0] = convertedInput;
				}
			}
		}
		[Category(table4CatName)]
		public string ConvertParams2
		{
			get => "0x" + table4Entries[1].ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table4Entries[1] = convertedInput;
				}
			}
		}
		[Category(table4CatName)]
		public string ConvertParams3
		{
			get => "0x" + table4Entries[2].ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table4Entries[2] = convertedInput;
				}
			}
		}
		[Category(table4CatName)]
		public string ConvertParams4
		{
			get => "0x" + table4Entries[3].ToString("X8");
			set
			{
				uint convertedInput = uint.MaxValue;
				string tempStr = value;
				if (tempStr.StartsWith("0x"))
				{
					tempStr = tempStr.Substring(2);
				}
				if (uint.TryParse(tempStr, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out convertedInput))
				{
					table4Entries[3] = convertedInput;
				}
			}
		}
	}

	class KirbyHatManager
	{
		const uint kirbyModuleID = 0x60;

		const uint maxCharCount = 0x100;
		const uint table1EntrySize = 0x4;
		const uint table2EntrySize = 0x4;
		const uint table3EntrySize = 0x10;
		const uint table4EntrySize = 0x10;
		const uint table1StartOffset = 0x0;
		const uint table1Length = maxCharCount * table1EntrySize;
		const uint table2StartOffset = table1StartOffset + table1Length;
		const uint table2Length = maxCharCount * table2EntrySize;
		const uint table3StartOffset = table2StartOffset + table2Length;
		const uint table3Length = maxCharCount * table3EntrySize;
		const uint table4StartOffset = table3StartOffset + table3Length;
		const uint table4Length = maxCharCount * table4EntrySize;
		const uint tablesEndOffset = table4StartOffset + table4Length;

		public const string tableSectionName = "Section [7]";

		HatInfoPack defaultInfoPack = new HatInfoPack();
		public SortedDictionary<uint, HatInfoPack> fighterIDToInfoPacks = new SortedDictionary<uint, HatInfoPack>();

		uint getTable1EntryOffset(uint charIDIn)
		{
			uint result = uint.MaxValue;

			if (charIDIn < maxCharCount)
			{
				result = (charIDIn * table1EntrySize) + table1StartOffset;
			}

			return result;
		}
		uint getTable2EntryOffset(uint charIDIn)
		{
			uint result = uint.MaxValue;

			if (charIDIn < maxCharCount)
			{
				result = (charIDIn * table2EntrySize) + table2StartOffset;
			}

			return result;
		}
		uint getTable3EntryOffset(uint charIDIn)
		{
			uint result = uint.MaxValue;

			if (charIDIn < maxCharCount)
			{
				result = (charIDIn * table3EntrySize) + table3StartOffset;
			}

			return result;
		}
		uint getTable4EntryOffset(uint charIDIn)
		{
			uint result = uint.MaxValue;

			if (charIDIn < maxCharCount)
			{
				result = (charIDIn * table4EntrySize) + table4StartOffset;
			}

			return result;
		}

		uint getWordFromByteArr(byte[] arrIn, uint offset)
		{
			uint result = uint.MaxValue;

			if (offset + 4 <= arrIn.Length)
			{
				byte[] conversionBuffer = new byte[4];
				conversionBuffer = arrIn.Skip((int)offset).Take(4).ToArray();
				if (BitConverter.IsLittleEndian)
				{
					conversionBuffer = conversionBuffer.Reverse().ToArray();
				}
				result = BitConverter.ToUInt32(conversionBuffer, 0);
			}

			return result;
		}
		bool writeWordToByteArr(byte[] arrIn, uint valueIn, uint offset)
		{
			bool result = false;

			if (offset + 4 <= arrIn.Length)
			{
				byte[] conversionBuffer = new byte[4];
				conversionBuffer = BitConverter.GetBytes(valueIn);
				if (BitConverter.IsLittleEndian)
				{
					conversionBuffer = conversionBuffer.Reverse().ToArray();
				}
				arrIn[offset] = conversionBuffer[0];
				arrIn[offset + 1] = conversionBuffer[1];
				arrIn[offset + 2] = conversionBuffer[2];
				arrIn[offset + 3] = conversionBuffer[3];
			}

			return result;
		}

		bool populateHatInfoFromSectionHex(uint fighterID, HatInfoPack destinationPack, byte[] sectionBodyIn)
		{
			bool result = false;

			if (fighterID < maxCharCount)
			{
				destinationPack.name = Values.getCanonNameFromFID(fighterID);

				destinationPack.table1Entry = getWordFromByteArr(sectionBodyIn, getTable1EntryOffset(fighterID));

				destinationPack.table2Entry = getWordFromByteArr(sectionBodyIn, getTable2EntryOffset(fighterID));

				uint table3EntriesStart = getTable3EntryOffset(fighterID);
				destinationPack.table3Entries[0] = getWordFromByteArr(sectionBodyIn, table3EntriesStart);
				destinationPack.table3Entries[1] = getWordFromByteArr(sectionBodyIn, table3EntriesStart + 0x4);
				destinationPack.table3Entries[2] = getWordFromByteArr(sectionBodyIn, table3EntriesStart + 0x8);
				destinationPack.table3Entries[3] = getWordFromByteArr(sectionBodyIn, table3EntriesStart + 0xC);

				uint table4EntriesStart = getTable4EntryOffset(fighterID);
				destinationPack.table4Entries[0] = getWordFromByteArr(sectionBodyIn, table4EntriesStart);
				destinationPack.table4Entries[1] = getWordFromByteArr(sectionBodyIn, table4EntriesStart + 0x4);
				destinationPack.table4Entries[2] = getWordFromByteArr(sectionBodyIn, table4EntriesStart + 0x8);
				destinationPack.table4Entries[3] = getWordFromByteArr(sectionBodyIn, table4EntriesStart + 0xC);

				result = true;
			}

			return result;
		}
		bool infoPackHasDefaultData(HatInfoPack sourcePack)
		{
			bool result = sourcePack.table1Entry == defaultInfoPack.table1Entry;
			result &= sourcePack.table2Entry == defaultInfoPack.table2Entry;
			result &= Enumerable.SequenceEqual(sourcePack.table3Entries, defaultInfoPack.table3Entries);
			result &= Enumerable.SequenceEqual(sourcePack.table4Entries, defaultInfoPack.table4Entries);

			return result;
		}

		public bool loadHatEntriesFromSectionHex(byte[] tableSectionBody)
		{
			bool result = false;

			if (tableSectionBody.Length >= tablesEndOffset)
			{
				fighterIDToInfoPacks.Clear();

				for (uint i = 0x00; i < maxCharCount; i++)
				{
					HatInfoPack newInfoPack = new HatInfoPack();
					if (populateHatInfoFromSectionHex(i, newInfoPack, tableSectionBody) && !infoPackHasDefaultData(newInfoPack))
					{
						fighterIDToInfoPacks[i] = newInfoPack;
					}
				}
				result = fighterIDToInfoPacks.Count > 0;
			}

			return result;
		}
		public bool loadHatEntriesFromSectionHex(string filepathIn)
		{
			bool result = false;

			if (File.Exists(filepathIn))
			{
				byte[] tableSectionBody = File.ReadAllBytes(filepathIn);
				result = loadHatEntriesFromSectionHex(tableSectionBody);
			}
			else
			{
				Console.WriteLine("Failed to load Table Section Hex file!");
			}

			return result;
		}
		public bool loadHatEntriesFromREL(BrawlLib.SSBB.ResourceNodes.RELNode kirbyModule)
		{
			bool result = false;

			if (kirbyModule.ModuleID == kirbyModuleID)
			{
				Console.WriteLine("Kirby Module Loaded:");
				Console.WriteLine("Name: " + kirbyModule.Name + "\n");
				Console.WriteLine("Size: " + kirbyModule.UncompressedSize.ToString("X3") + " bytes\n");

				var tableSectionNode = kirbyModule.FindChild(tableSectionName) as BrawlLib.SSBB.ResourceNodes.ModuleSectionNode;
				if (tableSectionNode != null && tableSectionNode.UncompressedSize >= tablesEndOffset)
				{
					string tempFilename = Path.GetTempFileName();
					tableSectionNode.Export(tempFilename);
					result = loadHatEntriesFromSectionHex(tempFilename);
					if (result)
					{
						Console.WriteLine("Successfully loaded and parsed Hat Table!");
					}
					File.Delete(tempFilename);
				}
				else
				{
					Console.WriteLine("Failed to load Hat Table!");
				}
			}
			else
			{
				Console.WriteLine("Loaded Module file is not Kirby Module!");
				Console.WriteLine("Kirby Module must have ModuleID " + kirbyModuleID.ToString() + ", loaded Module has ID " + kirbyModule.ModuleID.ToString() + "!");
			}

			return result;
		}
		public bool loadHatEntriesFromREL(string filepathIn)
		{
			bool result = false;

			if (File.Exists(filepathIn))
			{
				BrawlLib.SSBB.ResourceNodes.RELNode kirbyModule = new BrawlLib.SSBB.ResourceNodes.RELNode();
				kirbyModule.Replace(filepathIn);
				result = loadHatEntriesFromREL(kirbyModule);
			}
			else
			{
				Console.WriteLine("Failed to load Module file!");
			}

			return result;
		}
		
		public bool copyHatToSlot(uint sourceFighterID, uint destinationFighterID, bool allowOverwrite, bool copyName = false)
		{
			bool result = false;

			if (fighterIDToInfoPacks.ContainsKey(sourceFighterID) && destinationFighterID < maxCharCount)
			{
				result = true;

				if (!fighterIDToInfoPacks.ContainsKey(destinationFighterID))
				{
					result = createNewHat(destinationFighterID);
				}
				else
				{
					result = allowOverwrite;
				}

				if (result)
				{
					fighterIDToInfoPacks[destinationFighterID].copyInfoFrom(fighterIDToInfoPacks[sourceFighterID], copyName);
				}
			}

			return result;
		}
		public bool moveHatToSlot(uint sourceFighterID, uint destinationFighterID, bool allowOverwrite)
		{
			bool result = false;

			if (copyHatToSlot(sourceFighterID, destinationFighterID, allowOverwrite, true))
			{
				result = eraseHat(sourceFighterID);
			}

			return result;
		}
		public bool createNewHat(uint targetFighterID, string targetSlotName = Values.defaultName)
		{
			bool result = false;

			if (targetFighterID < maxCharCount && !fighterIDToInfoPacks.ContainsKey(targetFighterID))
			{
				fighterIDToInfoPacks[targetFighterID] = new HatInfoPack();
				fighterIDToInfoPacks[targetFighterID].name = targetSlotName;
				result = true;
			}

			return result;
		}
		public bool eraseHat(uint targetFighterID)
		{
			bool result = false;

			if (targetFighterID < maxCharCount && fighterIDToInfoPacks.ContainsKey(targetFighterID))
			{
				fighterIDToInfoPacks.Remove(targetFighterID);
				result = true;
			}

			return result;
		}

		public void summarizeHatTable()
		{
			foreach (var currPair in fighterIDToInfoPacks)
			{
				Console.WriteLine("[FID 0x" + currPair.Key.ToString("X2") + " - " + currPair.Value.name + "]");
				Console.WriteLine("  - Entry 1: 0x" + currPair.Value.table1Entry.ToString("X8"));
				Console.WriteLine("  - Entry 2: 0x" + currPair.Value.table2Entry.ToString("X8"));
				Console.Write("  - Entry 3:");
				foreach (uint value in currPair.Value.table3Entries)
				{
					Console.Write(" 0x" + value.ToString("X8"));
				}
				Console.WriteLine("");
				Console.Write("  - Entry 4:");
				foreach (uint value in currPair.Value.table4Entries)
				{
					Console.Write(" 0x" + value.ToString("X8"));
				}
				Console.WriteLine("");
			}
		}
		public bool buildAndExportTables(string filepathIn)
		{
			byte[] tableBody = new byte[tablesEndOffset];

			for (uint i = 0; i < maxCharCount; i++)
			{
				HatInfoPack sourcePack = defaultInfoPack;

				if (fighterIDToInfoPacks.ContainsKey(i))
				{
					sourcePack = fighterIDToInfoPacks[i];
				}

				writeWordToByteArr(tableBody, sourcePack.table1Entry, getTable1EntryOffset(i));
				writeWordToByteArr(tableBody, sourcePack.table2Entry, getTable2EntryOffset(i));
				uint table3EntryOffset = getTable3EntryOffset(i);
				for (uint u = 0; u < 4; u++)
				{
					writeWordToByteArr(tableBody, sourcePack.table3Entries[u], table3EntryOffset + (u * 4));
				}
				uint table4EntryOffset = getTable4EntryOffset(i);
				for (uint u = 0; u < 4; u++)
				{
					writeWordToByteArr(tableBody, sourcePack.table4Entries[u], table4EntryOffset + (u * 4));
				}
			}

			File.WriteAllBytes(filepathIn, tableBody);

			return File.Exists(filepathIn);
		}
	}
}
