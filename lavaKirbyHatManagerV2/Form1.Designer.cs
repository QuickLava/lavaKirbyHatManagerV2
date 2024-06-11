
namespace lKHM
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
			this.labelInputFile = new System.Windows.Forms.Label();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.textBoxInputFile = new System.Windows.Forms.TextBox();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.labelKirbyHats = new System.Windows.Forms.Label();
			this.treeViewKirbyHats = new System.Windows.Forms.TreeView();
			this.buttonCreateHat = new System.Windows.Forms.Button();
			this.buttonCloneHat = new System.Windows.Forms.Button();
			this.buttonDeleteHat = new System.Windows.Forms.Button();
			this.buttonMoveHat = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelInputFile
			// 
			this.labelInputFile.AutoSize = true;
			this.labelInputFile.Location = new System.Drawing.Point(13, 9);
			this.labelInputFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelInputFile.Name = "labelInputFile";
			this.labelInputFile.Size = new System.Drawing.Size(80, 17);
			this.labelInputFile.TabIndex = 35;
			this.labelInputFile.Text = "Module File";
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(591, 29);
			this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(33, 28);
			this.buttonBrowse.TabIndex = 34;
			this.buttonBrowse.Text = "...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// textBoxInputFile
			// 
			this.textBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInputFile.Enabled = false;
			this.textBoxInputFile.Location = new System.Drawing.Point(13, 32);
			this.textBoxInputFile.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxInputFile.Name = "textBoxInputFile";
			this.textBoxInputFile.Size = new System.Drawing.Size(569, 22);
			this.textBoxInputFile.TabIndex = 36;
			this.textBoxInputFile.TabStop = false;
			// 
			// buttonOpen
			// 
			this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpen.Location = new System.Drawing.Point(632, 29);
			this.buttonOpen.Margin = new System.Windows.Forms.Padding(4);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(134, 28);
			this.buttonOpen.TabIndex = 37;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// labelKirbyHats
			// 
			this.labelKirbyHats.AutoSize = true;
			this.labelKirbyHats.Location = new System.Drawing.Point(13, 72);
			this.labelKirbyHats.Name = "labelKirbyHats";
			this.labelKirbyHats.Size = new System.Drawing.Size(77, 17);
			this.labelKirbyHats.TabIndex = 39;
			this.labelKirbyHats.Text = "Kirby Hats:";
			// 
			// treeViewKirbyHats
			// 
			this.treeViewKirbyHats.HideSelection = false;
			this.treeViewKirbyHats.Location = new System.Drawing.Point(13, 93);
			this.treeViewKirbyHats.Name = "treeViewKirbyHats";
			this.treeViewKirbyHats.ShowPlusMinus = false;
			this.treeViewKirbyHats.ShowRootLines = false;
			this.treeViewKirbyHats.Size = new System.Drawing.Size(272, 414);
			this.treeViewKirbyHats.TabIndex = 40;
			// 
			// buttonCreateHat
			// 
			this.buttonCreateHat.Location = new System.Drawing.Point(292, 93);
			this.buttonCreateHat.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCreateHat.Name = "buttonCreateHat";
			this.buttonCreateHat.Size = new System.Drawing.Size(134, 28);
			this.buttonCreateHat.TabIndex = 41;
			this.buttonCreateHat.Text = "New Hat";
			this.buttonCreateHat.UseVisualStyleBackColor = true;
			this.buttonCreateHat.Click += new System.EventHandler(this.buttonCreateHat_Click);
			// 
			// buttonCloneHat
			// 
			this.buttonCloneHat.Location = new System.Drawing.Point(292, 129);
			this.buttonCloneHat.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCloneHat.Name = "buttonCloneHat";
			this.buttonCloneHat.Size = new System.Drawing.Size(134, 28);
			this.buttonCloneHat.TabIndex = 42;
			this.buttonCloneHat.Text = "Clone Selected";
			this.buttonCloneHat.UseVisualStyleBackColor = true;
			this.buttonCloneHat.Click += new System.EventHandler(this.buttonCloneHat_Click);
			// 
			// buttonDeleteHat
			// 
			this.buttonDeleteHat.Location = new System.Drawing.Point(292, 165);
			this.buttonDeleteHat.Margin = new System.Windows.Forms.Padding(4);
			this.buttonDeleteHat.Name = "buttonDeleteHat";
			this.buttonDeleteHat.Size = new System.Drawing.Size(134, 28);
			this.buttonDeleteHat.TabIndex = 43;
			this.buttonDeleteHat.Text = "Delete Selected";
			this.buttonDeleteHat.UseVisualStyleBackColor = true;
			this.buttonDeleteHat.Click += new System.EventHandler(this.buttonDeleteHat_Click);
			// 
			// buttonMoveHat
			// 
			this.buttonMoveHat.Location = new System.Drawing.Point(292, 201);
			this.buttonMoveHat.Margin = new System.Windows.Forms.Padding(4);
			this.buttonMoveHat.Name = "buttonMoveHat";
			this.buttonMoveHat.Size = new System.Drawing.Size(134, 28);
			this.buttonMoveHat.TabIndex = 44;
			this.buttonMoveHat.Text = "Move Selected";
			this.buttonMoveHat.UseVisualStyleBackColor = true;
			this.buttonMoveHat.Click += new System.EventHandler(this.buttonMoveHat_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 519);
			this.Controls.Add(this.buttonMoveHat);
			this.Controls.Add(this.buttonDeleteHat);
			this.Controls.Add(this.buttonCloneHat);
			this.Controls.Add(this.buttonCreateHat);
			this.Controls.Add(this.treeViewKirbyHats);
			this.Controls.Add(this.labelKirbyHats);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.labelInputFile);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxInputFile);
			this.Name = "Form1";
			this.Text = "lavaKirbyHatManager";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelInputFile;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.TextBox textBoxInputFile;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Label labelKirbyHats;
		private System.Windows.Forms.TreeView treeViewKirbyHats;
		private System.Windows.Forms.Button buttonCreateHat;
		private System.Windows.Forms.Button buttonCloneHat;
		private System.Windows.Forms.Button buttonDeleteHat;
		private System.Windows.Forms.Button buttonMoveHat;
	}
}

