﻿using System;
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
				TreeNode newNode = new TreeNode("[" + x.Key.ToString("X2") + "] " + x.Value.name);
				newNode.Tag = x.Key;
				treeViewKirbyHats.Nodes.Add(newNode);
			}

			treeViewKirbyHats.EndUpdate();
		}
		bool selectKirbyHatFromFID(uint targetFID)
		{
			bool result = false;

			foreach (TreeNode x in treeViewKirbyHats.Nodes)
			{
				uint currFID = (uint)x.Tag;

				if (currFID < targetFID) continue;
				if (currFID > targetFID) break;
				treeViewKirbyHats.SelectedNode = x;
			}

			return result;
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

		private void buttonCloneHat_Click(object sender, EventArgs e)
		{
			var IDForm = new SelectFighterIDForm("Fighter ID to Clone to:");
			if (IDForm.ShowDialog() != DialogResult.OK) return;

			if (hatManager.fighterIDToInfoPacks.ContainsKey((uint)IDForm.numericUpDownFID.Value))
			{
				if (MessageBox.Show("Target ID already has a hat! Overwrite the associated hat?", "Confirm Overwrite", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
			}

			uint sourceID = (uint)treeViewKirbyHats.SelectedNode.Tag;
			uint destinationID = (uint)IDForm.numericUpDownFID.Value;
			hatManager.copyHatInfoToSlot(sourceID, (uint)IDForm.numericUpDownFID.Value);

			populateTreeView();
			selectKirbyHatFromFID(destinationID);
			treeViewKirbyHats.Focus();
		}

		private void buttonMoveHat_Click(object sender, EventArgs e)
		{
			var IDForm = new SelectFighterIDForm("Fighter ID to Move to:");
			if (IDForm.ShowDialog() != DialogResult.OK) return;

			if (hatManager.fighterIDToInfoPacks.ContainsKey((uint)IDForm.numericUpDownFID.Value))
			{
				if (MessageBox.Show("Target ID already has a hat! Overwrite the associated hat?", "Confirm Overwrite", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
			}

			uint sourceID = (uint)treeViewKirbyHats.SelectedNode.Tag;
			uint destinationID = (uint)IDForm.numericUpDownFID.Value;
			hatManager.moveHatToNewFID(sourceID, (uint)IDForm.numericUpDownFID.Value);

			populateTreeView();
			selectKirbyHatFromFID(destinationID);
			treeViewKirbyHats.Focus();
		}

		private void buttonCreateHat_Click(object sender, EventArgs e)
		{
			var IDForm = new SelectFighterIDForm("Fighter ID for New Hat:");
			if (IDForm.ShowDialog() != DialogResult.OK) return;
			if (hatManager.fighterIDToInfoPacks.ContainsKey((uint)IDForm.numericUpDownFID.Value))
			{
				if (MessageBox.Show("Target ID already has a hat! Overwrite the associated hat?", "Confirm Overwrite", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
			}

			uint destinationID = (uint)IDForm.numericUpDownFID.Value;
			hatManager.createNewHatInfo((uint)IDForm.numericUpDownFID.Value);

			populateTreeView();
			selectKirbyHatFromFID(destinationID);
			treeViewKirbyHats.Focus();
		}
	}
}
