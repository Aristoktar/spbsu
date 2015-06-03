using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph {
	public class GraphSystemOscillogram : Graph {
		private System.Windows.Forms.Button button1;
	
		protected override void calculate () {
		}

		protected void InitializeComponent () {
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
		public void setYdata(List<double> data_Y,Color color,List<double>data_X = null)
		{
			this.XLabelLength = 15;
			if ( data_X == null ) {
				
				this.dataY = data_Y;
				List<double> data_X_temp = new List<double> ();
				for ( int i = 0 ; i < data_Y.Count ; i++ ) {
					data_X_temp.Add ( i );
				}
				this.dataX = data_X;
			}
			else {
				double delta = Math.Abs(data_X[data_X.Count - 1] - data_X[data_X.Count - 2]);
				int max = (int)(data_X[data_X.Count-1]/delta);
				bool lessZero;
				if(max<0)
				{
					lessZero=true;
					max--;

				}else
				{
					lessZero = false;
					max++;
				}

				//this.dataY = data_Y;
				List<double> data_X_temp = new List<double> ();
				for ( int i = 0 ; i < data_Y.Count ; i++ ) {
					data_X_temp.Insert ( 0 , max );
					if ( lessZero ) max++;
					else max--;
				}
				//this.dataX = data_X_temp;
				if ( this.Data == null ) this.Data = new List<GraphData> ();
				this.Data.Add ( new GraphData {
					dataX = data_X_temp ,
					dataY = data_Y ,
					DataColor = color
				} );
			}
		}
		public void setYdata ( List<GraphData> data) {
			this.XLabelLength = 15;
			foreach(var sol in data){
				//double delta = Math.Abs ( sol.dataX[sol.dataX.Count- 1] - sol.dataX[sol.dataX.Count - 2] );
				//int max = (int) ( sol.dataX[sol.dataX.Count - 1] / delta );
				//bool lessZero;
				//if ( max < 0 ) {
				//	lessZero = true;
				//	max--;

				//}
				//else {
				//	lessZero = false;
				//	max++;
				//}

				////this.dataY = data_Y;
				//List<double> data_X_temp = new List<double> ();
				//for ( int i = 0 ; i < sol.dataY.Count ; i++ ) {
				//	data_X_temp.Insert ( 0 , max );
				//	if ( lessZero ) max++;
				//	else max--;
				//}
				//this.dataX = data_X_temp;
				if ( this.Data == null ) this.Data = new List<GraphData> ();
				this.Data.Add ( new GraphData {
					dataX = sol.dataX ,
					dataY = sol.dataY ,
					DataColor = sol.DataColor
				} );
			}
		}
		private void button1_Click ( object sender , EventArgs e ) {
			//string path = "D:\\" + DateTime.Now.Minute + ".bmp";


			//if ( saveFileDialog1.ShowDialog () == DialogResult.OK ) {
			//	//this.img.Save(this.saveFileDialog1.FileName);
			//	//this.
			//	this.ImgAxesAndLabels.Save ( this.saveFileDialog1.FileName );
			//}
		}
	}
}
