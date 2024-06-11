using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lKHM
{
	public static class Constants
	{
		public enum LAVA_CHARA_SLOT_IDS
		{
			BOWSER = 12,
			CAPTAIN_FALCON = 10,
			CHARIZARD = 30,
			DEDEDE = 35,
			DIDDY_KONG = 28,
			DONKEY_KONG = 1,
			FALCO = 21,
			FOX = 7,
			GANONDORF = 22,
			GIGA_BOWSER = 44,
			ICE_CLIMBERS = 16,
			IKE = 37,
			IVYSAUR = 34,
			JIGGLYPUFF = 39,
			KIRBY = 6,
			LINK = 2,
			LUCARIO = 36,
			LUCAS = 27,
			LUIGI = 9,
			MARIO = 0,
			MARTH = 19,
			META_KNIGHT = 24,
			MR_GAME_AND_WATCH = 20,
			NESS = 11,
			OLIMAR = 26,
			PEACH = 13,
			PIKACHU = 8,
			PIT = 25,
			POKEMON_TRAINER = 72,
			ROB = 38,
			SAMUS = 3,
			SHEIK = 15,
			SNAKE = 42,
			SONIC = 43,
			SOPO = 17,
			SQUIRTLE = 32,
			TOON_LINK = 40,
			WARIO = 23,
			WARIOMAN = 45,
			WOLF = 41,
			YOSHI = 5,
			ZELDA = 14,
			ZERO_SUIT_SAMUS = 4,
			MEWTWO = 51,
			ROY = 50,
			KNUCKLES = 53,
			RIDLEY = 56,
			//DARK_SAMUS = 0x40,
			//WALUIGI = 0x39,
		};
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
			MEWTWO = 0x26,
			ROY = 0x27,
			KNUCKLES = 0x2D,
			RIDLEY = 0x2A,
			//DARK_SAMUS = 0x40,
			//WALUIGI = 0x28,
		}

		public static SortedDictionary<uint, string> fighterIDsToNames = new SortedDictionary<uint, string>();

		static Constants()
		{
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.CAPTAIN_FALCON] = "CAPTAIN";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.DEDEDE] = "DEDEDE";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.DIDDY_KONG] = "DIDDY";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.DONKEY_KONG] = "DONKEY";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.FALCO] = "FALCO";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.FOX] = "FOX";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.GANONDORF] = "GANON";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.MR_GAME_AND_WATCH] = "GAMEWATCH";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.GIGA_BOWSER] = "GKOOPA";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.IKE] = "IKE";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.KIRBY] = "KIRBY";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.BOWSER] = "KOOPA";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.LINK] = "LINK";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.LUCARIO] = "LUCARIO";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.LUCAS] = "LUCAS";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.LUIGI] = "LUIGI";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.MARIO] = "MARIO";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.MARTH] = "MARTH";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.META_KNIGHT] = "METAKNIGHT";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.NANA] = "NANA";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.NESS] = "NESS";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.PEACH] = "PEACH";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.PIKACHU] = "PIKACHU";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.OLIMAR] = "PIKMIN";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.PIT] = "PIT";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.IVYSAUR] = "POKEFUSHIGISOU";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.CHARIZARD] = "POKELIZARDON";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.POKEMON_TRAINER] = "POKETRAINER";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.SQUIRTLE] = "POKEZENIGAME";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.POPO] = "POPO";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.JIGGLYPUFF] = "PURIN";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.ROB] = "ROBOT";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.SAMUS] = "SAMUS";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.SHEIK] = "SHEIK";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.SNAKE] = "SNAKE";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.SONIC] = "SONIC";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.SOPO] = "SOPO";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.ZERO_SUIT_SAMUS] = "SZEROSUIT";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.TOON_LINK] = "TOONLINK";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.WARIO] = "WARIO";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.WARIOMAN] = "WARIOMAN";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.WOLF] = "WOLF";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.YOSHI] = "YOSHI";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.ZELDA] = "ZELDA";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.MEWTWO] = "MEWTWO";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.ROY] = "ROY";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.KNUCKLES] = "KNUCKLES";
			fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.RIDLEY] = "RIDLEY";
			//fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.DARK_SAMUS] = "DARK_SAMUS";
			//fighterIDsToNames[(uint)LAVA_CHARA_FIGHTER_IDS.WALUIGI] = "WALUIGI";
		}
	}

	public class HatInfoPack
	{
		public class quadWord
		{
			public uint w1 = 0x00;
			public uint w2 = 0x00;
			public uint w3 = 0x00;
			public uint w4 = 0x00;

			public bool anyNonzero()
			{
				bool result = false;

				result |= w1 != 0x00;
				result |= w2 != 0x00;
				result |= w3 != 0x00;
				result |= w4 != 0x00;

				return result;
			}
		}

		// AbilityTopStatusKind
		public uint table1Entry = uint.MaxValue;
		// AbilityProcesses
		public uint table2Entry = 0x00000000;
		// AbilityInfos
		public quadWord table3Entries = new quadWord();
		// AbilityConvertParams
		public quadWord table4Entries = new quadWord();

		public bool hatInfoPresent()
		{
			bool result = false;

			result |= table1Entry != uint.MaxValue;
			result |= table2Entry != 0x00000000;
			result |= table4Entries.anyNonzero();

			return result;
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

		const string tableSectionName = "Section [7]";

		BrawlLib.SSBB.ResourceNodes.RELNode kirbyModule = new BrawlLib.SSBB.ResourceNodes.RELNode();
		byte[] tableSectionBody = null;
		bool tableSectionBodyIsDirty = false;

		Dictionary<uint, HatInfoPack> fighterIDToInfoPacks = new Dictionary<uint, HatInfoPack>();

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
		bool populateHatInfoFromSectionHex(uint fighterID, HatInfoPack destinationPack, byte[] sectionBodyIn)
		{
			bool result = false;

			if (fighterID < maxCharCount)
			{
				destinationPack.table1Entry = getWordFromByteArr(sectionBodyIn, getTable1EntryOffset(fighterID));

				destinationPack.table2Entry = getWordFromByteArr(sectionBodyIn, getTable2EntryOffset(fighterID));

				uint table3EntriesStart = getTable3EntryOffset(fighterID);
				destinationPack.table3Entries.w1 = getWordFromByteArr(sectionBodyIn, table3EntriesStart);
				destinationPack.table3Entries.w2 = getWordFromByteArr(sectionBodyIn, table3EntriesStart + 0x4);
				destinationPack.table3Entries.w3 = getWordFromByteArr(sectionBodyIn, table3EntriesStart + 0x8);
				destinationPack.table3Entries.w4 = getWordFromByteArr(sectionBodyIn, table3EntriesStart + 0xC);

				uint table4EntriesStart = getTable4EntryOffset(fighterID);
				destinationPack.table4Entries.w1 = getWordFromByteArr(sectionBodyIn, table4EntriesStart);
				destinationPack.table4Entries.w2 = getWordFromByteArr(sectionBodyIn, table4EntriesStart + 0x4);
				destinationPack.table4Entries.w3 = getWordFromByteArr(sectionBodyIn, table4EntriesStart + 0x8);
				destinationPack.table4Entries.w4 = getWordFromByteArr(sectionBodyIn, table4EntriesStart + 0xC);

				result = true;
			}

			return result;
		}

		public bool loadKirbyREL(string filepathIn)
		{
			bool result = false;

			if (File.Exists(filepathIn))
			{
				kirbyModule.Replace(filepathIn);
				kirbyModule._origPath = filepathIn;

				if (kirbyModule.ModuleID == kirbyModuleID)
				{
					Console.WriteLine("Kirby Module Loaded:");
					Console.WriteLine("Name: " + kirbyModule.Name + "\n");
					Console.WriteLine("Size: " + kirbyModule.UncompressedSize.ToString("X3") + " bytes\n");

					var tableSectionNode = kirbyModule.FindChild(tableSectionName) as BrawlLib.SSBB.ResourceNodes.ModuleSectionNode;
					if (tableSectionNode != null && tableSectionNode.UncompressedSize >= tablesEndOffset)
					{
						tableSectionNode.Export("./temp.dat");
						tableSectionBody = File.ReadAllBytes("./temp.dat");
						result = true;
						Console.WriteLine("Successfully loaded Hat Table!");
					}
					else
					{
						Console.WriteLine("Failed to load Hat Table!");
					}
				}
				else
				{
					Console.WriteLine("Loaded Module file is not Kirby Module!");
					Console.WriteLine("Kirby Module must have ModuleID " + kirbyModuleID.ToString() +", loaded Module has ID " + kirbyModule.ModuleID.ToString() + "!");
				}
			}
			else
			{
				Console.WriteLine("Failed to load Module file!");
			}

			return result;
		}
		public void summarizeHatTable()
		{
			foreach (var currPair in fighterIDToInfoPacks)
			{
				Console.Write("[FID 0x" + currPair.Key.ToString("X2") + " - ");
				if (Constants.fighterIDsToNames.ContainsKey(currPair.Key))
				{
					Console.Write(Constants.fighterIDsToNames[currPair.Key]);
				}
				else
				{
					Console.Write("UNNAMED_FIGHTER");
				}
				Console.WriteLine("] TopStatusKind: 0x" + currPair.Value.table1Entry.ToString("X3"));
			}
		}
		public bool parseHatsSectionBody()
		{
			bool result = false;

			if (tableSectionBody.Length > 0)
			{
				for (uint i = 0x00; i < maxCharCount; i++)
				{
					HatInfoPack newInfoPack = new HatInfoPack();
					if (populateHatInfoFromSectionHex(i, newInfoPack, tableSectionBody) && newInfoPack.hatInfoPresent())
					{
						fighterIDToInfoPacks[i] = newInfoPack;
					}
				}
			}

			return result;
		}
		public bool copyHatInfoToEmptySlot(uint sourceFighterID, uint destinationFighterID)
		{
			bool result = false;

			if (!fighterIDToInfoPacks.ContainsKey(destinationFighterID))
			{
				result = copyHatInfoToSlot(sourceFighterID, destinationFighterID);
			}

			return result;
		}
		public bool copyHatInfoToSlot(uint sourceFighterID, uint destinationFighterID)
		{
			bool result = false;

			if ((sourceFighterID != destinationFighterID) && fighterIDToInfoPacks.ContainsKey(sourceFighterID))
			{
				fighterIDToInfoPacks[destinationFighterID] = fighterIDToInfoPacks[sourceFighterID];
				tableSectionBodyIsDirty = true;
			}

			return result;
		}
		public bool eraseHatInfo(uint targetFighterID)
		{
			bool result = false;

			if (fighterIDToInfoPacks.ContainsKey(targetFighterID))
			{
				fighterIDToInfoPacks.Remove(targetFighterID);
				tableSectionBodyIsDirty = true;
			}

			return result;
		}
	}
}
