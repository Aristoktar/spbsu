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
			// GraphDynamicType
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBoxScatter);
			this.Name = "GraphDynamicType";
			this.Load += new System.EventHandler(this.GraphDynamicType_Load);
			this.SizeChanged += new System.EventHandler(this.GraphDynamicType_SizeChanged);
			this.Controls.SetChildIndex(this.checkBoxScatter, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.CheckBox checkBoxScatter;

	}
}
