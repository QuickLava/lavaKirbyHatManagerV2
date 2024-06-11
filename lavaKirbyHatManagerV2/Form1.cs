using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lKHM
{
	public partial class Form1 : Form
	{
		String kirbyRelPath = "./ft_kirby.rel";
		KirbyHatManager hatManager = new KirbyHatManager();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (hatManager.loadHatEntriesFromREL(kirbyRelPath))
			{
				hatManager.summarizeHatTable();
				hatManager.copyHatInfoToEmptySlot((uint)Values.LAVA_CHARA_FIGHTER_IDS.CAPTAIN_FALCON, 0x169, "GARBONZO");
				hatManager.summarizeHatTable();
				hatManager.buildAndExportTables("out.dat");
			}
		}
	}
}
