namespace SPBSU.Dynamic {
	partial class SetOfInitialsForm {
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
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.labelCount = new System.Windows.Forms.Label();
			this.buttonChangeCount = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonRamove = new System.Windows.Forms.Button();
			this.buttonCalculate = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonSaveClose = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.SuspendLayout();
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(68, 12);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(100, 20);
			this.textBoxCount.TabIndex = 0;
			this.textBoxCount.Text = "1";
			// 
			// labelCount
			// 
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new System.Drawing.Point(12, 15);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(35, 13);
			this.labelCount.TabIndex = 1;
			this.labelCount.Text = "Count";
			// 
			// buttonChangeCount
			// 
			this.buttonChangeCount.Location = new System.Drawing.Point(197, 10);
			this.buttonChangeCount.Name = "buttonChangeCount";
			this.buttonChangeCount.Size = new System.Drawing.Size(75, 23);
			this.buttonChangeCount.TabIndex = 2;
			this.buttonChangeCount.Text = "Change";
			this.buttonChangeCount.UseVisualStyleBackColor = true;
			this.buttonChangeCount.Click += new System.EventHandler(this.buttonChangeCount_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(292, 10);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 3;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonRamove
			// 
			this.buttonRamove.Location = new System.Drawing.Point(390, 10);
			this.buttonRamove.Name = "buttonRamove";
			this.buttonRamove.Size = new System.Drawing.Size(75, 23);
			this.buttonRamove.TabIndex = 4;
			this.buttonRamove.Text = "Remove last";
			this.buttonRamove.UseVisualStyleBackColor = true;
			this.buttonRamove.Click += new System.EventHandler(this.buttonRamove_Click);
			// 
			// buttonCalculate
			// 
			this.buttonCalculate.Location = new System.Drawing.Point(12, 38);
			this.buttonCalculate.Name = "buttonCalculate";
			this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
			this.buttonCalculate.TabIndex = 5;
			this.buttonCalculate.Text = "Calculate";
			this.buttonCalculate.UseVisualStyleBackColor = true;
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(197, 38);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 6;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonSaveClose
			// 
			this.buttonSaveClose.Location = new System.Drawing.Point(105, 38);
			this.buttonSaveClose.Name = "buttonSaveClose";
			this.buttonSaveClose.Size = new System.Drawing.Size(75, 23);
			this.buttonSaveClose.TabIndex = 7;
			this.buttonSaveClose.Text = "Save & close";
			this.buttonSaveClose.UseVisualStyleBackColor = true;
			this.buttonSaveClose.Click += new System.EventHandler(this.buttonSaveClose_Click);
			// 
			// SetOfInitialsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(543, 320);
			this.Controls.Add(this.buttonSaveClose);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonCalculate);
			this.Controls.Add(this.buttonRamove);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.buttonChangeCount);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.textBoxCount);
			this.Name = "SetOfInitialsForm";
			this.Text = "SetOfInitialsForm";
			this.Load += new System.EventHandler(this.SetOfInitialsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.Label labelCount;
		private System.Windows.Forms.Button buttonChangeCount;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonRamove;
		private System.Windows.Forms.Button buttonCalculate;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSaveClose;
		private System.Windows.Forms.ColorDialog colorDialog1;
	}
}