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
			this.radioButtonDormandPrince = new System.Windows.Forms.RadioButton();
			this.textBoxHamiltonian = new System.Windows.Forms.TextBox();
			this.labelHamiltonian = new System.Windows.Forms.Label();
			this.buttonHamiltonian = new System.Windows.Forms.Button();
			this.buttonLyapunov = new System.Windows.Forms.Button();
			this.radioButtonIterativ = new System.Windows.Forms.RadioButton();
			this.buttonRedrawAxes = new System.Windows.Forms.Button();
			this.checkBoxPoincare = new System.Windows.Forms.CheckBox();
			this.textBoxThicknessOfLayer = new System.Windows.Forms.TextBox();
			this.comboBoxVarForPoincare = new System.Windows.Forms.ComboBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBoxHDet = new System.Windows.Forms.CheckBox();
			this.textBoxH = new System.Windows.Forms.TextBox();
			this.labelH = new System.Windows.Forms.Label();
			this.labelVarEquation = new System.Windows.Forms.Label();
			this.labelHDeterminingVariable = new System.Windows.Forms.Label();
			this.textBoxVarEquation = new System.Windows.Forms.TextBox();
			this.comboBoxVarForDetH = new System.Windows.Forms.ComboBox();
			this.labelSectionPoint = new System.Windows.Forms.Label();
			this.textBoxSectionPoint = new System.Windows.Forms.TextBox();
			this.textBoxHitCount = new System.Windows.Forms.TextBox();
			this.labelHitCount = new System.Windows.Forms.Label();
			this.labelThickness = new System.Windows.Forms.Label();
			this.labelVar = new System.Windows.Forms.Label();
			this.graphSystemBehavior1 = new Graph.GraphDynamicType();
			((System.ComponentModel.ISupportInitialize)(this.trackBarA)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarC)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarF)).BeginInit();
			this.panel1.SuspendLayout();
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
            "WikipediaRungeSample",
            "Harmonic oscillator",
            "Henon-Heilis",
            "Lorenz Equation",
            "Henon Map"});
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
			this.trackBarA.LargeChange = 2000;
			this.trackBarA.Location = new System.Drawing.Point(956, 53);
			this.trackBarA.Maximum = 50000;
			this.trackBarA.Minimum = -50000;
			this.trackBarA.Name = "trackBarA";
			this.trackBarA.Size = new System.Drawing.Size(104, 45);
			this.trackBarA.SmallChange = 1000;
			this.trackBarA.TabIndex = 15;
			this.trackBarA.TickFrequency = 2000;
			this.trackBarA.Scroll += new System.EventHandler(this.trackBarParameter_Scroll);
			// 
			// trackBarB
			// 
			this.trackBarB.LargeChange = 2000;
			this.trackBarB.Location = new System.Drawing.Point(956, 99);
			this.trackBarB.Maximum = 50000;
			this.trackBarB.Minimum = -50000;
			this.trackBarB.Name = "trackBarB";
			this.trackBarB.Size = new System.Drawing.Size(104, 45);
			this.trackBarB.SmallChange = 1000;
			this.trackBarB.TabIndex = 16;
			this.trackBarB.TickFrequency = 2000;
			this.trackBarB.Scroll += new System.EventHandler(this.trackBarParameter_Scroll);
			// 
			// trackBarC
			// 
			this.trackBarC.LargeChange = 2000;
			this.trackBarC.Location = new System.Drawing.Point(956, 150);
			this.trackBarC.Maximum = 50000;
			this.trackBarC.Minimum = -50000;
			this.trackBarC.Name = "trackBarC";
			this.trackBarC.Size = new System.Drawing.Size(104, 45);
			this.trackBarC.SmallChange = 1000;
			this.trackBarC.TabIndex = 17;
			this.trackBarC.TickFrequency = 2000;
			this.trackBarC.Scroll += new System.EventHandler(this.trackBarParameter_Scroll);
			// 
			// trackBarD
			// 
			this.trackBarD.LargeChange = 2000;
			this.trackBarD.Location = new System.Drawing.Point(956, 201);
			this.trackBarD.Maximum = 50000;
			this.trackBarD.Minimum = -50000;
			this.trackBarD.Name = "trackBarD";
			this.trackBarD.Size = new System.Drawing.Size(104, 45);
			this.trackBarD.SmallChange = 1000;
			this.trackBarD.TabIndex = 18;
			this.trackBarD.TickFrequency = 2000;
			this.trackBarD.Scroll += new System.EventHandler(this.trackBarParameter_Scroll);
			// 
			// trackBarE
			// 
			this.trackBarE.LargeChange = 2000;
			this.trackBarE.Location = new System.Drawing.Point(956, 252);
			this.trackBarE.Maximum = 50000;
			this.trackBarE.Minimum = -50000;
			this.trackBarE.Name = "trackBarE";
			this.trackBarE.Size = new System.Drawing.Size(104, 45);
			this.trackBarE.SmallChange = 1000;
			this.trackBarE.TabIndex = 19;
			this.trackBarE.TickFrequency = 2000;
			this.trackBarE.Scroll += new System.EventHandler(this.trackBarParameter_Scroll);
			// 
			// trackBarF
			// 
			this.trackBarF.LargeChange = 2000;
			this.trackBarF.Location = new System.Drawing.Point(956, 306);
			this.trackBarF.Maximum = 50000;
			this.trackBarF.Minimum = -50000;
			this.trackBarF.Name = "trackBarF";
			this.trackBarF.Size = new System.Drawing.Size(104, 45);
			this.trackBarF.SmallChange = 1000;
			this.trackBarF.TabIndex = 20;
			this.trackBarF.TickFrequency = 2000;
			this.trackBarF.Scroll += new System.EventHandler(this.trackBarParameter_Scroll);
			// 
			// textBoxA
			// 
			this.textBoxA.Location = new System.Drawing.Point(1067, 55);
			this.textBoxA.Name = "textBoxA";
			this.textBoxA.Size = new System.Drawing.Size(48, 20);
			this.textBoxA.TabIndex = 21;
			this.textBoxA.Text = "0";
			// 
			// textBoxE
			// 
			this.textBoxE.Location = new System.Drawing.Point(1067, 252);
			this.textBoxE.Name = "textBoxE";
			this.textBoxE.Size = new System.Drawing.Size(48, 20);
			this.textBoxE.TabIndex = 22;
			this.textBoxE.Text = "0";
			// 
			// textBoxD
			// 
			this.textBoxD.Location = new System.Drawing.Point(1067, 201);
			this.textBoxD.Name = "textBoxD";
			this.textBoxD.Size = new System.Drawing.Size(48, 20);
			this.textBoxD.TabIndex = 23;
			this.textBoxD.Text = "0";
			// 
			// textBoxC
			// 
			this.textBoxC.Location = new System.Drawing.Point(1067, 150);
			this.textBoxC.Name = "textBoxC";
			this.textBoxC.Size = new System.Drawing.Size(48, 20);
			this.textBoxC.TabIndex = 24;
			this.textBoxC.Text = "0";
			// 
			// textBoxB
			// 
			this.textBoxB.Location = new System.Drawing.Point(1067, 99);
			this.textBoxB.Name = "textBoxB";
			this.textBoxB.Size = new System.Drawing.Size(48, 20);
			this.textBoxB.TabIndex = 25;
			this.textBoxB.Text = "0";
			// 
			// textBoxF
			// 
			this.textBoxF.Location = new System.Drawing.Point(1067, 306);
			this.textBoxF.Name = "textBoxF";
			this.textBoxF.Size = new System.Drawing.Size(48, 20);
			this.textBoxF.TabIndex = 26;
			this.textBoxF.Text = "0";
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
			// radioButtonDormandPrince
			// 
			this.radioButtonDormandPrince.AutoSize = true;
			this.radioButtonDormandPrince.Location = new System.Drawing.Point(796, 178);
			this.radioButtonDormandPrince.Name = "radioButtonDormandPrince";
			this.radioButtonDormandPrince.Size = new System.Drawing.Size(98, 17);
			this.radioButtonDormandPrince.TabIndex = 37;
			this.radioButtonDormandPrince.Text = "DormandPrince";
			this.radioButtonDormandPrince.UseVisualStyleBackColor = true;
			this.radioButtonDormandPrince.CheckedChanged += new System.EventHandler ( this.radioButtonDormandPrince_CheckedChanged );
			// 
			// textBoxHamiltonian
			// 
			this.textBoxHamiltonian.Location = new System.Drawing.Point(796, 388);
			this.textBoxHamiltonian.Name = "textBoxHamiltonian";
			this.textBoxHamiltonian.Size = new System.Drawing.Size(292, 20);
			this.textBoxHamiltonian.TabIndex = 38;
			this.textBoxHamiltonian.Text = "(px*px+py*py)/2+(x*x+y*y)+x*x*y-y*y*y";
			// 
			// labelHamiltonian
			// 
			this.labelHamiltonian.AutoSize = true;
			this.labelHamiltonian.Location = new System.Drawing.Point(793, 362);
			this.labelHamiltonian.Name = "labelHamiltonian";
			this.labelHamiltonian.Size = new System.Drawing.Size(62, 13);
			this.labelHamiltonian.TabIndex = 39;
			this.labelHamiltonian.Text = "Hamiltonian";
			// 
			// buttonHamiltonian
			// 
			this.buttonHamiltonian.Location = new System.Drawing.Point(1094, 385);
			this.buttonHamiltonian.Name = "buttonHamiltonian";
			this.buttonHamiltonian.Size = new System.Drawing.Size(75, 23);
			this.buttonHamiltonian.TabIndex = 40;
			this.buttonHamiltonian.Text = "show";
			this.buttonHamiltonian.UseVisualStyleBackColor = true;
			this.buttonHamiltonian.Click += new System.EventHandler(this.buttonHamiltonian_Click);
			// 
			// buttonLyapunov
			// 
			this.buttonLyapunov.Location = new System.Drawing.Point(792, 429);
			this.buttonLyapunov.Name = "buttonLyapunov";
			this.buttonLyapunov.Size = new System.Drawing.Size(124, 23);
			this.buttonLyapunov.TabIndex = 41;
			this.buttonLyapunov.Text = "Lyapunov Spectrum";
			this.buttonLyapunov.UseVisualStyleBackColor = true;
			this.buttonLyapunov.Click += new System.EventHandler(this.buttonLyapunov_Click);
			// 
			// radioButtonIterativ
			// 
			this.radioButtonIterativ.AutoSize = true;
			this.radioButtonIterativ.Location = new System.Drawing.Point(796, 205);
			this.radioButtonIterativ.Name = "radioButtonIterativ";
			this.radioButtonIterativ.Size = new System.Drawing.Size(57, 17);
			this.radioButtonIterativ.TabIndex = 42;
			this.radioButtonIterativ.TabStop = true;
			this.radioButtonIterativ.Text = "Iterativ";
			this.radioButtonIterativ.UseVisualStyleBackColor = true;
			this.radioButtonIterativ.CheckedChanged += new System.EventHandler(this.radioButtonIterativ_CheckedChanged);
			// 
			// buttonRedrawAxes
			// 
			this.buttonRedrawAxes.Location = new System.Drawing.Point(198, 530);
			this.buttonRedrawAxes.Name = "buttonRedrawAxes";
			this.buttonRedrawAxes.Size = new System.Drawing.Size(75, 23);
			this.buttonRedrawAxes.TabIndex = 43;
			this.buttonRedrawAxes.Text = "Redraw Axes";
			this.buttonRedrawAxes.UseVisualStyleBackColor = true;
			this.buttonRedrawAxes.Click += new System.EventHandler(this.buttonRedrawAxes_Click);
			// 
			// checkBoxPoincare
			// 
			this.checkBoxPoincare.AutoSize = true;
			this.checkBoxPoincare.Checked = true;
			this.checkBoxPoincare.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxPoincare.Location = new System.Drawing.Point(19, 12);
			this.checkBoxPoincare.Name = "checkBoxPoincare";
			this.checkBoxPoincare.Size = new System.Drawing.Size(105, 17);
			this.checkBoxPoincare.TabIndex = 44;
			this.checkBoxPoincare.Text = "Poincare section";
			this.checkBoxPoincare.UseVisualStyleBackColor = true;
			this.checkBoxPoincare.CheckedChanged += new System.EventHandler(this.checkBoxPoincare_CheckedChanged);
			// 
			// textBoxThicknessOfLayer
			// 
			this.textBoxThicknessOfLayer.Location = new System.Drawing.Point(122, 75);
			this.textBoxThicknessOfLayer.Name = "textBoxThicknessOfLayer";
			this.textBoxThicknessOfLayer.Size = new System.Drawing.Size(121, 20);
			this.textBoxThicknessOfLayer.TabIndex = 45;
			this.textBoxThicknessOfLayer.Text = "0.005";
			// 
			// comboBoxVarForPoincare
			// 
			this.comboBoxVarForPoincare.FormattingEnabled = true;
			this.comboBoxVarForPoincare.Location = new System.Drawing.Point(122, 45);
			this.comboBoxVarForPoincare.Name = "comboBoxVarForPoincare";
			this.comboBoxVarForPoincare.Size = new System.Drawing.Size(121, 21);
			this.comboBoxVarForPoincare.TabIndex = 46;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(0, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 755);
			this.splitter1.TabIndex = 47;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel1.Controls.Add(this.checkBoxHDet);
			this.panel1.Controls.Add(this.textBoxH);
			this.panel1.Controls.Add(this.labelH);
			this.panel1.Controls.Add(this.labelVarEquation);
			this.panel1.Controls.Add(this.labelHDeterminingVariable);
			this.panel1.Controls.Add(this.textBoxVarEquation);
			this.panel1.Controls.Add(this.comboBoxVarForDetH);
			this.panel1.Controls.Add(this.labelSectionPoint);
			this.panel1.Controls.Add(this.textBoxSectionPoint);
			this.panel1.Controls.Add(this.textBoxHitCount);
			this.panel1.Controls.Add(this.labelHitCount);
			this.panel1.Controls.Add(this.labelThickness);
			this.panel1.Controls.Add(this.labelVar);
			this.panel1.Controls.Add(this.checkBoxPoincare);
			this.panel1.Controls.Add(this.textBoxThicknessOfLayer);
			this.panel1.Controls.Add(this.comboBoxVarForPoincare);
			this.panel1.Location = new System.Drawing.Point(792, 458);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(323, 297);
			this.panel1.TabIndex = 48;
			// 
			// checkBoxHDet
			// 
			this.checkBoxHDet.AutoSize = true;
			this.checkBoxHDet.Checked = true;
			this.checkBoxHDet.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxHDet.Location = new System.Drawing.Point(262, 183);
			this.checkBoxHDet.Name = "checkBoxHDet";
			this.checkBoxHDet.Size = new System.Drawing.Size(35, 17);
			this.checkBoxHDet.TabIndex = 59;
			this.checkBoxHDet.Text = "<-";
			this.checkBoxHDet.UseVisualStyleBackColor = true;
			this.checkBoxHDet.CheckedChanged += new System.EventHandler(this.checkBoxHDet_CheckedChanged);
			// 
			// textBoxH
			// 
			this.textBoxH.Location = new System.Drawing.Point(122, 217);
			this.textBoxH.Name = "textBoxH";
			this.textBoxH.Size = new System.Drawing.Size(121, 20);
			this.textBoxH.TabIndex = 58;
			this.textBoxH.Text = "1/8";
			// 
			// labelH
			// 
			this.labelH.AutoSize = true;
			this.labelH.Location = new System.Drawing.Point(29, 220);
			this.labelH.Name = "labelH";
			this.labelH.Size = new System.Drawing.Size(21, 13);
			this.labelH.TabIndex = 57;
			this.labelH.Text = "H=";
			// 
			// labelVarEquation
			// 
			this.labelVarEquation.AutoSize = true;
			this.labelVarEquation.Location = new System.Drawing.Point(3, 253);
			this.labelVarEquation.Name = "labelVarEquation";
			this.labelVarEquation.Size = new System.Drawing.Size(13, 13);
			this.labelVarEquation.TabIndex = 56;
			this.labelVarEquation.Text = "=";
			// 
			// labelHDeterminingVariable
			// 
			this.labelHDeterminingVariable.AutoSize = true;
			this.labelHDeterminingVariable.Location = new System.Drawing.Point(29, 183);
			this.labelHDeterminingVariable.Name = "labelHDeterminingVariable";
			this.labelHDeterminingVariable.Size = new System.Drawing.Size(67, 13);
			this.labelHDeterminingVariable.TabIndex = 55;
			this.labelHDeterminingVariable.Text = "Var for det H";
			// 
			// textBoxVarEquation
			// 
			this.textBoxVarEquation.Location = new System.Drawing.Point(30, 250);
			this.textBoxVarEquation.Name = "textBoxVarEquation";
			this.textBoxVarEquation.Size = new System.Drawing.Size(290, 20);
			this.textBoxVarEquation.TabIndex = 54;
			this.textBoxVarEquation.Text = "Math.Sqrt(H-(py*py/2+(x*x+y*y)/2+x*x*y-y*y*y))";
			// 
			// comboBoxVarForDetH
			// 
			this.comboBoxVarForDetH.FormattingEnabled = true;
			this.comboBoxVarForDetH.Location = new System.Drawing.Point(122, 180);
			this.comboBoxVarForDetH.Name = "comboBoxVarForDetH";
			this.comboBoxVarForDetH.Size = new System.Drawing.Size(121, 21);
			this.comboBoxVarForDetH.TabIndex = 53;
			// 
			// labelSectionPoint
			// 
			this.labelSectionPoint.AutoSize = true;
			this.labelSectionPoint.Location = new System.Drawing.Point(29, 146);
			this.labelSectionPoint.Name = "labelSectionPoint";
			this.labelSectionPoint.Size = new System.Drawing.Size(83, 13);
			this.labelSectionPoint.TabIndex = 52;
			this.labelSectionPoint.Text = "Point for section";
			// 
			// textBoxSectionPoint
			// 
			this.textBoxSectionPoint.Location = new System.Drawing.Point(122, 143);
			this.textBoxSectionPoint.Name = "textBoxSectionPoint";
			this.textBoxSectionPoint.Size = new System.Drawing.Size(121, 20);
			this.textBoxSectionPoint.TabIndex = 51;
			this.textBoxSectionPoint.Text = "0";
			// 
			// textBoxHitCount
			// 
			this.textBoxHitCount.Location = new System.Drawing.Point(122, 108);
			this.textBoxHitCount.Name = "textBoxHitCount";
			this.textBoxHitCount.Size = new System.Drawing.Size(121, 20);
			this.textBoxHitCount.TabIndex = 50;
			this.textBoxHitCount.Text = "1000";
			// 
			// labelHitCount
			// 
			this.labelHitCount.AutoSize = true;
			this.labelHitCount.Location = new System.Drawing.Point(29, 111);
			this.labelHitCount.Name = "labelHitCount";
			this.labelHitCount.Size = new System.Drawing.Size(50, 13);
			this.labelHitCount.TabIndex = 49;
			this.labelHitCount.Text = "Hit count";
			// 
			// labelThickness
			// 
			this.labelThickness.AutoSize = true;
			this.labelThickness.Location = new System.Drawing.Point(29, 78);
			this.labelThickness.Name = "labelThickness";
			this.labelThickness.Size = new System.Drawing.Size(56, 13);
			this.labelThickness.TabIndex = 48;
			this.labelThickness.Text = "Thickness";
			// 
			// labelVar
			// 
			this.labelVar.AutoSize = true;
			this.labelVar.Location = new System.Drawing.Point(29, 48);
			this.labelVar.Name = "labelVar";
			this.labelVar.Size = new System.Drawing.Size(45, 13);
			this.labelVar.TabIndex = 47;
			this.labelVar.Text = "Variable";
			// 
			// graphSystemBehavior1
			// 
			this.graphSystemBehavior1.AxisXlabel = "x";
			this.graphSystemBehavior1.AxisYlabel = "y";
			this.graphSystemBehavior1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graphSystemBehavior1.f0 = null;
			this.graphSystemBehavior1.functionsD = null;
			this.graphSystemBehavior1.GraphHist = false;
			this.graphSystemBehavior1.IntegrationType = Mathematics.Intergration.IntegrationType.EulerMethod;
			this.graphSystemBehavior1.IsAxisVisible = true;
			this.graphSystemBehavior1.Location = new System.Drawing.Point(12, 12);
			this.graphSystemBehavior1.MoveButtonsExist = true;
			this.graphSystemBehavior1.Name = "graphSystemBehavior1";
			this.graphSystemBehavior1.Parameters = null;
			this.graphSystemBehavior1.PoincareParameters = null;
			this.graphSystemBehavior1.Scatter = false;
			this.graphSystemBehavior1.Size = new System.Drawing.Size(464, 363);
			this.graphSystemBehavior1.Solutions = null;
			this.graphSystemBehavior1.t0 = 0D;
			this.graphSystemBehavior1.TabIndex = 0;
			this.graphSystemBehavior1.UseDynamicFunctions = false;
			this.graphSystemBehavior1.ZoomButtonsExist = true;
			// 
			// FormDynamicEquations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1181, 755);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.buttonRedrawAxes);
			this.Controls.Add(this.radioButtonIterativ);
			this.Controls.Add(this.buttonLyapunov);
			this.Controls.Add(this.buttonHamiltonian);
			this.Controls.Add(this.labelHamiltonian);
			this.Controls.Add(this.textBoxHamiltonian);
			this.Controls.Add(this.radioButtonDormandPrince);
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
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
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
		private System.Windows.Forms.RadioButton radioButtonDormandPrince;
		private System.Windows.Forms.TextBox textBoxHamiltonian;
		private System.Windows.Forms.Label labelHamiltonian;
		private System.Windows.Forms.Button buttonHamiltonian;
		private System.Windows.Forms.Button buttonLyapunov;
		private System.Windows.Forms.RadioButton radioButtonIterativ;
		private System.Windows.Forms.Button buttonRedrawAxes;
		private System.Windows.Forms.CheckBox checkBoxPoincare;
		private System.Windows.Forms.TextBox textBoxThicknessOfLayer;
		private System.Windows.Forms.ComboBox comboBoxVarForPoincare;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelHitCount;
		private System.Windows.Forms.Label labelThickness;
		private System.Windows.Forms.Label labelVar;
		private System.Windows.Forms.TextBox textBoxHitCount;
		private System.Windows.Forms.Label labelSectionPoint;
		private System.Windows.Forms.TextBox textBoxSectionPoint;
		private System.Windows.Forms.CheckBox checkBoxHDet;
		private System.Windows.Forms.TextBox textBoxH;
		private System.Windows.Forms.Label labelH;
		private System.Windows.Forms.Label labelVarEquation;
		private System.Windows.Forms.Label labelHDeterminingVariable;
		private System.Windows.Forms.TextBox textBoxVarEquation;
		private System.Windows.Forms.ComboBox comboBoxVarForDetH;
	}
}

