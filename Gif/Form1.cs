using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gif.Components;

namespace Gif {
	public partial class Form1 : Form {

		List<Image> Images;
		public Form1 () {
			InitializeComponent ();
			Images = new List<Image> ();
		}

		private void button2_Click ( object sender , EventArgs e ) {
			if ( this.saveFileDialog1.ShowDialog () == System.Windows.Forms.DialogResult.OK ) {
				AnimatedGifEncoder enc = new AnimatedGifEncoder ();
				enc.Start ( this.saveFileDialog1.FileName );
				enc.SetDelay ( Convert.ToInt32(this.textBox1.Text) );
				//-1:no repeat,0:always repeat
				enc.SetRepeat (-1);
				//this.Images.Reverse ();
				//for ( int i = 0 ; i < 5 ; i++ ) {
				//	enc.AddFrame ( this.Images.ElementAt(0) );
				//}
				foreach ( var img in this.Images ) {
					enc.AddFrame ( img );
				}
				//for ( int i = 0 ; i < 5 ; i++ ) {
				//	enc.AddFrame ( this.Images.ElementAt ( this.Images.Count-1 ) );
				//}
				enc.Finish ();
			}
		}

		private void button1_Click ( object sender , EventArgs e ) {
			if ( this.folderBrowserDialog1.ShowDialog () == System.Windows.Forms.DialogResult.OK ) {
				this.Images = new List<Image> ();
				DirectoryInfo dInfo = new DirectoryInfo ( this.folderBrowserDialog1.SelectedPath );
				if ( !dInfo.Exists ) {
					MessageBox.Show ("Not exist");
				}
				else {
					this.label1.Text = this.folderBrowserDialog1.SelectedPath;
					var li = dInfo.GetFiles ( "*.bmp" );//.OrderBy ( a => Convert.ToInt32 ( Path.GetFileNameWithoutExtension ( a.Name ) ) );
					foreach ( var f in  li) {
						Image imgToAdd = Bitmap.FromFile ( f.FullName );
						//---------------for henon-heiles--------------------------------
						//Graphics gr = Graphics.FromImage ( imgToAdd );
						//string val = f.Name.Split ( '-' )[1] + "/" + f.Name.Split ( '-' )[2];
						//Font font = new Font(Font.FontFamily,imgToAdd.Height/23);
						
						//gr.DrawString ( "H="+val ,font  , Brushes.Black , new PointF ( imgToAdd.Width - imgToAdd.Width / 5 , imgToAdd.Height / 12 ) );
						//gr.Save ();

						//---------------for duffing up--------------------------------
						Graphics gr = Graphics.FromImage ( imgToAdd );
						string val = f.Name.Split ( '-' )[0] + "." + Path.GetFileNameWithoutExtension(f.Name).Split ( '-' )[1];
						Font font = new Font ( Font.FontFamily , imgToAdd.Height / 25 );

						gr.DrawString ( "F=" + val , font , Brushes.OrangeRed , new PointF ( imgToAdd.Width - imgToAdd.Width / 5 , imgToAdd.Height / 12 ) );
						gr.Save ();
						this.Images.Add (imgToAdd );
					}

				}
			}
		}
	}
}
