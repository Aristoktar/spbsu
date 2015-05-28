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
			this.textBoxInitial = new System.Windows.Forms.TextBox();
			this.textBoxFinal = new System.Windows.Forms.TextBox();
			this.textBoxStep = new System.Windows.Forms.TextBox();
			this.comboBoxValueToVariate = new System.Windows.Forms.ComboBox();
			this.buttonGenerate = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.checkBoxSaveToFolder = new System.Windows.Forms.CheckBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.buttonSaveGif = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxInitial
			// 
			this.textBoxInitial.Location = new System.Drawing.Point(333, 60);
			this.textBoxInitial.Name = "textBoxInitial";
			this.textBoxInitial.Size = new System.Drawing.Size(100, 20);
			this.textBoxInitial.TabIndex = 1;
			this.textBoxInitial.Text = "0.0625";
			// 
			// textBoxFinal
			// 
			this.textBoxFinal.Location = new System.Drawing.Point(333, 112);
			this.textBoxFinal.Name = "textBoxFinal";
			this.textBoxFinal.Size = new System.Drawing.Size(100, 20);
			this.textBoxFinal.TabIndex = 2;
			this.textBoxFinal.Text = "0.16666";
			// 
			// textBoxStep
			// 
			this.textBoxStep.Location = new System.Drawing.Point(333, 165);
			this.textBoxStep.Name = "textBoxStep";
			this.textBoxStep.Size = new System.Drawing.Size(100, 20);
			this.textBoxStep.TabIndex = 4;
			this.textBoxStep.Text = "10";
			// 
			// comboBoxValueToVariate
			// 
			this.comboBoxValueToVariate.FormattingEnabled = true;
			this.comboBoxValueToVariate.Location = new System.Drawing.Point(333, 12);
			this.comboBoxValueToVariate.Name = "comboBoxValueToVariate";
			this.comboBoxValueToVariate.Size = new System.Drawing.Size(121, 21);
			this.comboBoxValueToVariate.TabIndex = 5;
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
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(247, 317);
			this.flowLayoutPanel1.TabIndex = 7;
			// 
			// checkBoxSaveToFolder
			// 
			this.checkBoxSaveToFolder.AutoSize = true;
			this.checkBoxSaveToFolder.Location = new System.Drawing.Point(426, 218);
			this.checkBoxSaveToFolder.Name = "checkBoxSaveToFolder";
			this.checkBoxSaveToFolder.Size = new System.Drawing.Size(93, 17);
			this.checkBoxSaveToFolder.TabIndex = 8;
			this.checkBoxSaveToFolder.Text = "SaveToFolder";
			this.checkBoxSaveToFolder.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(692, 10);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(451, 285);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(692, 315);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(451, 45);
			this.trackBar1.TabIndex = 10;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// buttonSaveGif
			// 
			this.buttonSaveGif.Location = new System.Drawing.Point(372, 305);
			this.buttonSaveGif.Name = "buttonSaveGif";
			this.buttonSaveGif.Size = new System.Drawing.Size(75, 23);
			this.buttonSaveGif.TabIndex = 11;
			this.buttonSaveGif.Text = "SaveGif";
			this.buttonSaveGif.UseVisualStyleBackColor = true;
			this.buttonSaveGif.Click += new System.EventHandler(this.buttonSaveGif_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(453, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "images";
			// 
			// GifGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1200, 394);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonSaveGif);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.checkBoxSaveToFolder);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.buttonGenerate);
			this.Controls.Add(this.comboBoxValueToVariate);
			this.Controls.Add(this.textBoxStep);
			this.Controls.Add(this.textBoxFinal);
			this.Controls.Add(this.textBoxInitial);
			this.Name = "GifGenerator";
			this.Text = "GifGenerator";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxInitial;
		private System.Windows.Forms.TextBox textBoxFinal;
		private System.Windows.Forms.TextBox textBoxStep;
		private System.Windows.Forms.Button buttonGenerate;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		public System.Windows.Forms.ComboBox comboBoxValueToVariate;
		private System.Windows.Forms.CheckBox checkBoxSaveToFolder;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Button buttonSaveGif;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label1;
	}
}