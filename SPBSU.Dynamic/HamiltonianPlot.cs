using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPBSU.Dynamic {
	public partial class HamiltonianPlot : Form {
		public HamiltonianPlot () {
			InitializeComponent ();
		}

		private void HamiltonianPlot_SizeChanged ( object sender , EventArgs e ) {
			this.graphSystemOscillogram1.Height = this.Height - 58;
			this.graphSystemOscillogram1.Width = this.Width - 43;
			this.graphSystemOscillogram1.Redraw ();
		}
	}
}
