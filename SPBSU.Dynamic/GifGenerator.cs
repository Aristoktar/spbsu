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
	public partial class GifGenerator : Form {
		FormDynamicEquations ParentF;
		List<Bitmap> Images;
		double Current;

		public GifGenerator (FormDynamicEquations p) {
			ParentF = p;
			InitializeComponent ();
		}

		private void buttonGenerate_Click ( object sender , EventArgs e ) {
			Images = new List<Bitmap> ();
			ParentF.graphSystemBehavior1.ImageCreated += graphSystemBehavior1_ImageCreated;
			Current = Convert.ToDouble(this.textBoxInitial.Text);
			ParentF.buttonCalc_Click ( null , null );
			


		}

		void graphSystemBehavior1_ImageCreated () {
			if ( Convert.ToDouble ( this.textBoxFinal.Text ) > Current ) {
				//ParentF.Initials.First ().Text = Current.ToString ();
				ParentF.buttonCalc_Click ( null , null );
				Current +=Convert.ToDouble( this.textBoxStep.Text);
				this.Images.Add ( ParentF.graphSystemBehavior1.GetImage () );
			}
			MessageBox.Show ("asddas");
		}
	}
}
