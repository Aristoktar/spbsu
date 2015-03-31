using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPBSU {
	public partial class Form1 : Form {
		public Form1 () {
			InitializeComponent ();
		}

		private void Form1_Load ( object sender , EventArgs e ) {
			this.graph1.alfa = 1 + (double) ( this.trackBarAlfa.Value ) / 100;
			this.graph1.betta = 1 + (double) ( this.trackBarBetta.Value ) / 100;
			this.graph1.initialX = (double) ( this.trackBarInitialX.Value ) / 100;
			this.graph1.initialY = (double) ( this.trackBarInitialY.Value ) / 100;
			this.graph1.setData ( 1 , 0 , 1 , 0);
		}

		private void trackBar1_Scroll ( object sender , EventArgs e ) {
			this.labelAlfaValue.Text = ( 1 + (double) ( ( sender as TrackBar ).Value ) / 100 ).ToString ();
			this.graph1.alfa = 1 + (double) ( ( sender as TrackBar ).Value ) / 100;
			this.graph1.Redraw ();
		}

		private void trackBarInitialX_Scroll ( object sender , EventArgs e ) {
			this.labelInitalXValue.Text = ( (double) ( ( sender as TrackBar ).Value ) / 100 ).ToString ();
			this.graph1.initialX = (double) ( ( sender as TrackBar ).Value ) / 100;
			this.graph1.Redraw ();
		}

		private void trackBarBetta_Scroll ( object sender , EventArgs e ) {
			this.labelBettaValue.Text = ( 1 + (double) ( ( sender as TrackBar ).Value ) / 100 ).ToString ();
			this.graph1.betta = 1 + (double) ( ( sender as TrackBar ).Value ) / 100;
			this.graph1.Redraw ();
		}

		private void trackBarInitialY_Scroll ( object sender , EventArgs e ) {
			this.labelInitialYValue.Text = ( (double) ( ( sender as TrackBar ).Value ) / 100 ).ToString ();
			this.graph1.initialY = (double) ( ( sender as TrackBar ).Value ) / 100;
			this.graph1.Redraw ();
		}
	}
}
