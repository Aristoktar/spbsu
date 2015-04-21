namespace SPBSU.Dynamic {
	partial class FormDynamicEquations {
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
			this.buttonAddEquation = new System.Windows.Forms.Button();
			this.buttonCalc = new System.Windows.Forms.Button();
			this.labelt0 = new System.Windows.Forms.Label();
			this.textBoxt0 = new System.Windows.Forms.TextBox();
			this.listBoxX = new System.Windows.Forms.ListBox();
			this.listBoxY = new System.Windows.Forms.ListBox();
			this.listBoxSystemName = new System.Windows.Forms.ListBox();
			this.labelParametersLabel = new System.Windows.Forms.Label();
			this.labelA = new System.Windows.Forms.Label();
			this.labelC = new System.Windows.Forms.Label();
			this.labelD = new System.Windows.Forms.Label();
			this.labelB = new System.Windows.Forms.Label();
			this.labelE = new System.Windows.Forms.Label();
			this.labelF = new System.Windows.Forms.Label();
			this.trackBarA = new System.Windows.Forms.TrackBar();
			this.trackBarB = new System.Windows.Forms.TrackBar();
			this.trackBarC = new System.Windows.Forms.TrackBar();
			this.trackBarD = new System.Windows.Forms.TrackBar();
			this.trackBarE = new System.Windows.Forms.TrackBar();
			this.trackBarF = new System.Windows.Forms.TrackBar();
			this.textBoxA = new System.Windows.Forms.TextBox();
			this.textBoxE = new System.Windows.Forms.TextBox();
			this.textBoxD = new System.Windows.Forms.TextBox();
			this.textBoxC = new System.Windows.Forms.TextBox();
			this.textBoxB = new System.Windows.Forms.TextBox();
			this.textBoxF = new System.Windows.Forms.TextBox();
			this.buttonA = new System.Windows.Forms.Button();
			this.buttonF = new System.Windows.Forms.Button();
			this.buttonE = new System.Windows.Forms.Button();
			this.buttonD = new System.Windows.Forms.Button();
			this.buttonC = new System.Windows.Forms.Button();
			this.buttonB = new System.Windows.Forms.Button();
			this.radioButtonRungeKutta4 = new System.Windows.Forms.RadioButton();
			this.radioButtonEuler = new System.Windows.Forms.RadioButton();
			this.graphSystemBehavior1 = new Graph.GraphDynamicType();
			this.radioButtonEulerSymplectic = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.trackBarA)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarC)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarF)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonAddEquation
			// 
			this.buttonAddEquation.Location = new System.Drawing.Point(498, 53);
			this.buttonAddEquation.Name = "buttonAddEquation";
			this.buttonAddEquation.Size = new System.Drawing.Size(75, 23);
			this.buttonAddEquation.TabIndex = 1;
			this.buttonAddEquation.Text = "Add";
			this.buttonAddEquation.UseVisualStyleBackColor = true;
			this.buttonAddEquation.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonCalc
			// 
			this.buttonCalc.Location = new System.Drawing.Point(796, 12);
			this.buttonCalc.Name = "buttonCalc";
			this.buttonCalc.Size = new System.Drawing.Size(75, 23);
			this.buttonCalc.TabIndex = 2;
			this.buttonCalc.Text = "Calc";
			this.buttonCalc.UseVisualStyleBackColor = true;
			this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
			// 
			// labelt0
			// 
			this.labelt0.AutoSize = true;
			this.labelt0.Location = new System.Drawing.Point(793, 63);
			this.labelt0.Name = "labelt0";
			this.labelt0.Size = new System.Drawing.Size(16, 13);
			this.labelt0.TabIndex = 3;
			this.labelt0.Text = "t0";
			// 
			// textBoxt0
			// 
			this.textBoxt0.Location = new System.Drawing.Point(836, 59);
			this.textBoxt0.Name = "textBoxt0";
			this.textBoxt0.Size = new System.Drawing.Size(35, 20);
			this.textBoxt0.TabIndex = 4;
			this.textBoxt0.Text = "0";
			// 
			// listBoxX
			// 
			this.listBoxX.FormattingEnabled = true;
			this.listBoxX.Location = new System.Drawing.Point(12, 429);
			this.listBoxX.Name = "listBoxX";
			this.listBoxX.Size = new System.Drawing.Size(120, 95);
			this.listBoxX.TabIndex = 5;
			// 
			// listBoxY
			// 
			this.listBoxY.FormattingEnabled = true;
			this.listBoxY.Location = new System.Drawing.Point(153, 429);
			this.listBoxY.Name = "listBoxY";
			this.listBoxY.Size = new System.Drawing.Size(120, 95);
			this.listBoxY.TabIndex = 6;
			// 
			// listBoxSystemName
			// 
			this.listBoxSystemName.FormattingEnabled = true;
			this.listBoxSystemName.Items.AddRange(new object[] {
            "Complex System Slides",
            "Logistic",
            "Harmonic oscillator",
            "Henon-Heilis"});
			this.listBoxSystemName.Location = new System.Drawing.Point(356, 429);
			this.listBoxSystemName.Name = "listBoxSystemName";
			this.listBoxSystemName.Size = new System.Drawing.Size(120, 95);
			this.listBoxSystemName.TabIndex = 7;
			this.listBoxSystemName.DoubleClick += new System.EventHandler(this.listBoxSystemName_DoubleClick);
			// 
			// labelParametersLabel
			// 
			this.labelParametersLabel.AutoSize = true;
			this.labelParametersLabel.Location = new System.Drawing.Point(936, 22);
			this.labelParametersLabel.Name = "labelParametersLabel";
			this.labelParametersLabel.Size = new System.Drawing.Size(60, 13);
			this.labelParametersLabel.TabIndex = 8;
			this.labelParametersLabel.Text = "Parameters";
			// 
			// labelA
			// 
			this.labelA.AutoSize = true;
			this.labelA.Location = new System.Drawing.Point(925, 53);
			this.labelA.Name = "labelA";
			this.labelA.Size = new System.Drawing.Size(14, 13);
			this.labelA.TabIndex = 9;
			this.labelA.Text = "A";
			// 
			// labelC
			// 
			this.labelC.AutoSize = true;
			this.labelC.Location = new System.Drawing.Point(925, 150);
			this.labelC.Name = "labelC";
			this.labelC.Size = new System.Drawing.Size(14, 13);
			this.labelC.TabIndex = 10;
			this.labelC.Text = "C";
			// 
			// labelD
			// 
			this.labelD.AutoSize = true;
			this.labelD.Location = new System.Drawing.Point(924, 201);
			this.labelD.Name = "labelD";
			this.labelD.Size = new System.Drawing.Size(15, 13);
			this.labelD.TabIndex = 11;
			this.labelD.Text = "D";
			// 
			// labelB
			// 
			this.labelB.AutoSize = true;
			this.labelB.Location = new System.Drawing.Point(923, 99);
			this.labelB.Name = "labelB";
			this.labelB.Size = new System.Drawing.Size(14, 13);
			this.labelB.TabIndex = 12;
			this.labelB.Text = "B";
			// 
			// labelE
			// 
			this.labelE.AutoSize = true;
			this.labelE.Location = new System.Drawing.Point(923, 252);
			this.labelE.Name = "labelE";
			this.labelE.Size = new System.Drawing.Size(14, 13);
			this.labelE.TabIndex = 13;
			this.labelE.Text = "E";
			// 
			// labelF
			// 
			this.labelF.AutoSize = true;
			this.labelF.Location = new System.Drawing.Point(924, 306);
			this.labelF.Name = "labelF";
			this.labelF.Size = new System.Drawing.Size(13, 13);
			this.labelF.TabIndex = 14;
			this.labelF.Text = "F";
			// 
			// trackBarA
			// 
			this.trackBarA.Location = new System.Drawing.Point(956, 53);
			this.trackBarA.Name = "trackBarA";
			this.trackBarA.Size = new System.Drawing.Size(104, 45);
			this.trackBarA.TabIndex = 15;
			this.trackBarA.Scroll += new System.EventHandler(this.trackBarParameter_Scroll);
			// 
			// trackBarB
			// 
			this.trackBarB.Location = new System.Drawing.Point(956, 99);
			this.trackBarB.Name = "trackBarB";
			this.trackBarB.Size = new System.Drawing.Size(104, 45);
			this.trackBarB.TabIndex = 16;
			// 
			// trackBarC
			// 
			this.trackBarC.Location = new System.Drawing.Point(956, 150);
			this.trackBarC.Name = "trackBarC";
			this.trackBarC.Size = new System.Drawing.Size(104, 45);
			this.trackBarC.TabIndex = 17;
			// 
			// trackBarD
			// 
			this.trackBarD.Location = new System.Drawing.Point(956, 201);
			this.trackBarD.Name = "trackBarD";
			this.trackBarD.Size = new System.Drawing.Size(104, 45);
			this.trackBarD.TabIndex = 18;
			// 
			// trackBarE
			// 
			this.trackBarE.Location = new System.Drawing.Point(956, 252);
			this.trackBarE.Name = "trackBarE";
			this.trackBarE.Size = new System.Drawing.Size(104, 45);
			this.trackBarE.TabIndex = 19;
			// 
			// trackBarF
			// 
			this.trackBarF.Location = new System.Drawing.Point(956, 306);
			this.trackBarF.Name = "trackBarF";
			this.trackBarF.Size = new System.Drawing.Size(104, 45);
			this.trackBarF.TabIndex = 20;
			// 
			// textBoxA
			// 
			this.textBoxA.Location = new System.Drawing.Point(1067, 55);
			this.textBoxA.Name = "textBoxA";
			this.textBoxA.Size = new System.Drawing.Size(33, 20);
			this.textBoxA.TabIndex = 21;
			// 
			// textBoxE
			// 
			this.textBoxE.Location = new System.Drawing.Point(1067, 252);
			this.textBoxE.Name = "textBoxE";
			this.textBoxE.Size = new System.Drawing.Size(33, 20);
			this.textBoxE.TabIndex = 22;
			// 
			// textBoxD
			// 
			this.textBoxD.Location = new System.Drawing.Point(1067, 201);
			this.textBoxD.Name = "textBoxD";
			this.textBoxD.Size = new System.Drawing.Size(33, 20);
			this.textBoxD.TabIndex = 23;
			// 
			// textBoxC
			// 
			this.textBoxC.Location = new System.Drawing.Point(1067, 150);
			this.textBoxC.Name = "textBoxC";
			this.textBoxC.Size = new System.Drawing.Size(33, 20);
			this.textBoxC.TabIndex = 24;
			// 
			// textBoxB
			// 
			this.textBoxB.Location = new System.Drawing.Point(1067, 99);
			this.textBoxB.Name = "textBoxB";
			this.textBoxB.Size = new System.Drawing.Size(33, 20);
			this.textBoxB.TabIndex = 25;
			// 
			// textBoxF
			// 
			this.textBoxF.Location = new System.Drawing.Point(1067, 306);
			this.textBoxF.Name = "textBoxF";
			this.textBoxF.Size = new System.Drawing.Size(33, 20);
			this.textBoxF.TabIndex = 26;
			// 
			// buttonA
			// 
			this.buttonA.Location = new System.Drawing.Point(1121, 52);
			this.buttonA.Name = "buttonA";
			this.buttonA.Size = new System.Drawing.Size(39, 23);
			this.buttonA.TabIndex = 27;
			this.buttonA.Text = "EditA";
			this.buttonA.UseVisualStyleBackColor = true;
			this.buttonA.Click += new System.EventHandler(this.buttonParameterEdit_Click);
			// 
			// buttonF
			// 
			this.buttonF.Location = new System.Drawing.Point(1121, 306);
			this.buttonF.Name = "buttonF";
			this.buttonF.Size = new System.Drawing.Size(39, 23);
			this.buttonF.TabIndex = 28;
			this.buttonF.Text = "Edit";
			this.buttonF.UseVisualStyleBackColor = true;
			this.buttonF.Click += new System.EventHandler(this.buttonParameterEdit_Click);
			// 
			// buttonE
			// 
			this.buttonE.Location = new System.Drawing.Point(1121, 252);
			this.buttonE.Name = "buttonE";
			this.buttonE.Size = new System.Drawing.Size(39, 23);
			this.buttonE.TabIndex = 31;
			this.buttonE.Text = "Edit";
			this.buttonE.UseVisualStyleBackColor = true;
			this.buttonE.Click += new System.EventHandler(this.buttonParameterEdit_Click);
			// 
			// buttonD
			// 
			this.buttonD.Location = new System.Drawing.Point(1121, 199);
			this.buttonD.Name = "buttonD";
			this.buttonD.Size = new System.Drawing.Size(39, 23);
			this.buttonD.TabIndex = 32;
			this.buttonD.Text = "Edit";
			this.buttonD.UseVisualStyleBackColor = true;
			this.buttonD.Click += new System.EventHandler(this.buttonParameterEdit_Click);
			// 
			// buttonC
			// 
			this.buttonC.Location = new System.Drawing.Point(1121, 148);
			this.buttonC.Name = "buttonC";
			this.buttonC.Size = new System.Drawing.Size(39, 23);
			this.buttonC.TabIndex = 33;
			this.buttonC.Text = "Edit";
			this.buttonC.UseVisualStyleBackColor = true;
			this.buttonC.Click += new System.EventHandler(this.buttonParameterEdit_Click);
			// 
			// buttonB
			// 
			this.buttonB.Location = new System.Drawing.Point(1121, 99);
			this.buttonB.Name = "buttonB";
			this.buttonB.Size = new System.Drawing.Size(39, 23);
			this.buttonB.TabIndex = 34;
			this.buttonB.Text = "EditB";
			this.buttonB.UseVisualStyleBackColor = true;
			this.buttonB.Click += new System.EventHandler(this.buttonParameterEdit_Click);
			// 
			// radioButtonRungeKutta4
			// 
			this.radioButtonRungeKutta4.AutoSize = true;
			this.radioButtonRungeKutta4.Location = new System.Drawing.Point(795, 127);
			this.radioButtonRungeKutta4.Name = "radioButtonRungeKutta4";
			this.radioButtonRungeKutta4.Size = new System.Drawing.Size(88, 17);
			this.radioButtonRungeKutta4.TabIndex = 35;
			this.radioButtonRungeKutta4.TabStop = true;
			this.radioButtonRungeKutta4.Text = "RungeKutta4";
			this.radioButtonRungeKutta4.UseVisualStyleBackColor = true;
			this.radioButtonRungeKutta4.CheckedChanged += new System.EventHandler(this.radioButtonRungeKutta4_CheckedChanged);
			// 
			// radioButtonEuler
			// 
			this.radioButtonEuler.AutoSize = true;
			this.radioButtonEuler.Checked = true;
			this.radioButtonEuler.Location = new System.Drawing.Point(796, 153);
			this.radioButtonEuler.Name = "radioButtonEuler";
			this.radioButtonEuler.Size = new System.Drawing.Size(49, 17);
			this.radioButtonEuler.TabIndex = 36;
			this.radioButtonEuler.TabStop = true;
			this.radioButtonEuler.Text = "Euler";
			this.radioButtonEuler.UseVisualStyleBackColor = true;
			this.radioButtonEuler.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// graphSystemBehavior1
			// 
			this.graphSystemBehavior1.axisXlabel = "x";
			this.graphSystemBehavior1.axisYlabel = "y";
			this.graphSystemBehavior1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graphSystemBehavior1.f0 = null;
			this.graphSystemBehavior1.functionsD = null;
			this.graphSystemBehavior1.graphHist = false;
			this.graphSystemBehavior1.IntegrationType = Mathematics.Intergration.IntegrationType.EulerMethod;
			this.graphSystemBehavior1.IsAxisVisible = true;
			this.graphSystemBehavior1.Location = new System.Drawing.Point(12, 12);
			this.graphSystemBehavior1.MoveButtonsExist = true;
			this.graphSystemBehavior1.Name = "graphSystemBehavior1";
			this.graphSystemBehavior1.scatterGraph = false;
			this.graphSystemBehavior1.Size = new System.Drawing.Size(464, 363);
			this.graphSystemBehavior1.t0 = 0D;
			this.graphSystemBehavior1.TabIndex = 0;
			this.graphSystemBehavior1.UseDynamicFunctions = false;
			this.graphSystemBehavior1.ZoomButtonsExist = true;
			// 
			// radioButtonEulerSymplectic
			// 
			this.radioButtonEulerSymplectic.AutoSize = true;
			this.radioButtonEulerSymplectic.Location = new System.Drawing.Point(796, 178);
			this.radioButtonEulerSymplectic.Name = "radioButtonEulerSymplectic";
			this.radioButtonEulerSymplectic.Size = new System.Drawing.Size(100, 17);
			this.radioButtonEulerSymplectic.TabIndex = 37;
			this.radioButtonEulerSymplectic.TabStop = true;
			this.radioButtonEulerSymplectic.Text = "EulerSymplectic";
			this.radioButtonEulerSymplectic.UseVisualStyleBackColor = true;
			this.radioButtonEulerSymplectic.CheckedChanged += new System.EventHandler(this.radioButtonEulerSymplectic_CheckedChanged);
			// 
			// FormDynamicEquations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1181, 599);
			this.Controls.Add(this.radioButtonEulerSymplectic);
			this.Controls.Add(this.radioButtonEuler);
			this.Controls.Add(this.radioButtonRungeKutta4);
			this.Controls.Add(this.buttonB);
			this.Controls.Add(this.buttonC);
			this.Controls.Add(this.buttonD);
			this.Controls.Add(this.buttonE);
			this.Controls.Add(this.buttonF);
			this.Controls.Add(this.buttonA);
			this.Controls.Add(this.textBoxF);
			this.Controls.Add(this.textBoxB);
			this.Controls.Add(this.textBoxC);
			this.Controls.Add(this.textBoxD);
			this.Controls.Add(this.textBoxE);
			this.Controls.Add(this.textBoxA);
			this.Controls.Add(this.trackBarF);
			this.Controls.Add(this.trackBarE);
			this.Controls.Add(this.trackBarD);
			this.Controls.Add(this.trackBarC);
			this.Controls.Add(this.trackBarB);
			this.Controls.Add(this.trackBarA);
			this.Controls.Add(this.labelF);
			this.Controls.Add(this.labelE);
			this.Controls.Add(this.labelB);
			this.Controls.Add(this.labelD);
			this.Controls.Add(this.labelC);
			this.Controls.Add(this.labelA);
			this.Controls.Add(this.labelParametersLabel);
			this.Controls.Add(this.listBoxSystemName);
			this.Controls.Add(this.listBoxY);
			this.Controls.Add(this.listBoxX);
			this.Controls.Add(this.textBoxt0);
			this.Controls.Add(this.labelt0);
			this.Controls.Add(this.buttonCalc);
			this.Controls.Add(this.buttonAddEquation);
			this.Controls.Add(this.graphSystemBehavior1);
			this.Name = "FormDynamicEquations";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.trackBarA)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarC)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarF)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Graph.GraphDynamicType graphSystemBehavior1;
		private System.Windows.Forms.Button buttonAddEquation;
		private System.Windows.Forms.Button buttonCalc;
		private System.Windows.Forms.Label labelt0;
		private System.Windows.Forms.TextBox textBoxt0;
		private System.Windows.Forms.ListBox listBoxX;
		private System.Windows.Forms.ListBox listBoxY;
		private System.Windows.Forms.ListBox listBoxSystemName;
		private System.Windows.Forms.Label labelParametersLabel;
		private System.Windows.Forms.Label labelA;
		private System.Windows.Forms.Label labelC;
		private System.Windows.Forms.Label labelD;
		private System.Windows.Forms.Label labelB;
		private System.Windows.Forms.Label labelE;
		private System.Windows.Forms.Label labelF;
		private System.Windows.Forms.TrackBar trackBarA;
		private System.Windows.Forms.TrackBar trackBarB;
		private System.Windows.Forms.TrackBar trackBarC;
		private System.Windows.Forms.TrackBar trackBarD;
		private System.Windows.Forms.TrackBar trackBarE;
		private System.Windows.Forms.TrackBar trackBarF;
		private System.Windows.Forms.TextBox textBoxA;
		private System.Windows.Forms.TextBox textBoxE;
		private System.Windows.Forms.TextBox textBoxD;
		private System.Windows.Forms.TextBox textBoxC;
		private System.Windows.Forms.TextBox textBoxB;
		private System.Windows.Forms.TextBox textBoxF;
		private System.Windows.Forms.Button buttonA;
		private System.Windows.Forms.Button buttonF;
		private System.Windows.Forms.Button buttonE;
		private System.Windows.Forms.Button buttonD;
		private System.Windows.Forms.Button buttonC;
		private System.Windows.Forms.Button buttonB;
		private System.Windows.Forms.RadioButton radioButtonRungeKutta4;
		private System.Windows.Forms.RadioButton radioButtonEuler;
		private System.Windows.Forms.RadioButton radioButtonEulerSymplectic;
	}
}

