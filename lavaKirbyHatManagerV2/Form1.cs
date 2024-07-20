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
		string[] defaultKirbyRelPaths = { "./ft_kirby.rel", "../pf/module/ft_kirby.rel" };
		KirbyHatManager hatManager = new KirbyHatManager();
		BrawlLib.SSBB.ResourceNodes.RELNode kirbyModule = null;

		void applyHatsFromTXT(string filepath)
		{
			if (System.IO.File.Exists(filepath))
			{
				List<TXTHatInfo> temp = new List<TXTHatInfo>();
				KirbyHatTXTParser.parseKirbyHatsTXT(filepath, temp);

				foreach (TXTHatInfo hat in temp)
				{
					hatManager.copyHatToSlot(hat.sourceID, hat.destinationID, true);
					HatNames.setFIDName(hat.destinationID, hat.name, true);
				}

				populateTreeView();
			}
		}

		bool tryLoadHatNamesFromBuildConfigFolder(string relPath)
		{
			bool result = false;

			string absolutePath = System.IO.Path.GetFullPath(relPath);

			int moduleDirPos = absolutePath.LastIndexOf("module" + System.IO.Path.DirectorySeparatorChar);
			if (moduleDirPos != -1)
			{
				string configFolderPath = absolutePath.Substring(0, moduleDirPos) + "BrawlEx/FighterConfig/";
				result = HatNames.tryPopulateFromFighterConfigFolder(configFolderPath, true);
			}

			return result;
		}

		bool loadModule(string filepath)
		{
			bool result = false;

			treeViewKirbyHats.Nodes.Clear();
			propertyGridHatDetails.SelectedObject = null;

			if (System.IO.File.Exists(filepath))
			{
				kirbyModule = new BrawlLib.SSBB.ResourceNodes.RELNode();
				kirbyModule.Replace(filepath);
				kirbyModule._origPath = filepath;

				if (hatManager.loadHatEntriesFromREL(kirbyModule))
				{
					tryLoadHatNamesFromBuildConfigFolder(filepath);
					HatNames.pruneNamesWithNoAssociatedHat(hatManager);
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
				TreeNode newNode = new TreeNode("[" + x.Key.ToString("X2") + "] " + HatNames.getNameFromFID(x.Key));
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
			saveModuleToolStripMenuItem.Enabled = true;
		}
		void disableControls()
		{
			buttonCreateHat.Enabled = false;
			buttonCloneHat.Enabled = false;
			buttonDeleteHat.Enabled = false;
			buttonMoveHat.Enabled = false;
			buttonExpandContract.Enabled = false;
			propertyGridHatDetails.Enabled = false;
			saveModuleToolStripMenuItem.Enabled = false;
		}
		void expandForm()
		{
			var tempSize = this.Size;
			tempSize.Width = 800;
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
			foreach (string defaultPath in defaultKirbyRelPaths)
			{
				if (loadModule(defaultPath)) break;
			}
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
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "*Module File(*.rel)|*.rel";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				if (hatManager.writeTablesToREL(kirbyModule))
				{
					kirbyModule.Export(sfd.FileName);
				}
			}
		}

		private void buttonDeleteHat_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Delete the selected hat?", "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
			if (treeViewKirbyHats.SelectedNode != null)
			{
				int selectedIndex = treeViewKirbyHats.SelectedNode.Index;

				uint targetFID = (uint)treeViewKirbyHats.SelectedNode.Tag;
				if (hatManager.eraseHat(targetFID))
				{
					HatNames.eraseFIDName(targetFID);
				}

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
			var IDForm = new SelectFighterIDForm("Fighter ID to Clone to:", hatManager);
			IDForm.checkBoxSetName.Visible = true;
			if (IDForm.ShowDialog() != DialogResult.OK) return;

			uint sourceID = (uint)treeViewKirbyHats.SelectedNode.Tag;
			uint destinationID = (uint)IDForm.numericUpDownFID.Value;

			if (hatManager.copyHatToSlot(sourceID, destinationID, true) && IDForm.checkBoxSetName.Checked)
			{
				HatNames.copyFIDName(sourceID, destinationID, true);
			}

			populateTreeView();
			selectKirbyHatFromFID(destinationID);
			treeViewKirbyHats.Focus();
		}
		private void buttonMoveHat_Click(object sender, EventArgs e)
		{
			var IDForm = new SelectFighterIDForm("Fighter ID to Move to:", hatManager);
			IDForm.checkBoxSetName.Visible = false;
			if (IDForm.ShowDialog() != DialogResult.OK) return;

			uint sourceID = (uint)treeViewKirbyHats.SelectedNode.Tag;
			uint destinationID = (uint)IDForm.numericUpDownFID.Value;
			if (hatManager.moveHatToSlot(sourceID, destinationID, true))
			{
				HatNames.moveFIDName(sourceID, destinationID, true);
			}

			populateTreeView();
			selectKirbyHatFromFID(destinationID);
			treeViewKirbyHats.Focus();
		}
		private void buttonCreateHat_Click(object sender, EventArgs e)
		{
			var IDForm = new SelectFighterIDForm("Fighter ID for New Hat:", hatManager);
			if (IDForm.ShowDialog() != DialogResult.OK) return;

			uint destinationID = (uint)IDForm.numericUpDownFID.Value;
			hatManager.createNewHat(destinationID);

			populateTreeView();
			selectKirbyHatFromFID(destinationID);
			treeViewKirbyHats.Focus();
		}

		private void treeViewKirbyHats_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (treeViewKirbyHats.SelectedNode != null)
			{
				propertyGridHatDetails.SelectedObject = hatManager.fighterIDToInfoPacks[(uint)treeViewKirbyHats.SelectedNode.Tag];
				propertyGridHatDetails.ExpandAllGridItems();
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
			propertyGridHatDetails.Refresh();
		}

		private void applyHatsFromTXTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Hat List File(*.txt)|*.txt";
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				applyHatsFromTXT(ofd.FileName);
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}
	}
}
