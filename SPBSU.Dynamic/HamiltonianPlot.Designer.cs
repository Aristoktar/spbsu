namespace SPBSU.Dynamic {
	partial class HamiltonianPlot {
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
			this.graphSystemOscillogram1 = new Graph.GraphSystemOscillogram();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// graphSystemOscillogram1
			// 
			this.graphSystemOscillogram1.Animate = false;
			this.graphSystemOscillogram1.AnimatePeriod = 1;
			this.graphSystemOscillogram1.AxisXlabel = "x";
			this.graphSystemOscillogram1.AxisYlabel = "y";
			this.graphSystemOscillogram1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graphSystemOscillogram1.GraphHist = false;
			this.graphSystemOscillogram1.IsAxisVisible = true;
			this.graphSystemOscillogram1.Location = new System.Drawing.Point(12, 12);
			this.graphSystemOscillogram1.MoveButtonsExist = true;
			this.graphSystemOscillogram1.Name = "graphSystemOscillogram1";
			this.graphSystemOscillogram1.SavePastValues = false;
			this.graphSystemOscillogram1.Scatter = false;
			this.graphSystemOscillogram1.Size = new System.Drawing.Size(981, 373);
			this.graphSystemOscillogram1.TabIndex = 0;
			this.graphSystemOscillogram1.ZoomButtonsExist = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(918, 362);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// HamiltonianPlot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1005, 397);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.graphSystemOscillogram1);
			this.Name = "HamiltonianPlot";
			this.Text = "HamiltonianPlot";
			this.SizeChanged += new System.EventHandler(this.HamiltonianPlot_SizeChanged);
			this.ResumeLayout(false);

		}

		#endregion

		public Graph.GraphSystemOscillogram graphSystemOscillogram1;
		private System.Windows.Forms.Button button1;

	}
}