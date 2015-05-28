using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gif.Components;



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
			ParentF.textBoxH.Text = this.textBoxInitial.Text;
			ParentF.buttonCalc_Click ( null , null );
		}

		void graphSystemBehavior1_ImageCreated () {
			
			if ( Convert.ToDouble ( this.textBoxFinal.Text ) > Current ) {
				//ParentF.Initials.First ().Text = Current.ToString ();
				double step = ( Convert.ToDouble ( this.textBoxFinal.Text ) - Convert.ToDouble ( this.textBoxInitial.Text ) ) / (Convert.ToDouble ( this.textBoxStep.Text )-1);
				Current += Convert.ToDouble ( step );
				this.SaveImage ( ParentF.graphSystemBehavior1.GetImage () );
				this.Images.Add ( ParentF.graphSystemBehavior1.GetImage () );
				ParentF.Invoke ( new Action ( () => {
					ParentF.textBoxH.Text = Current.ToString ();
					ParentF.buttonCalc_Click ( null , null );
					this.trackBar1.Maximum = Images.Count-1;
				} ) );


			}
			else {
				this.pictureBox1.Image = Images.First ();
				this.SaveImage ( ParentF.graphSystemBehavior1.GetImage () );
				this.Images.Add ( ParentF.graphSystemBehavior1.GetImage () );
				ParentF.Invoke ( new Action ( () => {
					this.trackBar1.Maximum = Images.Count - 1;
				} ) );
				//this.trackBar1.Maximum = Images.Count;
			}
			MessageBox.Show ("Done!");
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

		private void buttonSaveGif_Click ( object sender , EventArgs e ) {
			if ( this.saveFileDialog1.ShowDialog () == System.Windows.Forms.DialogResult.OK ) {
				AnimatedGifEncoder enc = new AnimatedGifEncoder ();
				enc.Start ( this.saveFileDialog1.FileName );
				enc.SetDelay ( 250 );
				//-1:no repeat,0:always repeat
				enc.SetRepeat ( 0 );
				foreach (var img in this.Images  ) {
					enc.AddFrame ( img );
				}
				enc.Finish ();
			}
		}
	}
}
