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
		int Iterator;
		public GifGenerator (FormDynamicEquations p) {
			ParentF = p;
			Iterator = 0;
			InitializeComponent ();
			this.FormClosing += GifGenerator_FormClosing;
		}

		void GifGenerator_FormClosing ( object sender , FormClosingEventArgs e ) {
			ParentF.graphSystemBehavior1.ImageCreated -= graphSystemBehavior1_ImageCreated;
		}

		private void buttonGenerate_Click ( object sender , EventArgs e ) {
			if ( this.checkBoxSaveToFolder.Checked ) {
				if ( this.folderBrowserDialog1.ShowDialog () != System.Windows.Forms.DialogResult.OK ) return;
			}
			Images = new List<Bitmap> ();
			ParentF.graphSystemBehavior1.ImageCreated += graphSystemBehavior1_ImageCreated;
			Current = Convert.ToDouble(this.textBoxInitial.Text);
			ParentF.Initials[0].Text = this.textBoxInitial.Text;
			ParentF.buttonCalc_Click ( null , null );
		}

		void graphSystemBehavior1_ImageCreated () {
			
			if ( Convert.ToDouble ( this.textBoxFinal.Text ) >= Current ) {
				//ParentF.Initials.First ().Text = Current.ToString ();
				Current += Convert.ToDouble ( this.textBoxStep.Text );
				this.SaveImage ( ParentF.graphSystemBehavior1.GetImage () );
				this.Images.Add ( ParentF.graphSystemBehavior1.GetImage () );
				ParentF.Invoke ( new Action ( () => {
					ParentF.Initials[0].Text = Current.ToString ();
					ParentF.buttonCalc_Click ( null , null );
					this.trackBar1.Maximum = Images.Count-1;
				} ) );


			}
			else {
				this.pictureBox1.Image = Images.First ();
				//this.trackBar1.Maximum = Images.Count;
			}
			MessageBox.Show ("asddas");
		}

		public void SaveImage ( Bitmap img ) {
			if ( this.checkBoxSaveToFolder.Checked ) {
				string name = this.folderBrowserDialog1.SelectedPath + "\\" + Iterator.ToString () + ".jpg";
				img.Save ( name ); 
			}
			var newPicBox = new PictureBox ();
			newPicBox.Image = img;
			newPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
			int width = this.flowLayoutPanel1.Width - 25;
			newPicBox.Size = new Size ( width , (int)( ((double) img.Height / (double)img.Width ) * (double)width) );
			this.Invoke ( new Action ( () => {
				this.flowLayoutPanel1.Controls.Add ( newPicBox );
			} ) );
			
			Iterator++;
		}

		private void trackBar1_Scroll ( object sender , EventArgs e ) {
			this.pictureBox1.Image = this.Images[this.trackBar1.Value];
		}
	}
}
