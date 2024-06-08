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
		BrawlLib.SSBB.ResourceNodes.RELNode kirbyModule = new BrawlLib.SSBB.ResourceNodes.RELNode();

		public Form1()
		{
			InitializeComponent();
			Console.SetOut(new ControlWriter(consoleTextBox));

			if (System.IO.File.Exists(kirbyRelPath))
			{
				kirbyModule.Replace(kirbyRelPath);
				kirbyModule._origPath = kirbyRelPath;

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
		}
	}
}
