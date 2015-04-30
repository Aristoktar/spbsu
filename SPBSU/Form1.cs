using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicCompiling;
using SPBSU.Dynamic;

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
			this.graph1.setData ( 1 , 0 , 1 , 0 );
			OscillatorRedraw ();

			// Data.DataProvider d = new Data.DataProvider ()  ;
			// MessageBox.Show ( d.EquationsSetsQuery.First ().Name );
			
		
			
		}

		private void OscillatorRedraw () {
			//this.graphSystemOscillogram1.setYdata ( this.graph1.GetAxisData ( Graph.Axes.x ) );
			//this.graphSystemOscillogram1.Redraw ();
			//this.graphSystemOscillogram2.setYdata ( this.graph1.GetAxisData ( Graph.Axes.y ) );
			//this.graphSystemOscillogram2.Redraw ();

			//============
			//int oscillatordataCount = this.graph1.GetAxisData ( Graph.Axes.x ).Count;
			//if ( oscillatordataCount > 1000 )
			//	oscillatordataCount = 1000;
			//t
			//	is.graphSystemOscillogram1.setData ( oscillatordataCount , 0 , 1 , 0 );

			//this.graphSystemOscillogram2.setYdata ( this.graph1.GetAxisData ( Graph.Axes.y ) );
			//this.graphSystemOscillogram2.setData ( oscillatordataCount , 0 , 1 , 0 );

		}
		private void trackBar1_Scroll ( object sender , EventArgs e ) {
			this.labelAlfaValue.Text = (  (double) ( ( sender as TrackBar ).Value ) / 100 ).ToString ();
			this.graph1.alfa = (double) ( ( sender as TrackBar ).Value ) / 100;
			this.graph1.Redraw ();
			OscillatorRedraw ();
		}

		private void trackBarInitialX_Scroll ( object sender , EventArgs e ) {
			this.labelInitalXValue.Text = ( (double) ( ( sender as TrackBar ).Value ) / 100 ).ToString ();
			this.graph1.initialX = (double) ( ( sender as TrackBar ).Value ) / 100;
			this.graph1.Redraw ();
			OscillatorRedraw ();
		}

		private void trackBarBetta_Scroll ( object sender , EventArgs e ) {
			this.labelBettaValue.Text = (  (double) ( ( sender as TrackBar ).Value ) / 100 ).ToString ();
			this.graph1.betta =  (double) ( ( sender as TrackBar ).Value ) / 100;
			this.graph1.Redraw ();
			OscillatorRedraw ();
		}

		private void trackBarInitialY_Scroll ( object sender , EventArgs e ) {
			this.labelInitialYValue.Text = ( (double) ( ( sender as TrackBar ).Value ) / 100 ).ToString ();
			this.graph1.initialY = (double) ( ( sender as TrackBar ).Value ) / 100;
			this.graph1.Redraw ();
			OscillatorRedraw ();
		}

		private void trackBarAlfa_MouseEnter ( object sender , EventArgs e ) {
			(sender as TrackBar).Focus ();
		}

		private void checkBoxScatterPlot_CheckedChanged ( object sender , EventArgs e ) {
			if ( ( sender as CheckBox ).Checked ) {
				this.graph1.Scatter = true;
			}
			else {
				this.graph1.Scatter = false;
			}
			this.graph1.Redraw ();
		}

		private void button1_Click ( object sender , EventArgs e ) {
			string inp = this.textBox1.Text.ToLower ().Replace("sin","Math.Sin");
			
			//Main.run (inp);
			FormDynamicEquations form = new FormDynamicEquations ();
			form.Show ();
		}
	}
}
