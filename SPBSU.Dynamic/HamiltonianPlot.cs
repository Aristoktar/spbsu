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
			this.graphSystemOscillogram1.DecimalPlaces = 15;
		}

		private void HamiltonianPlot_SizeChanged ( object sender , EventArgs e ) {
			this.graphSystemOscillogram1.Height = this.Height - 58;
			this.graphSystemOscillogram1.Width = this.Width - 43;
			this.graphSystemOscillogram1.Redraw ();
		}

		private void button1_Click ( object sender , EventArgs e ) {
			string path = "D:\\" + DateTime.Now.Minute + ".bmp";


			if ( this.graphSystemOscillogram1.saveFileDialog1.ShowDialog () == DialogResult.OK ) {
				//this.img.Save(this.saveFileDialog1.FileName);
				//this.
				this.graphSystemOscillogram1.GetImage().Save ( this.graphSystemOscillogram1.saveFileDialog1.FileName );
			}
		}
	}
}
