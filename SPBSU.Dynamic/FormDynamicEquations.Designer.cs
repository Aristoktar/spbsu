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
			this.textBoxA = new System.Windows.Forms.TextBox();
			this.textBoxE = new System.Windows.Forms.TextBox();
			this.textBoxD = new System.Windows.Forms.TextBox();
			this.textBoxC = new System.Windows.Forms.TextBox();
			this.textBoxB = new System.Windows.Forms.TextBox();
			this.textBoxF = new System.Windows.Forms.TextBox();
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
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
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
			this.checkBoxAnimate = new System.Windows.Forms.CheckBox();
			this.textBoxAnimatePeriod = new System.Windows.Forms.TextBox();
			this.buttonGif = new System.Windows.Forms.Button();
			this.radioButtonEulerSymplectic = new System.Windows.Forms.RadioButton();
			this.tabControlIntegrationParameters = new System.Windows.Forms.TabControl();
			this.tabPagePoincare = new System.Windows.Forms.TabPage();
			this.tabPageBasic = new System.Windows.Forms.TabPage();
			this.checkBoxDirectionRight = new System.Windows.Forms.CheckBox();
			this.checkBoxDirectionLeft = new System.Windows.Forms.CheckBox();
			this.labelDirection = new System.Windows.Forms.Label();
			this.textBoxStep = new System.Windows.Forms.TextBox();
			this.textBoxError = new System.Windows.Forms.TextBox();
			this.radioButtonStep = new System.Windows.Forms.RadioButton();
			this.radioButtonError = new System.Windows.Forms.RadioButton();
			this.labelIterations = new System.Windows.Forms.Label();
			this.textBoxIterations = new System.Windows.Forms.TextBox();
			this.groupBoxCalculationsResult = new System.Windows.Forms.GroupBox();
			this.labelFunctionsInvocationsCountResult = new System.Windows.Forms.Label();
			this.labelFunctionsInvocationsCount = new System.Windows.Forms.Label();
			this.labelIterationsCountResult = new System.Windows.Forms.Label();
			this.labelTimeElapsedResult = new System.Windows.Forms.Label();
			this.labelIterationsCount = new System.Windows.Forms.Label();
			this.labelTimeElapsed = new System.Windows.Forms.Label();
			this.radioButtonHeuns = new System.Windows.Forms.RadioButton();
			this.radioButtonEulerImplicit = new System.Windows.Forms.RadioButton();
			this.buttonSaveSystem = new System.Windows.Forms.Button();
			this.buttonFullScreen = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.checkBoxSavePastValues = new System.Windows.Forms.CheckBox();
			this.buttonColor = new System.Windows.Forms.Button();
			this.graphSystemBehavior1 = new Graph.GraphDynamicType();
			this.buttonSetOfInitials = new System.Windows.Forms.Button();
			this.buttonCalcSet = new System.Windows.Forms.Button();
			this.checkBoxTime = new System.Windows.Forms.CheckBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.buttonSaveData = new System.Windows.Forms.Button();
			this.buttonLoadData = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.tabControlIntegrationParameters.SuspendLayout();
			this.tabPagePoincare.SuspendLayout();
			this.tabPageBasic.SuspendLayout();
			this.groupBoxCalculationsResult.SuspendLayout();
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
			this.labelt0.Location = new System.Drawing.Point(793, 44);
			this.labelt0.Name = "labelt0";
			this.labelt0.Size = new System.Drawing.Size(16, 13);
			this.labelt0.TabIndex = 3;
			this.labelt0.Text = "t0";
			// 
			// textBoxt0
			// 
			this.textBoxt0.Location = new System.Drawing.Point(836, 41);
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
            "Harmonic oscillator",
            "Henon-Heiles",
            "Lorenz Equation",
            "Lotka–Volterra"});
			this.listBoxSystemName.Location = new System.Drawing.Point(356, 429);
			this.listBoxSystemName.Name = "listBoxSystemName";
			this.listBoxSystemName.Size = new System.Drawing.Size(120, 95);
			this.listBoxSystemName.TabIndex = 7;
			this.listBoxSystemName.DoubleClick += new System.EventHandler(this.listBoxSystemName_DoubleClick);
			// 
			// labelParametersLabel
			// 
			this.labelParametersLabel.AutoSize = true;
			this.labelParametersLabel.Location = new System.Drawing.Point(801, 130);
			this.labelParametersLabel.Name = "labelParametersLabel";
			this.labelParametersLabel.Size = new System.Drawing.Size(60, 13);
			this.labelParametersLabel.TabIndex = 8;
			this.labelParametersLabel.Text = "Parameters";
			// 
			// labelA
			// 
			this.labelA.AutoSize = true;
			this.labelA.Location = new System.Drawing.Point(790, 161);
			this.labelA.Name = "labelA";
			this.labelA.Size = new System.Drawing.Size(14, 13);
			this.labelA.TabIndex = 9;
			this.labelA.Text = "A";
			// 
			// labelC
			// 
			this.labelC.AutoSize = true;
			this.labelC.Location = new System.Drawing.Point(788, 215);
			this.labelC.Name = "labelC";
			this.labelC.Size = new System.Drawing.Size(14, 13);
			this.labelC.TabIndex = 10;
			this.labelC.Text = "C";
			// 
			// labelD
			// 
			this.labelD.AutoSize = true;
			this.labelD.Location = new System.Drawing.Point(790, 241);
			this.labelD.Name = "labelD";
			this.labelD.Size = new System.Drawing.Size(15, 13);
			this.labelD.TabIndex = 11;
			this.labelD.Text = "D";
			// 
			// labelB
			// 
			this.labelB.AutoSize = true;
			this.labelB.Location = new System.Drawing.Point(790, 189);
			this.labelB.Name = "labelB";
			this.labelB.Size = new System.Drawing.Size(14, 13);
			this.labelB.TabIndex = 12;
			this.labelB.Text = "B";
			// 
			// labelE
			// 
			this.labelE.AutoSize = true;
			this.labelE.Location = new System.Drawing.Point(788, 267);
			this.labelE.Name = "labelE";
			this.labelE.Size = new System.Drawing.Size(14, 13);
			this.labelE.TabIndex = 13;
			this.labelE.Text = "E";
			// 
			// labelF
			// 
			this.labelF.AutoSize = true;
			this.labelF.Location = new System.Drawing.Point(789, 293);
			this.labelF.Name = "labelF";
			this.labelF.Size = new System.Drawing.Size(13, 13);
			this.labelF.TabIndex = 14;
			this.labelF.Text = "F";
			// 
			// textBoxA
			// 
			this.textBoxA.Location = new System.Drawing.Point(823, 158);
			this.textBoxA.Name = "textBoxA";
			this.textBoxA.Size = new System.Drawing.Size(48, 20);
			this.textBoxA.TabIndex = 21;
			this.textBoxA.Text = "0";
			// 
			// textBoxE
			// 
			this.textBoxE.Location = new System.Drawing.Point(823, 264);
			this.textBoxE.Name = "textBoxE";
			this.textBoxE.Size = new System.Drawing.Size(48, 20);
			this.textBoxE.TabIndex = 22;
			this.textBoxE.Text = "0";
			// 
			// textBoxD
			// 
			this.textBoxD.Location = new System.Drawing.Point(823, 238);
			this.textBoxD.Name = "textBoxD";
			this.textBoxD.Size = new System.Drawing.Size(48, 20);
			this.textBoxD.TabIndex = 23;
			this.textBoxD.Text = "0";
			// 
			// textBoxC
			// 
			this.textBoxC.Location = new System.Drawing.Point(823, 212);
			this.textBoxC.Name = "textBoxC";
			this.textBoxC.Size = new System.Drawing.Size(48, 20);
			this.textBoxC.TabIndex = 24;
			this.textBoxC.Text = "0";
			// 
			// textBoxB
			// 
			this.textBoxB.Location = new System.Drawing.Point(823, 186);
			this.textBoxB.Name = "textBoxB";
			this.textBoxB.Size = new System.Drawing.Size(48, 20);
			this.textBoxB.TabIndex = 25;
			this.textBoxB.Text = "0";
			// 
			// textBoxF
			// 
			this.textBoxF.Location = new System.Drawing.Point(823, 290);
			this.textBoxF.Name = "textBoxF";
			this.textBoxF.Size = new System.Drawing.Size(48, 20);
			this.textBoxF.TabIndex = 26;
			this.textBoxF.Text = "0";
			// 
			// radioButtonRungeKutta4
			// 
			this.radioButtonRungeKutta4.AutoSize = true;
			this.radioButtonRungeKutta4.Checked = true;
			this.radioButtonRungeKutta4.Location = new System.Drawing.Point(1240, 18);
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
			this.radioButtonEuler.Location = new System.Drawing.Point(1240, 60);
			this.radioButtonEuler.Name = "radioButtonEuler";
			this.radioButtonEuler.Size = new System.Drawing.Size(49, 17);
			this.radioButtonEuler.TabIndex = 36;
			this.radioButtonEuler.Text = "Euler";
			this.radioButtonEuler.UseVisualStyleBackColor = true;
			this.radioButtonEuler.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButtonDormandPrince
			// 
			this.radioButtonDormandPrince.AutoSize = true;
			this.radioButtonDormandPrince.Location = new System.Drawing.Point(1240, 128);
			this.radioButtonDormandPrince.Name = "radioButtonDormandPrince";
			this.radioButtonDormandPrince.Size = new System.Drawing.Size(98, 17);
			this.radioButtonDormandPrince.TabIndex = 37;
			this.radioButtonDormandPrince.Text = "DormandPrince";
			this.radioButtonDormandPrince.UseVisualStyleBackColor = true;
			this.radioButtonDormandPrince.CheckedChanged += new System.EventHandler(this.radioButtonDormandPrince_CheckedChanged);
			// 
			// textBoxHamiltonian
			// 
			this.textBoxHamiltonian.Location = new System.Drawing.Point(498, 454);
			this.textBoxHamiltonian.Name = "textBoxHamiltonian";
			this.textBoxHamiltonian.Size = new System.Drawing.Size(292, 20);
			this.textBoxHamiltonian.TabIndex = 38;
			this.textBoxHamiltonian.Text = "(px*px+py*py)/2+(x*x+y*y)+x*x*y-y*y*y";
			// 
			// labelHamiltonian
			// 
			this.labelHamiltonian.AutoSize = true;
			this.labelHamiltonian.Location = new System.Drawing.Point(495, 428);
			this.labelHamiltonian.Name = "labelHamiltonian";
			this.labelHamiltonian.Size = new System.Drawing.Size(62, 13);
			this.labelHamiltonian.TabIndex = 39;
			this.labelHamiltonian.Text = "Hamiltonian";
			// 
			// buttonHamiltonian
			// 
			this.buttonHamiltonian.Location = new System.Drawing.Point(796, 451);
			this.buttonHamiltonian.Name = "buttonHamiltonian";
			this.buttonHamiltonian.Size = new System.Drawing.Size(75, 23);
			this.buttonHamiltonian.TabIndex = 40;
			this.buttonHamiltonian.Text = "show";
			this.buttonHamiltonian.UseVisualStyleBackColor = true;
			this.buttonHamiltonian.Click += new System.EventHandler(this.buttonHamiltonian_Click);
			// 
			// buttonLyapunov
			// 
			this.buttonLyapunov.Location = new System.Drawing.Point(494, 495);
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
			this.radioButtonIterativ.Enabled = false;
			this.radioButtonIterativ.Location = new System.Drawing.Point(1240, 151);
			this.radioButtonIterativ.Name = "radioButtonIterativ";
			this.radioButtonIterativ.Size = new System.Drawing.Size(57, 17);
			this.radioButtonIterativ.TabIndex = 42;
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
			this.splitter1.Size = new System.Drawing.Size(3, 724);
			this.splitter1.TabIndex = 47;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel1.Controls.Add(this.checkBoxTime);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
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
			this.panel1.Location = new System.Drawing.Point(6, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(323, 318);
			this.panel1.TabIndex = 48;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(39, 290);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 61;
			this.label3.Text = "label3";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 290);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(13, 13);
			this.label2.TabIndex = 60;
			this.label2.Text = "=";
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
			// checkBoxAnimate
			// 
			this.checkBoxAnimate.AutoSize = true;
			this.checkBoxAnimate.Location = new System.Drawing.Point(12, 391);
			this.checkBoxAnimate.Name = "checkBoxAnimate";
			this.checkBoxAnimate.Size = new System.Drawing.Size(64, 17);
			this.checkBoxAnimate.TabIndex = 49;
			this.checkBoxAnimate.Text = "Animate";
			this.checkBoxAnimate.UseVisualStyleBackColor = true;
			this.checkBoxAnimate.CheckedChanged += new System.EventHandler(this.checkBoxAnimate_CheckedChanged);
			// 
			// textBoxAnimatePeriod
			// 
			this.textBoxAnimatePeriod.Location = new System.Drawing.Point(82, 388);
			this.textBoxAnimatePeriod.Name = "textBoxAnimatePeriod";
			this.textBoxAnimatePeriod.Size = new System.Drawing.Size(83, 20);
			this.textBoxAnimatePeriod.TabIndex = 50;
			this.textBoxAnimatePeriod.Text = "1";
			// 
			// buttonGif
			// 
			this.buttonGif.Location = new System.Drawing.Point(198, 559);
			this.buttonGif.Name = "buttonGif";
			this.buttonGif.Size = new System.Drawing.Size(75, 23);
			this.buttonGif.TabIndex = 51;
			this.buttonGif.Text = "Animation";
			this.buttonGif.UseVisualStyleBackColor = true;
			this.buttonGif.Click += new System.EventHandler(this.buttonGif_Click);
			// 
			// radioButtonEulerSymplectic
			// 
			this.radioButtonEulerSymplectic.AutoSize = true;
			this.radioButtonEulerSymplectic.Location = new System.Drawing.Point(1240, 82);
			this.radioButtonEulerSymplectic.Name = "radioButtonEulerSymplectic";
			this.radioButtonEulerSymplectic.Size = new System.Drawing.Size(103, 17);
			this.radioButtonEulerSymplectic.TabIndex = 52;
			this.radioButtonEulerSymplectic.Text = "Euler Symplectic";
			this.radioButtonEulerSymplectic.UseVisualStyleBackColor = true;
			this.radioButtonEulerSymplectic.CheckedChanged += new System.EventHandler(this.radioButtonEulerSymplectic_CheckedChanged);
			// 
			// tabControlIntegrationParameters
			// 
			this.tabControlIntegrationParameters.Controls.Add(this.tabPagePoincare);
			this.tabControlIntegrationParameters.Controls.Add(this.tabPageBasic);
			this.tabControlIntegrationParameters.Location = new System.Drawing.Point(893, 12);
			this.tabControlIntegrationParameters.Name = "tabControlIntegrationParameters";
			this.tabControlIntegrationParameters.SelectedIndex = 0;
			this.tabControlIntegrationParameters.Size = new System.Drawing.Size(341, 356);
			this.tabControlIntegrationParameters.TabIndex = 53;
			// 
			// tabPagePoincare
			// 
			this.tabPagePoincare.Controls.Add(this.panel1);
			this.tabPagePoincare.Location = new System.Drawing.Point(4, 22);
			this.tabPagePoincare.Name = "tabPagePoincare";
			this.tabPagePoincare.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePoincare.Size = new System.Drawing.Size(333, 330);
			this.tabPagePoincare.TabIndex = 0;
			this.tabPagePoincare.Text = "Poincare";
			this.tabPagePoincare.UseVisualStyleBackColor = true;
			// 
			// tabPageBasic
			// 
			this.tabPageBasic.Controls.Add(this.checkBoxDirectionRight);
			this.tabPageBasic.Controls.Add(this.checkBoxDirectionLeft);
			this.tabPageBasic.Controls.Add(this.labelDirection);
			this.tabPageBasic.Controls.Add(this.textBoxStep);
			this.tabPageBasic.Controls.Add(this.textBoxError);
			this.tabPageBasic.Controls.Add(this.radioButtonStep);
			this.tabPageBasic.Controls.Add(this.radioButtonError);
			this.tabPageBasic.Controls.Add(this.labelIterations);
			this.tabPageBasic.Controls.Add(this.textBoxIterations);
			this.tabPageBasic.Location = new System.Drawing.Point(4, 22);
			this.tabPageBasic.Name = "tabPageBasic";
			this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageBasic.Size = new System.Drawing.Size(333, 330);
			this.tabPageBasic.TabIndex = 1;
			this.tabPageBasic.Text = "Basic";
			this.tabPageBasic.UseVisualStyleBackColor = true;
			// 
			// checkBoxDirectionRight
			// 
			this.checkBoxDirectionRight.AutoSize = true;
			this.checkBoxDirectionRight.Checked = true;
			this.checkBoxDirectionRight.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxDirectionRight.Location = new System.Drawing.Point(148, 106);
			this.checkBoxDirectionRight.Name = "checkBoxDirectionRight";
			this.checkBoxDirectionRight.Size = new System.Drawing.Size(51, 17);
			this.checkBoxDirectionRight.TabIndex = 7;
			this.checkBoxDirectionRight.Text = "Right";
			this.checkBoxDirectionRight.UseVisualStyleBackColor = true;
			// 
			// checkBoxDirectionLeft
			// 
			this.checkBoxDirectionLeft.AutoSize = true;
			this.checkBoxDirectionLeft.Checked = true;
			this.checkBoxDirectionLeft.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxDirectionLeft.Location = new System.Drawing.Point(98, 106);
			this.checkBoxDirectionLeft.Name = "checkBoxDirectionLeft";
			this.checkBoxDirectionLeft.Size = new System.Drawing.Size(44, 17);
			this.checkBoxDirectionLeft.TabIndex = 6;
			this.checkBoxDirectionLeft.Text = "Left";
			this.checkBoxDirectionLeft.UseVisualStyleBackColor = true;
			// 
			// labelDirection
			// 
			this.labelDirection.AutoSize = true;
			this.labelDirection.Location = new System.Drawing.Point(17, 106);
			this.labelDirection.Name = "labelDirection";
			this.labelDirection.Size = new System.Drawing.Size(49, 13);
			this.labelDirection.TabIndex = 0;
			this.labelDirection.Text = "Direction";
			// 
			// textBoxStep
			// 
			this.textBoxStep.Location = new System.Drawing.Point(98, 71);
			this.textBoxStep.Name = "textBoxStep";
			this.textBoxStep.Size = new System.Drawing.Size(100, 20);
			this.textBoxStep.TabIndex = 5;
			this.textBoxStep.Text = "0.01";
			// 
			// textBoxError
			// 
			this.textBoxError.Enabled = false;
			this.textBoxError.Location = new System.Drawing.Point(98, 44);
			this.textBoxError.Name = "textBoxError";
			this.textBoxError.Size = new System.Drawing.Size(100, 20);
			this.textBoxError.TabIndex = 4;
			this.textBoxError.Text = "0.001";
			// 
			// radioButtonStep
			// 
			this.radioButtonStep.AutoSize = true;
			this.radioButtonStep.Checked = true;
			this.radioButtonStep.Location = new System.Drawing.Point(20, 71);
			this.radioButtonStep.Name = "radioButtonStep";
			this.radioButtonStep.Size = new System.Drawing.Size(47, 17);
			this.radioButtonStep.TabIndex = 3;
			this.radioButtonStep.TabStop = true;
			this.radioButtonStep.Text = "Step";
			this.radioButtonStep.UseVisualStyleBackColor = true;
			// 
			// radioButtonError
			// 
			this.radioButtonError.AutoSize = true;
			this.radioButtonError.Enabled = false;
			this.radioButtonError.Location = new System.Drawing.Point(20, 44);
			this.radioButtonError.Name = "radioButtonError";
			this.radioButtonError.Size = new System.Drawing.Size(47, 17);
			this.radioButtonError.TabIndex = 2;
			this.radioButtonError.Text = "Error";
			this.radioButtonError.UseVisualStyleBackColor = true;
			// 
			// labelIterations
			// 
			this.labelIterations.AutoSize = true;
			this.labelIterations.Location = new System.Drawing.Point(17, 12);
			this.labelIterations.Name = "labelIterations";
			this.labelIterations.Size = new System.Drawing.Size(50, 13);
			this.labelIterations.TabIndex = 1;
			this.labelIterations.Text = "Iterations";
			// 
			// textBoxIterations
			// 
			this.textBoxIterations.Enabled = false;
			this.textBoxIterations.Location = new System.Drawing.Point(98, 10);
			this.textBoxIterations.Name = "textBoxIterations";
			this.textBoxIterations.Size = new System.Drawing.Size(100, 20);
			this.textBoxIterations.TabIndex = 0;
			this.textBoxIterations.Text = "100000";
			// 
			// groupBoxCalculationsResult
			// 
			this.groupBoxCalculationsResult.Controls.Add(this.labelFunctionsInvocationsCountResult);
			this.groupBoxCalculationsResult.Controls.Add(this.labelFunctionsInvocationsCount);
			this.groupBoxCalculationsResult.Controls.Add(this.labelIterationsCountResult);
			this.groupBoxCalculationsResult.Controls.Add(this.labelTimeElapsedResult);
			this.groupBoxCalculationsResult.Controls.Add(this.labelIterationsCount);
			this.groupBoxCalculationsResult.Controls.Add(this.labelTimeElapsed);
			this.groupBoxCalculationsResult.Location = new System.Drawing.Point(897, 388);
			this.groupBoxCalculationsResult.Name = "groupBoxCalculationsResult";
			this.groupBoxCalculationsResult.Size = new System.Drawing.Size(303, 165);
			this.groupBoxCalculationsResult.TabIndex = 54;
			this.groupBoxCalculationsResult.TabStop = false;
			this.groupBoxCalculationsResult.Text = "CalculationsResult";
			// 
			// labelFunctionsInvocationsCountResult
			// 
			this.labelFunctionsInvocationsCountResult.AutoSize = true;
			this.labelFunctionsInvocationsCountResult.Location = new System.Drawing.Point(151, 77);
			this.labelFunctionsInvocationsCountResult.Name = "labelFunctionsInvocationsCountResult";
			this.labelFunctionsInvocationsCountResult.Size = new System.Drawing.Size(136, 13);
			this.labelFunctionsInvocationsCountResult.TabIndex = 5;
			this.labelFunctionsInvocationsCountResult.Text = "FunctionsInvocationsCount";
			// 
			// labelFunctionsInvocationsCount
			// 
			this.labelFunctionsInvocationsCount.AutoSize = true;
			this.labelFunctionsInvocationsCount.Location = new System.Drawing.Point(12, 77);
			this.labelFunctionsInvocationsCount.Name = "labelFunctionsInvocationsCount";
			this.labelFunctionsInvocationsCount.Size = new System.Drawing.Size(136, 13);
			this.labelFunctionsInvocationsCount.TabIndex = 4;
			this.labelFunctionsInvocationsCount.Text = "FunctionsInvocationsCount";
			// 
			// labelIterationsCountResult
			// 
			this.labelIterationsCountResult.AutoSize = true;
			this.labelIterationsCountResult.Location = new System.Drawing.Point(151, 54);
			this.labelIterationsCountResult.Name = "labelIterationsCountResult";
			this.labelIterationsCountResult.Size = new System.Drawing.Size(108, 13);
			this.labelIterationsCountResult.TabIndex = 3;
			this.labelIterationsCountResult.Text = "IterationsCountResult";
			// 
			// labelTimeElapsedResult
			// 
			this.labelTimeElapsedResult.AutoSize = true;
			this.labelTimeElapsedResult.Location = new System.Drawing.Point(151, 33);
			this.labelTimeElapsedResult.Name = "labelTimeElapsedResult";
			this.labelTimeElapsedResult.Size = new System.Drawing.Size(98, 13);
			this.labelTimeElapsedResult.TabIndex = 2;
			this.labelTimeElapsedResult.Text = "TimeElapsedResult";
			// 
			// labelIterationsCount
			// 
			this.labelIterationsCount.AutoSize = true;
			this.labelIterationsCount.Location = new System.Drawing.Point(12, 55);
			this.labelIterationsCount.Name = "labelIterationsCount";
			this.labelIterationsCount.Size = new System.Drawing.Size(81, 13);
			this.labelIterationsCount.TabIndex = 1;
			this.labelIterationsCount.Text = "IterationsCount:";
			// 
			// labelTimeElapsed
			// 
			this.labelTimeElapsed.AutoSize = true;
			this.labelTimeElapsed.Location = new System.Drawing.Point(9, 33);
			this.labelTimeElapsed.Name = "labelTimeElapsed";
			this.labelTimeElapsed.Size = new System.Drawing.Size(71, 13);
			this.labelTimeElapsed.TabIndex = 0;
			this.labelTimeElapsed.Text = "TimeElapsed:";
			// 
			// radioButtonHeuns
			// 
			this.radioButtonHeuns.AutoSize = true;
			this.radioButtonHeuns.Location = new System.Drawing.Point(1240, 40);
			this.radioButtonHeuns.Name = "radioButtonHeuns";
			this.radioButtonHeuns.Size = new System.Drawing.Size(82, 17);
			this.radioButtonHeuns.TabIndex = 56;
			this.radioButtonHeuns.Text = "Symplectic4";
			this.radioButtonHeuns.UseVisualStyleBackColor = true;
			this.radioButtonHeuns.CheckedChanged += new System.EventHandler(this.radioButtonHeuns_CheckedChanged);
			// 
			// radioButtonEulerImplicit
			// 
			this.radioButtonEulerImplicit.AutoSize = true;
			this.radioButtonEulerImplicit.Location = new System.Drawing.Point(1240, 105);
			this.radioButtonEulerImplicit.Name = "radioButtonEulerImplicit";
			this.radioButtonEulerImplicit.Size = new System.Drawing.Size(84, 17);
			this.radioButtonEulerImplicit.TabIndex = 57;
			this.radioButtonEulerImplicit.Text = "Euler Implicit";
			this.radioButtonEulerImplicit.UseVisualStyleBackColor = true;
			this.radioButtonEulerImplicit.CheckedChanged += new System.EventHandler(this.radioButtonEulerImplicit_CheckedChanged);
			// 
			// buttonSaveSystem
			// 
			this.buttonSaveSystem.Location = new System.Drawing.Point(356, 540);
			this.buttonSaveSystem.Name = "buttonSaveSystem";
			this.buttonSaveSystem.Size = new System.Drawing.Size(75, 23);
			this.buttonSaveSystem.TabIndex = 58;
			this.buttonSaveSystem.Text = "Save";
			this.buttonSaveSystem.UseVisualStyleBackColor = true;
			this.buttonSaveSystem.Click += new System.EventHandler(this.buttonSaveSystem_Click);
			// 
			// buttonFullScreen
			// 
			this.buttonFullScreen.Location = new System.Drawing.Point(401, 385);
			this.buttonFullScreen.Name = "buttonFullScreen";
			this.buttonFullScreen.Size = new System.Drawing.Size(75, 23);
			this.buttonFullScreen.TabIndex = 59;
			this.buttonFullScreen.Text = "full screen";
			this.buttonFullScreen.UseVisualStyleBackColor = true;
			this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
			// 
			// checkBoxSavePastValues
			// 
			this.checkBoxSavePastValues.AutoSize = true;
			this.checkBoxSavePastValues.Checked = true;
			this.checkBoxSavePastValues.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSavePastValues.Location = new System.Drawing.Point(238, 388);
			this.checkBoxSavePastValues.Name = "checkBoxSavePastValues";
			this.checkBoxSavePastValues.Size = new System.Drawing.Size(110, 17);
			this.checkBoxSavePastValues.TabIndex = 60;
			this.checkBoxSavePastValues.Text = "Save Past Values";
			this.checkBoxSavePastValues.UseVisualStyleBackColor = true;
			this.checkBoxSavePastValues.CheckedChanged += new System.EventHandler(this.checkBoxSavePastValues_CheckedChanged);
			// 
			// buttonColor
			// 
			this.buttonColor.Location = new System.Drawing.Point(57, 540);
			this.buttonColor.Name = "buttonColor";
			this.buttonColor.Size = new System.Drawing.Size(75, 23);
			this.buttonColor.TabIndex = 61;
			this.buttonColor.Text = "Select Color";
			this.buttonColor.UseVisualStyleBackColor = true;
			this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
			// 
			// graphSystemBehavior1
			// 
			this.graphSystemBehavior1.Animate = false;
			this.graphSystemBehavior1.AnimatePeriod = 1;
			this.graphSystemBehavior1.AxisXlabel = "x";
			this.graphSystemBehavior1.AxisYlabel = "y";
			this.graphSystemBehavior1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graphSystemBehavior1.ColorForNewData = System.Drawing.Color.Empty;
			this.graphSystemBehavior1.Data = null;
			this.graphSystemBehavior1.f0 = null;
			this.graphSystemBehavior1.functionsD = null;
			this.graphSystemBehavior1.GraphHist = false;
			this.graphSystemBehavior1.IntegrationType = Mathematics.Intergration.IntegrationType.EulerMethod;
			this.graphSystemBehavior1.IntergrationParameters = null;
			this.graphSystemBehavior1.IsAxisVisible = true;
			this.graphSystemBehavior1.Location = new System.Drawing.Point(12, 12);
			this.graphSystemBehavior1.MoveButtonsExist = true;
			this.graphSystemBehavior1.Name = "graphSystemBehavior1";
			this.graphSystemBehavior1.Parameters = null;
			this.graphSystemBehavior1.SavePastValues = false;
			this.graphSystemBehavior1.Scatter = true;
			this.graphSystemBehavior1.Size = new System.Drawing.Size(464, 363);
			this.graphSystemBehavior1.Solutions = null;
			this.graphSystemBehavior1.t0 = 0D;
			this.graphSystemBehavior1.TabIndex = 0;
			this.graphSystemBehavior1.UseDynamicFunctions = false;
			this.graphSystemBehavior1.ZoomButtonsExist = true;
			this.graphSystemBehavior1.CalculationFinished += new Graph.Events.CalculationFinishedHandler(this.graphSystemBehavior1_CalculationFinished);
			// 
			// buttonSetOfInitials
			// 
			this.buttonSetOfInitials.Location = new System.Drawing.Point(796, 67);
			this.buttonSetOfInitials.Name = "buttonSetOfInitials";
			this.buttonSetOfInitials.Size = new System.Drawing.Size(75, 23);
			this.buttonSetOfInitials.TabIndex = 62;
			this.buttonSetOfInitials.Text = "Set of init";
			this.buttonSetOfInitials.UseVisualStyleBackColor = true;
			this.buttonSetOfInitials.Click += new System.EventHandler(this.buttonSetOfInitials_Click);
			// 
			// buttonCalcSet
			// 
			this.buttonCalcSet.Enabled = false;
			this.buttonCalcSet.Location = new System.Drawing.Point(796, 96);
			this.buttonCalcSet.Name = "buttonCalcSet";
			this.buttonCalcSet.Size = new System.Drawing.Size(75, 23);
			this.buttonCalcSet.TabIndex = 63;
			this.buttonCalcSet.Text = "Calc set";
			this.buttonCalcSet.UseVisualStyleBackColor = true;
			this.buttonCalcSet.Click += new System.EventHandler(this.buttonCalcSet_Click);
			// 
			// checkBoxTime
			// 
			this.checkBoxTime.AutoSize = true;
			this.checkBoxTime.Location = new System.Drawing.Point(252, 78);
			this.checkBoxTime.Name = "checkBoxTime";
			this.checkBoxTime.Size = new System.Drawing.Size(29, 17);
			this.checkBoxTime.TabIndex = 62;
			this.checkBoxTime.Text = "t";
			this.checkBoxTime.UseVisualStyleBackColor = true;
			this.checkBoxTime.CheckedChanged += new System.EventHandler(this.checkBoxTime_CheckedChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Equatins Set (*.eqset)|*.eqset";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Equatins Set (*.eqset)|*.eqset";
			// 
			// buttonSaveData
			// 
			this.buttonSaveData.Location = new System.Drawing.Point(338, 601);
			this.buttonSaveData.Name = "buttonSaveData";
			this.buttonSaveData.Size = new System.Drawing.Size(75, 23);
			this.buttonSaveData.TabIndex = 64;
			this.buttonSaveData.Text = "Sava Data";
			this.buttonSaveData.UseVisualStyleBackColor = true;
			this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click_1);
			// 
			// buttonLoadData
			// 
			this.buttonLoadData.Location = new System.Drawing.Point(513, 601);
			this.buttonLoadData.Name = "buttonLoadData";
			this.buttonLoadData.Size = new System.Drawing.Size(75, 23);
			this.buttonLoadData.TabIndex = 65;
			this.buttonLoadData.Text = "LoadData";
			this.buttonLoadData.UseVisualStyleBackColor = true;
			this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
			// 
			// FormDynamicEquations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1370, 724);
			this.Controls.Add(this.buttonLoadData);
			this.Controls.Add(this.buttonSaveData);
			this.Controls.Add(this.buttonCalcSet);
			this.Controls.Add(this.buttonSetOfInitials);
			this.Controls.Add(this.buttonColor);
			this.Controls.Add(this.checkBoxSavePastValues);
			this.Controls.Add(this.buttonFullScreen);
			this.Controls.Add(this.buttonSaveSystem);
			this.Controls.Add(this.radioButtonEulerImplicit);
			this.Controls.Add(this.radioButtonHeuns);
			this.Controls.Add(this.groupBoxCalculationsResult);
			this.Controls.Add(this.tabControlIntegrationParameters);
			this.Controls.Add(this.radioButtonEulerSymplectic);
			this.Controls.Add(this.buttonGif);
			this.Controls.Add(this.textBoxAnimatePeriod);
			this.Controls.Add(this.checkBoxAnimate);
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
			this.Controls.Add(this.textBoxF);
			this.Controls.Add(this.textBoxB);
			this.Controls.Add(this.textBoxC);
			this.Controls.Add(this.textBoxD);
			this.Controls.Add(this.textBoxE);
			this.Controls.Add(this.textBoxA);
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
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabControlIntegrationParameters.ResumeLayout(false);
			this.tabPagePoincare.ResumeLayout(false);
			this.tabPageBasic.ResumeLayout(false);
			this.tabPageBasic.PerformLayout();
			this.groupBoxCalculationsResult.ResumeLayout(false);
			this.groupBoxCalculationsResult.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonAddEquation;
		private System.Windows.Forms.Button buttonCalc;
		private System.Windows.Forms.Label labelt0;
		private System.Windows.Forms.TextBox textBoxt0;
		private System.Windows.Forms.ListBox listBoxX;
		private System.Windows.Forms.ListBox listBoxY;
		private System.Windows.Forms.Label labelParametersLabel;
		private System.Windows.Forms.Label labelA;
		private System.Windows.Forms.Label labelC;
		private System.Windows.Forms.Label labelD;
		private System.Windows.Forms.Label labelB;
		private System.Windows.Forms.Label labelE;
		private System.Windows.Forms.Label labelF;
		private System.Windows.Forms.TextBox textBoxA;
		private System.Windows.Forms.TextBox textBoxE;
		private System.Windows.Forms.TextBox textBoxD;
		private System.Windows.Forms.TextBox textBoxC;
		private System.Windows.Forms.TextBox textBoxB;
		private System.Windows.Forms.TextBox textBoxF;
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
		private System.Windows.Forms.Label labelH;
		private System.Windows.Forms.Label labelVarEquation;
		private System.Windows.Forms.Label labelHDeterminingVariable;
		private System.Windows.Forms.TextBox textBoxVarEquation;
		private System.Windows.Forms.ComboBox comboBoxVarForDetH;
		private System.Windows.Forms.CheckBox checkBoxAnimate;
		private System.Windows.Forms.TextBox textBoxAnimatePeriod;
		private System.Windows.Forms.Button buttonGif;
		public Graph.GraphDynamicType graphSystemBehavior1;
		private System.Windows.Forms.RadioButton radioButtonEulerSymplectic;
		private System.Windows.Forms.TabControl tabControlIntegrationParameters;
		private System.Windows.Forms.TabPage tabPagePoincare;
		private System.Windows.Forms.TabPage tabPageBasic;
		private System.Windows.Forms.TextBox textBoxIterations;
		private System.Windows.Forms.CheckBox checkBoxDirectionRight;
		private System.Windows.Forms.CheckBox checkBoxDirectionLeft;
		private System.Windows.Forms.Label labelDirection;
		private System.Windows.Forms.TextBox textBoxStep;
		private System.Windows.Forms.TextBox textBoxError;
		private System.Windows.Forms.RadioButton radioButtonStep;
		private System.Windows.Forms.RadioButton radioButtonError;
		private System.Windows.Forms.Label labelIterations;
		private System.Windows.Forms.GroupBox groupBoxCalculationsResult;
		private System.Windows.Forms.Label labelFunctionsInvocationsCountResult;
		private System.Windows.Forms.Label labelFunctionsInvocationsCount;
		private System.Windows.Forms.Label labelIterationsCountResult;
		private System.Windows.Forms.Label labelTimeElapsedResult;
		private System.Windows.Forms.Label labelIterationsCount;
		private System.Windows.Forms.Label labelTimeElapsed;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radioButtonHeuns;
		private System.Windows.Forms.RadioButton radioButtonEulerImplicit;
		public System.Windows.Forms.TextBox textBoxH;
		private System.Windows.Forms.Button buttonSaveSystem;
		public System.Windows.Forms.ListBox listBoxSystemName;
		private System.Windows.Forms.Button buttonFullScreen;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.CheckBox checkBoxSavePastValues;
		private System.Windows.Forms.Button buttonColor;
		private System.Windows.Forms.Button buttonSetOfInitials;
		private System.Windows.Forms.Button buttonCalcSet;
		private System.Windows.Forms.CheckBox checkBoxTime;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button buttonSaveData;
		private System.Windows.Forms.Button buttonLoadData;
	}
}

