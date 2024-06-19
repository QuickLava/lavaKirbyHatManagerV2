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
	public partial class SelectFighterIDForm : Form
	{
		public SelectFighterIDForm(string contextStringIn = "")
		{
			InitializeComponent();
			labelContext.Text = contextStringIn;
			TextBox numTextBox = numericUpDownFID.Controls[1] as TextBox;
			numTextBox.CharacterCasing = CharacterCasing.Upper;
			numTextBox.MaxLength = 2;
		}

		private void buttonOkay_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void numericUpDownFID_KeyDown(object sender, KeyEventArgs e)
		{
			string allowedChars = "0123456789ABCDEF";
			if (!allowedChars.Contains((char)e.KeyCode))
			{
				e.SuppressKeyPress = true;
			}
		}
	}
}
