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
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			labelProgramName.Text = "lavaKirbyHatManager " + Program.Version;
			TreeNode currNode = null;
			currNode = treeView1.Nodes.Add("Created by: QuickLava");
			currNode = treeView1.Nodes.Add("lKHM Lib Version: " + KirbyHatManager.Version);
			currNode = treeView1.Nodes.Add("Program Homepage: https://https://github.com/QuickLava/lavaKirbyHatManagerV2/");
			currNode = treeView1.Nodes.Add("Based on Work by:");
			currNode.Nodes.Add("BrawlEx Team: Original EX Kirby Hat Implementation");
			currNode.Nodes.Add("DesiacX: EX Kirby Hats Quick Start Guide");
			currNode.Nodes.Add("Kapedani: Revamped EX Kirby Hat Implementation");
			currNode = treeView1.Nodes.Add("Powered by BrawlLib:");
			currNode.Nodes.Add("BrawlCrate Maintainers: soopercool101, Squidgy");
			currNode.Nodes.Add("BrawlCrate Homepage: https://github.com/soopercool101/BrawlCrate");
			currNode = treeView1.Nodes.Add("Special Thanks:");
			currNode.Nodes.Add("Kapedani, Squidgy, KingJigglypuff");
			treeView1.ExpandAll();
		}
	}
}
