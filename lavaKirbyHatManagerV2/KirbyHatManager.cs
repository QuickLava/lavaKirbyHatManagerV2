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
		enum LAVA_CHARA_SLOT_IDS
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
		enum LAVA_CHARA_FIGHTER_IDS
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

		public static Dictionary<uint, string> fighterIDsToNames = new Dictionary<uint, string>();

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

	class KirbyHatManager
	{
		const uint maxCharCount = 0x100;
		const uint table1EntrySize = 0x4;
		const uint table1Length = maxCharCount * table1EntrySize;
		const uint table2EntrySize = 0x4;
		const uint table2Length = maxCharCount * table2EntrySize;
		const uint table3EntrySize = 0x10;
		const uint table3Length = maxCharCount * table3EntrySize;
		const uint table4EntrySize = 0x10;
		const uint table4Length = maxCharCount * table4EntrySize;
		BrawlLib.SSBB.ResourceNodes.RELNode kirbyModule = new BrawlLib.SSBB.ResourceNodes.RELNode();

		uint getTable1EntryOffset(uint charIDIn)
		{
			uint result = uint.MaxValue;

			if (charIDIn < maxCharCount)
			{
				result = charIDIn * table1EntrySize;
			}

			return result;
		}
		uint getTable2EntryOffset(uint charIDIn)
		{
			uint result = uint.MaxValue;

			if (charIDIn < maxCharCount)
			{
				result = (charIDIn * table2EntrySize) + table1Length;
			}

			return result;
		}
		uint getTable3EntryOffset(uint charIDIn)
		{
			uint result = uint.MaxValue;

			if (charIDIn < maxCharCount)
			{
				result = (charIDIn * table3EntrySize) + table2Length + table1Length;
			}

			return result;
		}
		uint getTable4EntryOffset(uint charIDIn)
		{
			uint result = uint.MaxValue;

			if (charIDIn < maxCharCount)
			{
				result = (charIDIn * table4EntrySize) + table3Length + table2Length + table1Length;
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

				Console.WriteLine("Kirby Module Loaded:");
				Console.WriteLine("Name: " + kirbyModule.Name + "\n");
				Console.WriteLine("Size: " + kirbyModule.UncompressedSize.ToString("X3") + " bytes\n");
				Console.WriteLine("Sections:");
				foreach (var x in kirbyModule.Sections)
				{
					Console.WriteLine("  - " + x.Name);
				}
			}
			else
			{
				Console.WriteLine("Module Not Found.");
			}

			return result;
		}
	}
}
