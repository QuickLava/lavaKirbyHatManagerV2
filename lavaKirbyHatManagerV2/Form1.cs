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

		void populateTreeView()
		{
			treeViewKirbyHats.BeginUpdate();

			treeViewKirbyHats.Nodes.Clear();
			foreach (var x in hatManager.fighterIDToInfoPacks)
			{
				TreeNode newNode = new TreeNode("[" + x.Key.ToString("X2") + "] ");
				newNode.Tag = x.Key;
				if (Values.fighterIDsToNames.ContainsKey(x.Key))
				{
					newNode.Text += Values.fighterIDsToNames[x.Key];
				}
				else
				{
					newNode.Text += "UNNAMED_FIGHTER";
				}
				treeViewKirbyHats.Nodes.Add(newNode);
			}

			treeViewKirbyHats.EndUpdate();
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (hatManager.loadHatEntriesFromREL(kirbyRelPath))
			{
				hatManager.summarizeHatTable();
				hatManager.copyHatInfoToEmptySlot((uint)Values.LAVA_CHARA_FIGHTER_IDS.CAPTAIN_FALCON, 0x69, "GARBONZO");
				populateTreeView();
			}
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Module File(*.rel)|*.rel";
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				textBoxInputFile.Text = ofd.FileName;
			}
		}
		private void buttonOpen_Click(object sender, EventArgs e)
		{
			if (hatManager.loadHatEntriesFromREL(textBoxInputFile.Text))
			{
				populateTreeView();
			}
		}

		private void buttonDeleteHat_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Delete the selected hat?", "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
			if (treeViewKirbyHats.SelectedNode != null)
			{
				int selectedIndex = treeViewKirbyHats.SelectedNode.Index;
				hatManager.eraseHatInfo((uint)treeViewKirbyHats.SelectedNode.Tag);
				populateTreeView();
				if (selectedIndex < treeViewKirbyHats.Nodes.Count)
				{
					treeViewKirbyHats.SelectedNode = treeViewKirbyHats.Nodes[selectedIndex];
				}
				else if (treeViewKirbyHats.Nodes.Count > 0)
				{
					treeViewKirbyHats.SelectedNode = treeViewKirbyHats.Nodes[treeViewKirbyHats.Nodes.Count - 1];
				}
				treeViewKirbyHats.Focus();
			}
		}
	}
}
