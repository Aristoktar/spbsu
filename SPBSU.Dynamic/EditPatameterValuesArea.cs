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
	public partial class EditPatameterValuesArea : Form {

		private TrackBar TrackBarToEdit;
		public EditPatameterValuesArea (TrackBar trackbar) {
			InitializeComponent ();
			this.TrackBarToEdit = trackbar;


			this.numericUpDownMax.Value = (decimal)this.TrackBarToEdit.Maximum / (decimal)( Math.Pow(10,(double)this.numericUpDownMax.DecimalPlaces) );
			this.numericUpDownMin.Value = (decimal)this.TrackBarToEdit.Minimum / (decimal)( Math.Pow(10,(double)this.numericUpDownMin.DecimalPlaces ) );
			this.numericUpDownMax.ValueChanged += new System.EventHandler ( this.numericUpDownMax_ValueChanged );
			this.numericUpDownMin.ValueChanged += new System.EventHandler ( this.numericUpDownMin_ValueChanged );
			
		}

		private void numericUpDownMin_ValueChanged ( object sender , EventArgs e ) {
			if ( this.numericUpDownMax.Value <= this.numericUpDownMin.Value ) {
				MessageBox.Show ("Value must be bigger then mininmal value");
				this.numericUpDownMax.Value = this.numericUpDownMin.Value + this.numericUpDownMin.Increment ;
			}
		}

		private void numericUpDownMax_ValueChanged ( object sender , EventArgs e ) {
			if ( this.numericUpDownMax.Value <= this.numericUpDownMin.Value ) {
				MessageBox.Show ( "Value must be smaller then maximum value" );
				this.numericUpDownMin.Value = this.numericUpDownMax.Value - this.numericUpDownMin.Increment ;
			}
		}

		private void buttonOk_Click ( object sender , EventArgs e ) {
			this.TrackBarToEdit.Minimum = (int)(this.numericUpDownMin.Value*(decimal)Math.Pow(10,(double)this.numericUpDownMin.DecimalPlaces));
			this.TrackBarToEdit.Maximum = (int)(this.numericUpDownMax.Value*(decimal)Math.Pow(10,(double)this.numericUpDownMax.DecimalPlaces));
		}
	}
}
