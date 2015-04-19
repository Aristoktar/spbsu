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
			this.graphSystemBehavior1 = new Graph.GraphDynamicType();
			this.buttonAddEquation = new System.Windows.Forms.Button();
			this.buttonCalc = new System.Windows.Forms.Button();
			this.labelt0 = new System.Windows.Forms.Label();
			this.textBoxt0 = new System.Windows.Forms.TextBox();
			this.listBoxX = new System.Windows.Forms.ListBox();
			this.listBoxY = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// graphSystemBehavior1
			// 
			//this.graphSystemBehavior1.alfa = 0D;
			this.graphSystemBehavior1.axisXlabel = "x";
			this.graphSystemBehavior1.axisYlabel = "y";
			this.graphSystemBehavior1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			//this.graphSystemBehavior1.betta = 0D;
			this.graphSystemBehavior1.f0 = null;
			this.graphSystemBehavior1.functionsD = null;
			this.graphSystemBehavior1.graphHist = false;
			//this.graphSystemBehavior1.GrowthX = 0D;
			//this.graphSystemBehavior1.GrowthY = 0D;
			//this.graphSystemBehavior1.initialX = 0D;
			//this.graphSystemBehavior1.initialY = 0D;
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
			this.buttonCalc.Location = new System.Drawing.Point(763, 24);
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
			this.labelt0.Location = new System.Drawing.Point(773, 62);
			this.labelt0.Name = "labelt0";
			this.labelt0.Size = new System.Drawing.Size(16, 13);
			this.labelt0.TabIndex = 3;
			this.labelt0.Text = "t0";
			// 
			// textBoxt0
			// 
			this.textBoxt0.Location = new System.Drawing.Point(814, 59);
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
			this.listBoxY.Location = new System.Drawing.Point(356, 429);
			this.listBoxY.Name = "listBoxY";
			this.listBoxY.Size = new System.Drawing.Size(120, 95);
			this.listBoxY.TabIndex = 6;
			// 
			// FormDynamicEquations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1112, 599);
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
	}
}

