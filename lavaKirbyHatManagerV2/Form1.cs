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
			LoadRELAndTable();
		}

		private void LoadRELAndTable()
		{
			if (hatManager.loadKirbyREL(kirbyRelPath))
			{
				hatManager.parseHatsSectionBody();
				hatManager.summarizeHatTable();
				hatManager.copyHatInfoToEmptySlot((uint)Constants.LAVA_CHARA_FIGHTER_IDS.CAPTAIN_FALCON, 0x69);
				hatManager.summarizeHatTable();
			}
		}
	}
}
