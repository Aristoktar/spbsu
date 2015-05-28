using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Mathematics {
	public class CalculationProgress {

		CalculationProgressBar bar1;
		Control Parent;
		bool ProgressBar;
		public CalculationProgress (int maxValue, Control parent = null ) {
			Parent = parent;
			if ( parent == null ) {
				ProgressBar = false;

			}
			else {
				ProgressBar = true;
			}


			bar1 = new CalculationProgressBar ();
			bar1.progressBar1.Maximum = maxValue;
			if ( ProgressBar ) {

				bar1.timer.Elapsed += new ElapsedEventHandler ( ( sender , e ) => {
					parent.Invoke ( new Action ( () => {
						if ( bar1.progressBarLastValue == bar1.progressBar1.Value ) {

							bar1.Close ();
							parent.Invoke ( new Action ( () => {
								bar1.Close ();
							} ) );
						}
						else {
							bar1.progressBarLastValue = bar1.progressBar1.Value;
						}
						//bar1 = null;
					} ) );
				} );
				
				

				parent.Invoke ( new Action ( () => {
					bar1.Show ();
				} ) );
			}

		}
		public void NextValue (int newVal = -1) {
			//this.bar1.progressBar1.Maximum = newVal == -1 ? this.bar1.progressBar1.Maximum + 1 : newVal;
			
			Parent.Invoke ( new Action ( () => {
					var newV = newVal == -1 ? this.bar1.progressBar1.Value + 1 : newVal;
					bar1.progressBar1.Value = newV > bar1.progressBar1.Minimum && newV <= bar1.progressBar1.Maximum ? newV : this.bar1.progressBar1.Value;
					bar1.Text = "CalculationProgress(" + bar1.progressBar1.Value.ToString () + "/" + bar1.progressBar1.Maximum.ToString () + ")";
				
			} ) );
		}

		public void RefreshCounter () {
			bar1.timer.Stop ();
			bar1.timer.Start ();
		}

		public void Close () {
			if ( ProgressBar ) Parent.Invoke ( new Action ( () => {
				bar1.Close ();
				//bar1 = null;
			} ) );
		}
		
	}
}
