namespace SPBSU.Dynamic {
	partial class GraphFullScreen {
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
			this.graphDynamicType = new Graph.GraphDynamicType();
			this.SuspendLayout();
			// 
			// graphSystemBehavior1
			// 
			this.graphDynamicType.Animate = false;
			this.graphDynamicType.AnimatePeriod = 1;
			this.graphDynamicType.AxisXlabel = "x";
			this.graphDynamicType.AxisYlabel = "y";
			this.graphDynamicType.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.graphDynamicType.f0 = null;
			this.graphDynamicType.functionsD = null;
			this.graphDynamicType.GraphHist = false;
			this.graphDynamicType.IsAxisVisible = true;
			this.graphDynamicType.Location = new System.Drawing.Point(1, 0);
			this.graphDynamicType.MoveButtonsExist = true;
			this.graphDynamicType.Name = "graphSystemBehavior1";
			this.graphDynamicType.SavePastValues = false;
			this.graphDynamicType.Scatter = false;
			this.graphDynamicType.Size = new System.Drawing.Size(1091, 525);
			this.graphDynamicType.t0 = 0D;
			this.graphDynamicType.TabIndex = 0;
			this.graphDynamicType.ZoomButtonsExist = true;
			// 
			// GraphFullScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1092, 525);
			this.Controls.Add(this.graphDynamicType);
			this.Name = "GraphFullScreen";
			this.Text = "GraphFullScreen";
			this.SizeChanged += new System.EventHandler(this.GraphFullScreen_SizeChanged);
			this.ResumeLayout(false);

		}

		#endregion

		public Graph.GraphDynamicType graphDynamicType;


	}
}