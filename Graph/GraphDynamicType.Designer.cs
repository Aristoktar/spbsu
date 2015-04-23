namespace Graph {
	partial class GraphDynamicType {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.checkBoxScatter = new System.Windows.Forms.CheckBox();
			this.buttonZoom100 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkBoxScatter
			// 
			this.checkBoxScatter.AutoSize = true;
			this.checkBoxScatter.Location = new System.Drawing.Point(66, 343);
			this.checkBoxScatter.Name = "checkBoxScatter";
			this.checkBoxScatter.Size = new System.Drawing.Size(81, 17);
			this.checkBoxScatter.TabIndex = 1;
			this.checkBoxScatter.Text = "Scatter Plot";
			this.checkBoxScatter.UseVisualStyleBackColor = true;
			this.checkBoxScatter.CheckedChanged += new System.EventHandler(this.checkBoxScatter_CheckedChanged);
			// 
			// buttonZoom100
			// 
			this.buttonZoom100.Location = new System.Drawing.Point(0, 343);
			this.buttonZoom100.Name = "buttonZoom100";
			this.buttonZoom100.Size = new System.Drawing.Size(44, 23);
			this.buttonZoom100.TabIndex = 2;
			this.buttonZoom100.Text = "100%";
			this.buttonZoom100.UseVisualStyleBackColor = true;
			this.buttonZoom100.Click += new System.EventHandler(this.buttonZoom100_Click);
			// 
			// GraphDynamicType
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonZoom100);
			this.Controls.Add(this.checkBoxScatter);
			this.Name = "GraphDynamicType";
			this.Load += new System.EventHandler(this.GraphDynamicType_Load);
			this.Controls.SetChildIndex(this.checkBoxScatter, 0);
			this.Controls.SetChildIndex(this.buttonZoom100, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxScatter;
		private System.Windows.Forms.Button buttonZoom100;
	}
}
