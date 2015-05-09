namespace SPBSU.Dynamic {
	partial class GifGenerator {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ();
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBoxInitial = new System.Windows.Forms.TextBox();
			this.textBoxFinal = new System.Windows.Forms.TextBox();
			this.comboBoxX = new System.Windows.Forms.ComboBox();
			this.textBoxStep = new System.Windows.Forms.TextBox();
			this.comboBoxY = new System.Windows.Forms.ComboBox();
			this.buttonGenerate = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(224, 182);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// textBoxInitial
			// 
			this.textBoxInitial.Location = new System.Drawing.Point(333, 60);
			this.textBoxInitial.Name = "textBoxInitial";
			this.textBoxInitial.Size = new System.Drawing.Size(100, 20);
			this.textBoxInitial.TabIndex = 1;
			this.textBoxInitial.Text = "0";
			// 
			// textBoxFinal
			// 
			this.textBoxFinal.Location = new System.Drawing.Point(333, 112);
			this.textBoxFinal.Name = "textBoxFinal";
			this.textBoxFinal.Size = new System.Drawing.Size(100, 20);
			this.textBoxFinal.TabIndex = 2;
			this.textBoxFinal.Text = "0.5";
			// 
			// comboBoxX
			// 
			this.comboBoxX.FormattingEnabled = true;
			this.comboBoxX.Location = new System.Drawing.Point(333, 12);
			this.comboBoxX.Name = "comboBoxX";
			this.comboBoxX.Size = new System.Drawing.Size(121, 21);
			this.comboBoxX.TabIndex = 3;
			// 
			// textBoxStep
			// 
			this.textBoxStep.Location = new System.Drawing.Point(333, 165);
			this.textBoxStep.Name = "textBoxStep";
			this.textBoxStep.Size = new System.Drawing.Size(100, 20);
			this.textBoxStep.TabIndex = 4;
			this.textBoxStep.Text = "0.1";
			// 
			// comboBoxY
			// 
			this.comboBoxY.FormattingEnabled = true;
			this.comboBoxY.Location = new System.Drawing.Point(485, 12);
			this.comboBoxY.Name = "comboBoxY";
			this.comboBoxY.Size = new System.Drawing.Size(121, 21);
			this.comboBoxY.TabIndex = 5;
			// 
			// buttonGenerate
			// 
			this.buttonGenerate.Location = new System.Drawing.Point(333, 214);
			this.buttonGenerate.Name = "buttonGenerate";
			this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
			this.buttonGenerate.TabIndex = 6;
			this.buttonGenerate.Text = "Generate";
			this.buttonGenerate.UseVisualStyleBackColor = true;
			this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
			// 
			// GifGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 394);
			this.Controls.Add(this.buttonGenerate);
			this.Controls.Add(this.comboBoxY);
			this.Controls.Add(this.textBoxStep);
			this.Controls.Add(this.comboBoxX);
			this.Controls.Add(this.textBoxFinal);
			this.Controls.Add(this.textBoxInitial);
			this.Controls.Add(this.pictureBox1);
			this.Name = "GifGenerator";
			this.Text = "GifGenerator";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBoxInitial;
		private System.Windows.Forms.TextBox textBoxFinal;
		private System.Windows.Forms.ComboBox comboBoxX;
		private System.Windows.Forms.TextBox textBoxStep;
		private System.Windows.Forms.ComboBox comboBoxY;
		private System.Windows.Forms.Button buttonGenerate;
	}
}