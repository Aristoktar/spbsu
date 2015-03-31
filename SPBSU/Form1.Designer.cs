namespace SPBSU {
	partial class Form1 {
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
			this.trackBarAlfa = new System.Windows.Forms.TrackBar();
			this.labelAlfaValue = new System.Windows.Forms.Label();
			this.trackBarBetta = new System.Windows.Forms.TrackBar();
			this.trackBarInitialX = new System.Windows.Forms.TrackBar();
			this.trackBarInitialY = new System.Windows.Forms.TrackBar();
			this.labelBettaValue = new System.Windows.Forms.Label();
			this.labelInitalXValue = new System.Windows.Forms.Label();
			this.labelInitialYValue = new System.Windows.Forms.Label();
			this.labelAlfaLabel = new System.Windows.Forms.Label();
			this.labelBettaLabel = new System.Windows.Forms.Label();
			this.labelInitialXLabel = new System.Windows.Forms.Label();
			this.labelInitialYLabel = new System.Windows.Forms.Label();
			this.graph1 = new Graph.GraphSystemBehavior();
			((System.ComponentModel.ISupportInitialize)(this.trackBarAlfa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarBetta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarInitialX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarInitialY)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBarAlfa
			// 
			this.trackBarAlfa.Location = new System.Drawing.Point(594, 38);
			this.trackBarAlfa.Maximum = 300;
			this.trackBarAlfa.Name = "trackBarAlfa";
			this.trackBarAlfa.Size = new System.Drawing.Size(104, 45);
			this.trackBarAlfa.TabIndex = 1;
			this.trackBarAlfa.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// labelAlfaValue
			// 
			this.labelAlfaValue.AutoSize = true;
			this.labelAlfaValue.Location = new System.Drawing.Point(743, 38);
			this.labelAlfaValue.Name = "labelAlfaValue";
			this.labelAlfaValue.Size = new System.Drawing.Size(13, 13);
			this.labelAlfaValue.TabIndex = 2;
			this.labelAlfaValue.Text = "1";
			// 
			// trackBarBetta
			// 
			this.trackBarBetta.Location = new System.Drawing.Point(594, 89);
			this.trackBarBetta.Maximum = 300;
			this.trackBarBetta.Name = "trackBarBetta";
			this.trackBarBetta.Size = new System.Drawing.Size(104, 45);
			this.trackBarBetta.TabIndex = 3;
			this.trackBarBetta.Scroll += new System.EventHandler(this.trackBarBetta_Scroll);
			// 
			// trackBarInitialX
			// 
			this.trackBarInitialX.Location = new System.Drawing.Point(594, 140);
			this.trackBarInitialX.Maximum = 100;
			this.trackBarInitialX.Name = "trackBarInitialX";
			this.trackBarInitialX.Size = new System.Drawing.Size(104, 45);
			this.trackBarInitialX.TabIndex = 4;
			this.trackBarInitialX.Value = 50;
			this.trackBarInitialX.Scroll += new System.EventHandler(this.trackBarInitialX_Scroll);
			// 
			// trackBarInitialY
			// 
			this.trackBarInitialY.Location = new System.Drawing.Point(594, 179);
			this.trackBarInitialY.Maximum = 100;
			this.trackBarInitialY.Name = "trackBarInitialY";
			this.trackBarInitialY.Size = new System.Drawing.Size(104, 45);
			this.trackBarInitialY.TabIndex = 5;
			this.trackBarInitialY.Value = 50;
			this.trackBarInitialY.Scroll += new System.EventHandler(this.trackBarInitialY_Scroll);
			// 
			// labelBettaValue
			// 
			this.labelBettaValue.AutoSize = true;
			this.labelBettaValue.Location = new System.Drawing.Point(743, 89);
			this.labelBettaValue.Name = "labelBettaValue";
			this.labelBettaValue.Size = new System.Drawing.Size(13, 13);
			this.labelBettaValue.TabIndex = 6;
			this.labelBettaValue.Text = "1";
			// 
			// labelInitalXValue
			// 
			this.labelInitalXValue.AutoSize = true;
			this.labelInitalXValue.Location = new System.Drawing.Point(743, 140);
			this.labelInitalXValue.Name = "labelInitalXValue";
			this.labelInitalXValue.Size = new System.Drawing.Size(13, 13);
			this.labelInitalXValue.TabIndex = 7;
			this.labelInitalXValue.Text = "0";
			// 
			// labelInitialYValue
			// 
			this.labelInitialYValue.AutoSize = true;
			this.labelInitialYValue.Location = new System.Drawing.Point(743, 179);
			this.labelInitialYValue.Name = "labelInitialYValue";
			this.labelInitialYValue.Size = new System.Drawing.Size(35, 13);
			this.labelInitialYValue.TabIndex = 8;
			this.labelInitialYValue.Text = "label3";
			// 
			// labelAlfaLabel
			// 
			this.labelAlfaLabel.AutoSize = true;
			this.labelAlfaLabel.Location = new System.Drawing.Point(533, 38);
			this.labelAlfaLabel.Name = "labelAlfaLabel";
			this.labelAlfaLabel.Size = new System.Drawing.Size(25, 13);
			this.labelAlfaLabel.TabIndex = 9;
			this.labelAlfaLabel.Text = "Alfa";
			// 
			// labelBettaLabel
			// 
			this.labelBettaLabel.AutoSize = true;
			this.labelBettaLabel.Location = new System.Drawing.Point(533, 89);
			this.labelBettaLabel.Name = "labelBettaLabel";
			this.labelBettaLabel.Size = new System.Drawing.Size(32, 13);
			this.labelBettaLabel.TabIndex = 10;
			this.labelBettaLabel.Text = "Betta";
			// 
			// labelInitialXLabel
			// 
			this.labelInitialXLabel.AutoSize = true;
			this.labelInitialXLabel.Location = new System.Drawing.Point(533, 149);
			this.labelInitialXLabel.Name = "labelInitialXLabel";
			this.labelInitialXLabel.Size = new System.Drawing.Size(38, 13);
			this.labelInitialXLabel.TabIndex = 11;
			this.labelInitialXLabel.Text = "InitialX";
			// 
			// labelInitialYLabel
			// 
			this.labelInitialYLabel.AutoSize = true;
			this.labelInitialYLabel.Location = new System.Drawing.Point(533, 179);
			this.labelInitialYLabel.Name = "labelInitialYLabel";
			this.labelInitialYLabel.Size = new System.Drawing.Size(38, 13);
			this.labelInitialYLabel.TabIndex = 12;
			this.labelInitialYLabel.Text = "InitialY";
			// 
			// graph1
			// 
			this.graph1.alfa = 0D;
			this.graph1.axisXlabel = "x";
			this.graph1.axisYlabel = "y";
			this.graph1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graph1.betta = 0D;
			this.graph1.graphHist = false;
			this.graph1.GrowthX = 0D;
			this.graph1.GrowthY = 0D;
			this.graph1.initialX = 0D;
			this.graph1.initialY = 0D;
			this.graph1.IsAxisVisible = true;
			this.graph1.Location = new System.Drawing.Point(27, 13);
			this.graph1.MoveButtonsExist = true;
			this.graph1.Name = "graph1";
			this.graph1.scatterGraph = false;
			this.graph1.Size = new System.Drawing.Size(464, 363);
			this.graph1.TabIndex = 0;
			this.graph1.ZoomButtonsExist = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(931, 388);
			this.Controls.Add(this.labelInitialYLabel);
			this.Controls.Add(this.labelInitialXLabel);
			this.Controls.Add(this.labelBettaLabel);
			this.Controls.Add(this.labelAlfaLabel);
			this.Controls.Add(this.labelInitialYValue);
			this.Controls.Add(this.labelInitalXValue);
			this.Controls.Add(this.labelBettaValue);
			this.Controls.Add(this.trackBarInitialY);
			this.Controls.Add(this.trackBarInitialX);
			this.Controls.Add(this.trackBarBetta);
			this.Controls.Add(this.labelAlfaValue);
			this.Controls.Add(this.trackBarAlfa);
			this.Controls.Add(this.graph1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.trackBarAlfa)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarBetta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarInitialX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarInitialY)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Graph.GraphSystemBehavior graph1;
		private System.Windows.Forms.TrackBar trackBarAlfa;
		private System.Windows.Forms.Label labelAlfaValue;
		private System.Windows.Forms.TrackBar trackBarBetta;
		private System.Windows.Forms.TrackBar trackBarInitialX;
		private System.Windows.Forms.TrackBar trackBarInitialY;
		private System.Windows.Forms.Label labelBettaValue;
		private System.Windows.Forms.Label labelInitalXValue;
		private System.Windows.Forms.Label labelInitialYValue;
		private System.Windows.Forms.Label labelAlfaLabel;
		private System.Windows.Forms.Label labelBettaLabel;
		private System.Windows.Forms.Label labelInitialXLabel;
		private System.Windows.Forms.Label labelInitialYLabel;

	}
}

