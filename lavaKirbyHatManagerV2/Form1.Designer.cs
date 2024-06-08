
namespace lavaKirbyHatManagerV2
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.consoleTextBox = new System.Windows.Forms.TextBox();
			this.consoleLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// consoleTextBox
			// 
			this.consoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.consoleTextBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.consoleTextBox.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.consoleTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.consoleTextBox.Location = new System.Drawing.Point(12, 107);
			this.consoleTextBox.Multiline = true;
			this.consoleTextBox.Name = "consoleTextBox";
			this.consoleTextBox.ReadOnly = true;
			this.consoleTextBox.Size = new System.Drawing.Size(776, 410);
			this.consoleTextBox.TabIndex = 1;
			this.consoleTextBox.TabStop = false;
			// 
			// consoleLabel
			// 
			this.consoleLabel.AutoSize = true;
			this.consoleLabel.Location = new System.Drawing.Point(12, 87);
			this.consoleLabel.Name = "consoleLabel";
			this.consoleLabel.Size = new System.Drawing.Size(59, 17);
			this.consoleLabel.TabIndex = 0;
			this.consoleLabel.Text = "Console";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 519);
			this.Controls.Add(this.consoleLabel);
			this.Controls.Add(this.consoleTextBox);
			this.Name = "Form1";
			this.Text = "lavaKirbyHatManager";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label consoleLabel;
		public System.Windows.Forms.TextBox consoleTextBox;
	}
}

