using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph {
	public class GraphSystemOscillogram : Graph {
		private System.Windows.Forms.Button button1;
	
		protected override void calculate () {
		}

		private void InitializeComponent () {
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(389, 158);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// GraphSystemOscillogram
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.button1);
			this.Name = "GraphSystemOscillogram";
			this.Size = new System.Drawing.Size(464, 181);
			this.Controls.SetChildIndex(this.button1, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		public void setYdata(List<double> data_Y)
		{
			this.dataY = data_Y.ToArray ();
			List<double> data_X = new List<double> ();
			for ( int i = 0 ; i < data_Y.Count ; i++ ) {
				data_X.Add (i);
			}
			this.dataX = data_X.ToArray ();
		}

		private void button1_Click ( object sender , EventArgs e ) {
			string path = "D:\\" + DateTime.Now.Minute + ".bmp";


			if ( saveFileDialog1.ShowDialog () == DialogResult.OK ) {
				//this.img.Save(this.saveFileDialog1.FileName);
				//this.
				this.ImgAxesAndLabels.Save ( this.saveFileDialog1.FileName );
			}
		}
	}
}
