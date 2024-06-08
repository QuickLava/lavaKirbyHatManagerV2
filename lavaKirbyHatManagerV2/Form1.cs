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
			Console.SetOut(new ControlWriter(consoleTextBox));

			hatManager.loadKirbyREL(kirbyRelPath);
		}
	}
}
