using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Mathematics {
	public partial class CalculationProgressBar : Form {
		public System.Timers.Timer timer;
		public int progressBarLastValue;
		public CalculationProgressBar () {
			progressBarLastValue = 0;
			InitializeComponent ();
			timer = new System.Timers.Timer ();
			timer.Interval = 3000;
			timer.AutoReset = true;
			//timer.Elapsed += new ElapsedEventHandler ( (sender,e)=>{} );
			timer.Start ();
			this.ControlBox = false;
		}

		

		private void CalculationProgressBar_Load ( object sender , EventArgs e ) {

		}
	}
}
