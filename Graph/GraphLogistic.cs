using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class GraphLogistic: Graph
    {
        double pointOfInterest = double.PositiveInfinity;
        double initialX = 0.25;
        protected override void calculate()
        {
            base.calculate();
            this.deltaXs = (double)(this.XMaxValue - this.XMinValue) / this.countXs;

            double[] temp;
            this.dataArrayOfArrays = new double[0][];
            //this.progressBar1.Maximum = this.countRs;
            //this.progressBar1.Value = 0;
            for (int i = 0; i < this.countXs; i++)
            {
                double dtemp = (double)this.XMinValue + deltaXs * i;
                temp = logistic.calc(dtemp, initialX);
                Array.Resize<double[]>(ref this.dataArrayOfArrays, this.dataArrayOfArrays.Length + 1);
                this.dataArrayOfArrays[this.dataArrayOfArrays.Length - 1] = temp;
                //this.progressBar1.Value++;
            }
            
            //base.calculate(function);
        }
       
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            
            base.OnPaint(e);
            if (this.pointOfInterest != double.PositiveInfinity)
            {
                int x = (int)this.UsersToPixel(this.pointOfInterest, Axes.x);
                if(x>0 && x<this.Width)
                {
                e.Graphics.DrawLine(Pens.Green, new Point(x, this.HeightBorderUp), new Point(x, this.Height - this.HeightBorderDown));
                }
            }

        }
        public void setInitialX(double val)
        {
            this.initialX = val;
        }

        public double setPointOfInterestCoordAndGetValue(int coord)
        {
            this.pointOfInterest = this.PixelToUsers(coord, Axes.x);
            return this.pointOfInterest;

        }


		private double[] calc ( double r , double x0 = 0.25 , int iterationsCount = 1000 ) {
			double[] ans = new double[0];
			
			for ( int i = 0 ; i < iterationsCount ; i++ ) {
				x0 = r * x0 * ( 1 - x0 );
				
				Array.Resize<double> ( ref ans , ans.Length + 1 );
				ans[ans.Length - 1] = x0;
				Array.Resize<double> ( ref ans , ans.Length + 1 );
				ans[ans.Length - 1] = x0;
			}

			return ans;
		}
    }
}
