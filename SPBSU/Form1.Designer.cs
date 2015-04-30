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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
			this.checkBoxScatterPlot = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.graph21 = new Graph.Graph2();
			this.graphSystemOscillogram2 = new Graph.GraphSystemOscillogram();
			this.graphSystemOscillogram1 = new Graph.GraphSystemOscillogram();
			this.graph1 = new Graph.GraphSystemBehavior();
			((System.ComponentModel.ISupportInitialize)(this.trackBarAlfa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarBetta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarInitialX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarInitialY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBarAlfa
			// 
			this.trackBarAlfa.Location = new System.Drawing.Point(556, 21);
			this.trackBarAlfa.Maximum = 500;
			this.trackBarAlfa.Name = "trackBarAlfa";
			this.trackBarAlfa.Size = new System.Drawing.Size(104, 45);
			this.trackBarAlfa.SmallChange = 10;
			this.trackBarAlfa.TabIndex = 1;
			this.trackBarAlfa.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			this.trackBarAlfa.MouseEnter += new System.EventHandler(this.trackBarAlfa_MouseEnter);
			// 
			// labelAlfaValue
			// 
			this.labelAlfaValue.AutoSize = true;
			this.labelAlfaValue.Location = new System.Drawing.Point(705, 21);
			this.labelAlfaValue.Name = "labelAlfaValue";
			this.labelAlfaValue.Size = new System.Drawing.Size(13, 13);
			this.labelAlfaValue.TabIndex = 2;
			this.labelAlfaValue.Text = "1";
			// 
			// trackBarBetta
			// 
			this.trackBarBetta.Location = new System.Drawing.Point(556, 72);
			this.trackBarBetta.Maximum = 300;
			this.trackBarBetta.Minimum = -300;
			this.trackBarBetta.Name = "trackBarBetta";
			this.trackBarBetta.Size = new System.Drawing.Size(104, 45);
			this.trackBarBetta.TabIndex = 3;
			this.trackBarBetta.Scroll += new System.EventHandler(this.trackBarBetta_Scroll);
			// 
			// trackBarInitialX
			// 
			this.trackBarInitialX.Location = new System.Drawing.Point(556, 123);
			this.trackBarInitialX.Maximum = 100;
			this.trackBarInitialX.Name = "trackBarInitialX";
			this.trackBarInitialX.Size = new System.Drawing.Size(104, 45);
			this.trackBarInitialX.TabIndex = 4;
			this.trackBarInitialX.Value = 50;
			this.trackBarInitialX.Scroll += new System.EventHandler(this.trackBarInitialX_Scroll);
			// 
			// trackBarInitialY
			// 
			this.trackBarInitialY.Location = new System.Drawing.Point(556, 162);
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
			this.labelBettaValue.Location = new System.Drawing.Point(705, 72);
			this.labelBettaValue.Name = "labelBettaValue";
			this.labelBettaValue.Size = new System.Drawing.Size(13, 13);
			this.labelBettaValue.TabIndex = 6;
			this.labelBettaValue.Text = "1";
			// 
			// labelInitalXValue
			// 
			this.labelInitalXValue.AutoSize = true;
			this.labelInitalXValue.Location = new System.Drawing.Point(705, 123);
			this.labelInitalXValue.Name = "labelInitalXValue";
			this.labelInitalXValue.Size = new System.Drawing.Size(13, 13);
			this.labelInitalXValue.TabIndex = 7;
			this.labelInitalXValue.Text = "0";
			// 
			// labelInitialYValue
			// 
			this.labelInitialYValue.AutoSize = true;
			this.labelInitialYValue.Location = new System.Drawing.Point(705, 162);
			this.labelInitialYValue.Name = "labelInitialYValue";
			this.labelInitialYValue.Size = new System.Drawing.Size(35, 13);
			this.labelInitialYValue.TabIndex = 8;
			this.labelInitialYValue.Text = "label3";
			// 
			// labelAlfaLabel
			// 
			this.labelAlfaLabel.AutoSize = true;
			this.labelAlfaLabel.Location = new System.Drawing.Point(495, 21);
			this.labelAlfaLabel.Name = "labelAlfaLabel";
			this.labelAlfaLabel.Size = new System.Drawing.Size(25, 13);
			this.labelAlfaLabel.TabIndex = 9;
			this.labelAlfaLabel.Text = "Alfa";
			// 
			// labelBettaLabel
			// 
			this.labelBettaLabel.AutoSize = true;
			this.labelBettaLabel.Location = new System.Drawing.Point(495, 72);
			this.labelBettaLabel.Name = "labelBettaLabel";
			this.labelBettaLabel.Size = new System.Drawing.Size(32, 13);
			this.labelBettaLabel.TabIndex = 10;
			this.labelBettaLabel.Text = "Betta";
			// 
			// labelInitialXLabel
			// 
			this.labelInitialXLabel.AutoSize = true;
			this.labelInitialXLabel.Location = new System.Drawing.Point(495, 132);
			this.labelInitialXLabel.Name = "labelInitialXLabel";
			this.labelInitialXLabel.Size = new System.Drawing.Size(38, 13);
			this.labelInitialXLabel.TabIndex = 11;
			this.labelInitialXLabel.Text = "InitialX";
			// 
			// labelInitialYLabel
			// 
			this.labelInitialYLabel.AutoSize = true;
			this.labelInitialYLabel.Location = new System.Drawing.Point(495, 162);
			this.labelInitialYLabel.Name = "labelInitialYLabel";
			this.labelInitialYLabel.Size = new System.Drawing.Size(38, 13);
			this.labelInitialYLabel.TabIndex = 12;
			this.labelInitialYLabel.Text = "InitialY";
			// 
			// checkBoxScatterPlot
			// 
			this.checkBoxScatterPlot.AutoSize = true;
			this.checkBoxScatterPlot.Location = new System.Drawing.Point(498, 213);
			this.checkBoxScatterPlot.Name = "checkBoxScatterPlot";
			this.checkBoxScatterPlot.Size = new System.Drawing.Size(81, 17);
			this.checkBoxScatterPlot.TabIndex = 15;
			this.checkBoxScatterPlot.Text = "Scatter Plot";
			this.checkBoxScatterPlot.UseVisualStyleBackColor = true;
			this.checkBoxScatterPlot.CheckedChanged += new System.EventHandler(this.checkBoxScatterPlot_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(615, 324);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 30);
			this.button1.TabIndex = 16;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(556, 266);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 17;
			this.textBox1.Text = "Sin(x)+1";
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(498, 292);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(104, 45);
			this.trackBar1.SmallChange = 2;
			this.trackBar1.TabIndex = 18;
			this.trackBar1.TickFrequency = 2;
			// 
			// graph21
			// 
			this.graph21.AxisXlabel = "x";
			this.graph21.AxisYlabel = "y";
			this.graph21.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graph21.Data = ((System.Collections.Generic.Dictionary<string, System.Collections.ObjectModel.ObservableCollection<double>>)(resources.GetObject("graph21.Data")));
			this.graph21.DrawnPoints = 0;
			this.graph21.IsAxisVisible = true;
			this.graph21.Location = new System.Drawing.Point(186, 429);
			this.graph21.MoveButtonsExist = true;
			this.graph21.Name = "graph21";
			this.graph21.Scatter = false;
			this.graph21.Size = new System.Drawing.Size(430, 235);
			this.graph21.TabIndex = 19;
			this.graph21.ZoomButtonsExist = true;
			// 
			// graphSystemOscillogram2
			// 
			this.graphSystemOscillogram2.AxisXlabel = "x";
			this.graphSystemOscillogram2.AxisYlabel = "y";
			this.graphSystemOscillogram2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graphSystemOscillogram2.GraphHist = false;
			this.graphSystemOscillogram2.IsAxisVisible = true;
			this.graphSystemOscillogram2.Location = new System.Drawing.Point(767, 204);
			this.graphSystemOscillogram2.MoveButtonsExist = true;
			this.graphSystemOscillogram2.Name = "graphSystemOscillogram2";
			this.graphSystemOscillogram2.Scatter = false;
			this.graphSystemOscillogram2.Size = new System.Drawing.Size(464, 150);
			this.graphSystemOscillogram2.TabIndex = 14;
			this.graphSystemOscillogram2.ZoomButtonsExist = true;
			// 
			// graphSystemOscillogram1
			// 
			this.graphSystemOscillogram1.AxisXlabel = "x";
			this.graphSystemOscillogram1.AxisYlabel = "y";
			this.graphSystemOscillogram1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graphSystemOscillogram1.GraphHist = false;
			this.graphSystemOscillogram1.IsAxisVisible = true;
			this.graphSystemOscillogram1.Location = new System.Drawing.Point(767, 18);
			this.graphSystemOscillogram1.MoveButtonsExist = true;
			this.graphSystemOscillogram1.Name = "graphSystemOscillogram1";
			this.graphSystemOscillogram1.Scatter = false;
			this.graphSystemOscillogram1.Size = new System.Drawing.Size(464, 150);
			this.graphSystemOscillogram1.TabIndex = 13;
			this.graphSystemOscillogram1.ZoomButtonsExist = true;
			// 
			// graph1
			// 
			this.graph1.alfa = 0D;
			this.graph1.AxisXlabel = "x";
			this.graph1.AxisYlabel = "y";
			this.graph1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graph1.betta = 0D;
			this.graph1.f0 = null;
			//this.graph1.functionsD = null;
			this.graph1.GraphHist = true;
			this.graph1.GrowthX = 0D;
			this.graph1.GrowthY = 0D;
			this.graph1.initialX = 0D;
			this.graph1.initialY = 0D;
			this.graph1.IsAxisVisible = true;
			this.graph1.Location = new System.Drawing.Point(12, 12);
			this.graph1.MoveButtonsExist = true;
			this.graph1.Name = "graph1";
			this.graph1.Scatter = true;
			this.graph1.Size = new System.Drawing.Size(464, 363);
			this.graph1.t0 = 0D;
			this.graph1.TabIndex = 0;
			this.graph1.UserDynamicFunctions = false;
			this.graph1.ZoomButtonsExist = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1243, 716);
			this.Controls.Add(this.graph21);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBoxScatterPlot);
			this.Controls.Add(this.graphSystemOscillogram2);
			this.Controls.Add(this.graphSystemOscillogram1);
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
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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
		private Graph.GraphSystemOscillogram graphSystemOscillogram1;
		private Graph.GraphSystemOscillogram graphSystemOscillogram2;
		private System.Windows.Forms.CheckBox checkBoxScatterPlot;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TrackBar trackBar1;
		private Graph.Graph2 graph21;

	}
}

