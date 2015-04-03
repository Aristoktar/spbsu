using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph {
	public class GraphSystemOscillogram : Graph {
		protected override void calculate () {
		}

		private void InitializeComponent () {
			this.SuspendLayout();
			// 
			// GraphSystemBehavior
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "GraphSystemBehavior";
			this.Size = new System.Drawing.Size(464, 181);
			this.ResumeLayout(false);

		}
		public void setYdata(List<double> data_Y)
		{
			this.dataY = data_Y.ToArray ();
			List<double> data_X = new List<double> ();
			for ( int i = 0 ; i < data_Y.Count ; i++ ) {
				data_X.Add (i);
			}
			this.dataX = data_X.ToArray ();
		}
	}
}
