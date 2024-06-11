
namespace lKHM
{
	partial class SelectFighterIDForm
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
			this.labelContext = new System.Windows.Forms.Label();
			this.numericUpDownFID = new System.Windows.Forms.NumericUpDown();
			this.buttonOkay = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFID)).BeginInit();
			this.SuspendLayout();
			// 
			// labelContext
			// 
			this.labelContext.AutoSize = true;
			this.labelContext.Location = new System.Drawing.Point(13, 13);
			this.labelContext.Name = "labelContext";
			this.labelContext.Size = new System.Drawing.Size(46, 17);
			this.labelContext.TabIndex = 0;
			this.labelContext.Text = "label1";
			// 
			// numericUpDownFID
			// 
			this.numericUpDownFID.Hexadecimal = true;
			this.numericUpDownFID.Location = new System.Drawing.Point(16, 34);
			this.numericUpDownFID.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.numericUpDownFID.Name = "numericUpDownFID";
			this.numericUpDownFID.Size = new System.Drawing.Size(156, 22);
			this.numericUpDownFID.TabIndex = 1;
			this.numericUpDownFID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// buttonOkay
			// 
			this.buttonOkay.Location = new System.Drawing.Point(16, 63);
			this.buttonOkay.Name = "buttonOkay";
			this.buttonOkay.Size = new System.Drawing.Size(75, 23);
			this.buttonOkay.TabIndex = 2;
			this.buttonOkay.Text = "Okay";
			this.buttonOkay.UseVisualStyleBackColor = true;
			this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(97, 63);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// SelectFighterIDForm
			// 
			this.AcceptButton = this.buttonOkay;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(188, 98);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOkay);
			this.Controls.Add(this.numericUpDownFID);
			this.Controls.Add(this.labelContext);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectFighterIDForm";
			this.Text = "Select ID";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelContext;
		private System.Windows.Forms.Button buttonOkay;
		private System.Windows.Forms.Button buttonCancel;
		public System.Windows.Forms.NumericUpDown numericUpDownFID;
	}
}