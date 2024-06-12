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
		bool formExpanded = false;
		String defaultKirbyRelPath = "./ft_kirby.rel";
		KirbyHatManager hatManager = new KirbyHatManager();
		BrawlLib.SSBB.ResourceNodes.RELNode kirbyModule = null;

		bool loadModule(string filepath)
		{
			bool result = false;

			if (System.IO.File.Exists(filepath))
			{
				kirbyModule = new BrawlLib.SSBB.ResourceNodes.RELNode();
				kirbyModule.Replace(filepath);
				kirbyModule._origPath = filepath;

				if (hatManager.loadHatEntriesFromREL(kirbyModule))
				{
					populateTreeView();
					result = true;
				}
				else
				{
					kirbyModule = null;
				}
			}

			if (result)
			{
				enableControls();
			}
			else
			{
				disableControls();
			}

			return result;
		}
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
		void enableControls()
		{
			buttonCreateHat.Enabled = true;
			buttonCloneHat.Enabled = true;
			buttonDeleteHat.Enabled = true;
			buttonMoveHat.Enabled = true;
			buttonExpandContract.Enabled = true;
			propertyGridHatDetails.Enabled = true;
		}
		void disableControls()
		{
			buttonCreateHat.Enabled = false;
			buttonCloneHat.Enabled = false;
			buttonDeleteHat.Enabled = false;
			buttonMoveHat.Enabled = false;
			buttonExpandContract.Enabled = false;
			propertyGridHatDetails.Enabled = false;
		}
		void expandForm()
		{
			var tempSize = this.Size;
			tempSize.Width = 750;
			buttonExpandContract.Text = "<<";
			propertyGridHatDetails.TabStop = true;
			formExpanded = true;
			this.Size = tempSize;
		}
		void contractForm()
		{
			var tempSize = this.Size;
			tempSize.Width = 450;
			buttonExpandContract.Text = ">>";
			propertyGridHatDetails.TabStop = false;
			formExpanded = false;
			this.Size = tempSize;
		}
		void setFormExpanded(bool expandedIn)
		{
			if (expandedIn)
			{
				expandForm();
			}
			else
			{
				contractForm();
			}
		}
		void invertFormExpanded()
		{
			setFormExpanded(!formExpanded);
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
			loadModule(defaultKirbyRelPath);
			setFormExpanded(formExpanded);
		}

		private void openModuleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Module File(*.rel)|*.rel";
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				loadModule(ofd.FileName);
			}
		}
		private void saveModuleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string tempFilename = System.IO.Path.GetTempFileName();
			if (hatManager.buildAndExportTables(tempFilename))
			{
				var tableSectionNode = kirbyModule.FindChild(KirbyHatManager.tableSectionName) as BrawlLib.SSBB.ResourceNodes.ModuleSectionNode;
				if (tableSectionNode != null)
				{
					tableSectionNode.Replace(tempFilename);

					SaveFileDialog sfd = new SaveFileDialog();
					sfd.Filter = "*Module File(*.rel)|*.rel";
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						Console.WriteLine("");
						kirbyModule.Export(sfd.FileName);
					}

					System.IO.File.Delete(tempFilename);
				}
			}
		}

		private void buttonDeleteHat_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Delete the selected hat?", "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
			if (treeViewKirbyHats.SelectedNode != null)
			{
				int selectedIndex = treeViewKirbyHats.SelectedNode.Index;
				hatManager.eraseHat((uint)treeViewKirbyHats.SelectedNode.Tag);
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
			hatManager.copyHatToSlot(sourceID, (uint)IDForm.numericUpDownFID.Value);

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
			hatManager.createNewHat((uint)IDForm.numericUpDownFID.Value);

			populateTreeView();
			selectKirbyHatFromFID(destinationID);
			treeViewKirbyHats.Focus();
		}

		private void treeViewKirbyHats_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (treeViewKirbyHats.SelectedNode != null)
			{
				propertyGridHatDetails.SelectedObject = hatManager.fighterIDToInfoPacks[(uint)treeViewKirbyHats.SelectedNode.Tag];
			}
		}

		private void buttonExpandContract_Click(object sender, EventArgs e)
		{
			invertFormExpanded();
		}

		private void propertyGridHatDetails_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if (treeViewKirbyHats.SelectedNode != null && e.ChangedItem.Label == "Name")
			{
				uint selectedNodeFID = (uint)treeViewKirbyHats.SelectedNode.Tag;
				populateTreeView();
				selectKirbyHatFromFID(selectedNodeFID);
			}
		}
	}
}
