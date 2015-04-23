namespace SPBSU.Dynamic {
	partial class EditPatameterValuesArea {
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
			this.labelMin = new System.Windows.Forms.Label();
			this.labelMax = new System.Windows.Forms.Label();
			this.numericUpDownMin = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMax = new System.Windows.Forms.NumericUpDown();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).BeginInit();
			this.SuspendLayout();
			// 
			// labelMin
			// 
			this.labelMin.AutoSize = true;
			this.labelMin.Location = new System.Drawing.Point(37, 72);
			this.labelMin.Name = "labelMin";
			this.labelMin.Size = new System.Drawing.Size(24, 13);
			this.labelMin.TabIndex = 0;
			this.labelMin.Text = "Min";
			// 
			// labelMax
			// 
			this.labelMax.AutoSize = true;
			this.labelMax.Location = new System.Drawing.Point(176, 72);
			this.labelMax.Name = "labelMax";
			this.labelMax.Size = new System.Drawing.Size(27, 13);
			this.labelMax.TabIndex = 1;
			this.labelMax.Text = "Max";
			// 
			// numericUpDownMin
			// 
			this.numericUpDownMin.DecimalPlaces = 4;
			this.numericUpDownMin.Location = new System.Drawing.Point(32, 129);
			this.numericUpDownMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownMin.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.numericUpDownMin.Name = "numericUpDownMin";
			this.numericUpDownMin.Size = new System.Drawing.Size(83, 20);
			this.numericUpDownMin.TabIndex = 2;
			// 
			// numericUpDownMax
			// 
			this.numericUpDownMax.DecimalPlaces = 4;
			this.numericUpDownMax.Location = new System.Drawing.Point(179, 129);
			this.numericUpDownMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownMax.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.numericUpDownMax.Name = "numericUpDownMax";
			this.numericUpDownMax.Size = new System.Drawing.Size(76, 20);
			this.numericUpDownMax.TabIndex = 3;
			this.numericUpDownMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(40, 201);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 4;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(168, 201);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// EditPatameterValuesArea
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.numericUpDownMax);
			this.Controls.Add(this.numericUpDownMin);
			this.Controls.Add(this.labelMax);
			this.Controls.Add(this.labelMin);
			this.Name = "EditPatameterValuesArea";
			this.Text = "EditPatameterValuesArea";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelMin;
		private System.Windows.Forms.Label labelMax;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		public System.Windows.Forms.NumericUpDown numericUpDownMin;
		public System.Windows.Forms.NumericUpDown numericUpDownMax;
	}
}