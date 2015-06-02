using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using Graph.Events;
using Mathematics;

namespace Graph
{
    public partial class Graph : UserControl
    {
        /// <summary>
        /// Gets or sets a value indicating whether the Axes are displayed.
        /// </summary>\
        public bool IsAxisVisible { get; set; }
       /// <summary>
       /// Gets or sets a value indicating whether the Zoom buttons are displayed.
       /// </summary>
        public bool ZoomButtonsExist { get; set; }
       /// <summary>
       /// Gets or sets a value indicating whether the Zoom buttons are displayed.
       /// </summary>
        public bool MoveButtonsExist { get; set; }
        /// <summary>
        /// axis X label
        /// </summary>
        private string _axisXlabel;
        /// <summary>
        /// axis x label
        /// </summary>
        public string AxisXlabel
        {
            get
            {
                return string.IsNullOrEmpty(_axisXlabel) ? "x" : _axisXlabel;
            }
            set { _axisXlabel = value; }
        }
        private string _axisYlabel;
        /// <summary>
        /// axis Y label
        /// </summary>
        public string AxisYlabel
        {
            get
            {
                return string.IsNullOrEmpty(_axisYlabel) ? "y" : _axisYlabel;
            }
            set { _axisYlabel = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating y data hist
        /// useful in case you want to know how often displayed pixels
        /// </summary>
        public bool GraphHist { get; set; }
        public bool Scatter { get; set; }

		public bool SavePastValues {
			get;
			set;
		}

		//public List<>

		public int DecimalPlaces = 4;

		public bool Animate {
			get;
			set;
		}
		public int AnimatePeriod {
			get;
			set;
		}

		protected Point CanvasLocation {
			get;
			set;
		}
        protected Size CanvasSize;

        protected int HeightBorderUp = 10;
        protected int HeightBorderDown = 45;
        protected int WidthBorderLeft = 70;
        protected int WidthBorderRight = 10;
        
        protected bool IsDataTrimmVisible = false;

        protected int MouseX;
        protected int MouseY;

        public double XMinValue;
        public double XMaxValue;
		public double YMinValue;
		public double YMaxValue;

		protected List<PointF> ZoomBoxList;
		protected Bitmap ImgGraph {
			get;
			set;
		}
        protected Bitmap ImgAxesAndLabels;
        protected Bitmap ImgOut;
        

        protected double[][] dataArrayOfArrays;
        public List<double> dataY;
        public List<double> dataX;
		public List<GraphData> Data {
			get;
			set;
		}
        protected string equation = "";
        private Button buttonZoomIn;
        private Button buttonZoomOut;
        private Button buttonRight;
        private Button buttonLeft;
        private Button buttonUp;
        private Button buttonDown;
        private Button buttonSave;

        public int countXs = 500;
        public int countYs = 200;
        protected double deltaXs;
        protected double deltaYs;
        private bool buttonsInited = false;

		private Thread RedrawThread;

		public int XLabelLength = 4;
		public int YLabelLength = 4;

        public Graph()
        {
            this.InitializeComponent();
            this.AxisXlabel = "x";
            this.AxisYlabel = "y";
            this.IsAxisVisible = true;
            this.MoveButtonsExist = true;
            this.ZoomButtonsExist = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CanvasLocation = new Point(WidthBorderLeft, HeightBorderUp);
            this.CanvasSize = new Size(this.Width - (this.WidthBorderLeft + this.WidthBorderRight), this.Height - (this.HeightBorderUp + this.HeightBorderDown));
            typeof(Control).GetProperty(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty
                ).SetValue(this, true, null);
            ZoomBoxList = new List<PointF>();
            this.dataArrayOfArrays = new double[0][];

			this.AnimatePeriod = 1;
        }

        /// <summary>
        /// you have to redefine this method co calculate
        /// values for graph if you what to use
        /// not analitic function
        /// </summary>
        protected virtual void calculate()
        {
			//commented when dataX array -> List
			//if (!string.IsNullOrWhiteSpace(this.equation))
			//{
			//	this.countXs = 100;
			//	this.deltaXs = (double)(this.XMaxValue - this.XMinValue) / this.countXs;

			//	treeParse.treeParse tree = new treeParse.treeParse(this.equation);
			//	tree.init();

			//	this.dataX = new List<double> ();
			//	this.dataY = new List<double> ();
			//	var timer = Stopwatch.StartNew();

			//	for (int i = 0; i <= this.countXs; i++)
			//	{
			//		double dtemp = (double)this.XMinValue + deltaXs * i;
			//		double tempt = tree.calculate("x",dtemp);

			//		Array.Resize<double>(ref this.dataX, this.dataX.Length + 1);
			//		Array.Resize<double>(ref this.dataY, this.dataY.Length + 1);
			//		this.dataX[this.dataX.Length - 1] = dtemp;
			//		this.dataY[this.dataY.Length - 1] = tempt;
			//	}
			//	timer.Stop();
			//	//MessageBox.Show(timer.Elapsed.ToString());

			//}
        }
		protected virtual void calculate (out CalculationFinishedEventArgs calculationFinishedEventArgs) {
			calculationFinishedEventArgs = new CalculationFinishedEventArgs ();
			
		}
        protected int[][] hist()
        {           
            int[][] histARR = new int[this.countXs][];
            this.deltaYs = (double)(this.YMaxValue - this.YMinValue) / this.countYs;
            for (int i = 0; i < countXs; i++)
            {
                int[] histTempArr = new int[this.countYs];
                int max = 0;
                for (int j = 0; j < this.countYs; j++)
                {
                    double dtemp = (double)this.YMinValue + deltaYs * j;
                    for (int k = 0; k < this.dataArrayOfArrays[i].Length; k++)
                    {
                        if (this.dataArrayOfArrays[i][k] > dtemp && this.dataArrayOfArrays[i][k] <= dtemp + deltaYs)
                        {
                            histTempArr[j]++;
                            if (histTempArr[j] > max)
                                max = histTempArr[j];
                        }
                    }
                }
                for (int j = 0; j < this.countYs; j++)
                {
                    double temp;
                if (max != 0)
                    temp = ((double)histTempArr[j] / (double)max) * 255;
                else
                    temp = 0;
                    histTempArr[j] = (int)temp;
                }
                histARR[i] = histTempArr;
            }
            
            return histARR;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            
			this.CreateAxesAndLabelsImage ();
			e.Graphics.DrawImage ( this.ImgAxesAndLabels , new Rectangle ( 0 , 0 , this.Width , this.Height ) );
			
            if (this.IsDataTrimmVisible)
            {
                if (!(MouseX < this.WidthBorderLeft || MouseX > this.Width - this.WidthBorderRight))
                {
                    if (!(MouseY < this.HeightBorderUp || MouseY > this.Height - this.HeightBorderDown))
                    {
                        e.Graphics.DrawLine(Pens.DarkBlue, this.WidthBorderLeft, MouseY, this.Width - this.WidthBorderRight, MouseY);
                        e.Graphics.DrawLine(Pens.DarkBlue, MouseX, this.HeightBorderUp, MouseX, this.Height - this.HeightBorderDown);
                        decimal x = (decimal)(((decimal)this.MouseX - this.WidthBorderLeft) * (decimal)(this.XMaxValue - this.XMinValue) / (this.Width - this.WidthBorderLeft - this.WidthBorderRight) + (decimal)this.XMinValue);
                        decimal y = (decimal)((this.Height - this.HeightBorderUp - this.HeightBorderDown - ((decimal)this.MouseY - this.HeightBorderUp)) * (decimal)(this.YMaxValue - this.YMinValue) / (this.Height - this.HeightBorderUp - this.HeightBorderDown) + (decimal)this.YMinValue);

						string pattern = "0.";
						for ( int i = 0 ; i < this.DecimalPlaces ; i++ ) {
							pattern += "#";
						}
						e.Graphics.DrawString ( x.ToString ( pattern ) , Font , Brushes.Black , new Point ( MouseX , this.HeightBorderUp ) );

                        e.Graphics.DrawString(y.ToString(pattern), Font, Brushes.Black, new Point(this.WidthBorderLeft, MouseY));
                    }
                }
            }
            if (this.ZoomBoxList.Count > 1)
            {
				e.Graphics.DrawLine ( Pens.Black , new PointF ( ZoomBoxList[0].X , ZoomBoxList[0].Y ) , new PointF ( ZoomBoxList[0].X , ZoomBoxList[ZoomBoxList.Count - 1].Y ) );
				e.Graphics.DrawLine ( Pens.Black , new PointF ( ZoomBoxList[ZoomBoxList.Count - 1].X , ZoomBoxList[ZoomBoxList.Count - 1].Y ) , new PointF ( ZoomBoxList[0].X , ZoomBoxList[ZoomBoxList.Count - 1].Y ) );
				e.Graphics.DrawLine ( Pens.Black , new PointF ( ZoomBoxList[0].X , ZoomBoxList[0].Y ) , new PointF ( ZoomBoxList[ZoomBoxList.Count - 1].X , ZoomBoxList[0].Y ) );
				e.Graphics.DrawLine ( Pens.Black , new PointF ( ZoomBoxList[ZoomBoxList.Count - 1].X , ZoomBoxList[0].Y ) , new PointF ( ZoomBoxList[ZoomBoxList.Count - 1].X , ZoomBoxList[ZoomBoxList.Count - 1].Y ) );
            }
            
        
        }
        
        protected override void OnMouseMove(MouseEventArgs e)
        {
            
            if (this.IsDataTrimmVisible)
            {
                this.MouseX = e.X;
                this.MouseY = e.Y;
            }
            if (MouseButtons.Left == e.Button)
            {
                if (!(e.X < this.WidthBorderLeft || e.X > this.Width - this.WidthBorderRight))
                {
                    if (!(e.Y < this.HeightBorderUp || e.Y > this.Height - this.HeightBorderDown))
                    {
                        ZoomBoxList.Add(new PointF(e.X, e.Y));
                    }
                }
            }
            this.Refresh();
           // base.OnMouseMove(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!this.IsDataTrimmVisible && e.Button == MouseButtons.Middle)
            {
                this.MouseX = e.X;
                this.MouseY = e.Y;
                this.IsDataTrimmVisible = true;
            }
            else
            {
                if (this.IsDataTrimmVisible && (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right))
                {
                    this.IsDataTrimmVisible = false;

                }
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.ZoomBoxList.Count < 1)
            {
                this.ZoomBoxList = new List<PointF>();
                return;
            }
            float minDelta = 7;//px
			double minDeltaUsers = Double.MinValue * 10; ;
            float xMax;
            float yMax;
            float xMin;
            float yMin;
            
            float[] Xs = new float[2];
            float[] Ys = new float[2];
            Xs[0] = ZoomBoxList[0].X;
            Ys[0] = ZoomBoxList[0].Y;
            Xs[1] = ZoomBoxList[ZoomBoxList.Count - 1].X;
            Ys[1] = ZoomBoxList[ZoomBoxList.Count - 1].Y;
            xMax = Xs.Max();
            yMax = Ys.Min();
            xMin = Xs.Min();
            yMin = Ys.Max();
            if (xMax - xMin < minDelta || yMin - yMax < minDelta)
            {
                this.ZoomBoxList = new List<PointF>();
                return;
            }
            

            double yStart = this.PixelToUsers(yMin, Axes.y);
            double yEnd = this.PixelToUsers(yMax, Axes.y);
            double xStart = this.PixelToUsers(xMin, Axes.x);
            double xEnd = this.PixelToUsers(xMax, Axes.x);
            if (Math.Abs(yEnd - yStart) < minDeltaUsers || Math.Abs( xEnd - xStart) < minDeltaUsers)
            {
                this.ZoomBoxList = new List<PointF>();
                MessageBox.Show("reached maximun zoom");
                return;
            }
            this.YMaxValue = yEnd;
            this.YMinValue = yStart;
            this.XMaxValue = xEnd;
            this.XMinValue = xStart;
            this.ZoomBoxList = new List<PointF>();
            
            this.Draw();
        }
        public void setData(double xMax, double xMin, double yMax, double yMin, string equationString = "")
        {
            this.XMaxValue = xMax;
            this.XMinValue = xMin;
            this.YMaxValue = yMax;
            this.YMinValue = yMin;
            this.equation = equationString;
            InitializeComponent1();
            this.Draw();
        }

		private void DrawThreading () {
			if ( this.checkBoxZoomrRecalc.Checked ) {
				
				CalculationFinishedEventArgs calculationResults;
				this.calculate ( out calculationResults );
				if ( CalculationFinished != null ) {
					CalculationFinished ( this , calculationResults );
				}
			}
			this.CreateGraphImage ();
			this.Invalidate ();
			if ( ImageCreated != null ) {
				ImageCreated ();
			}
			//this.ImageCreated ();
		}
        /// <summary>
        /// use it to re-calculate and redraw
        /// if you do not want to re-calculate values-
        /// use Refersh() or Invalidate();
        /// </summary>
        protected void Draw()
        {
			if ( this.RedrawThread != null && this.RedrawThread.IsAlive ) {
				this.RedrawThread.Abort ();
			}
			this.RedrawThread = new Thread ( DrawThreading );
			this.RedrawThread.Start ();
			//DrawThreading ();
        }

		private void RedrawThreading () {

			Stopwatch s = new Stopwatch ();
			s.Start ();
			CalculationFinishedEventArgs calculationResults;
			this.calculate ( out calculationResults );
			if ( CalculationFinished != null ) {
				CalculationFinished ( this , calculationResults );
			}
			s.Stop ();
			s.Restart ();
			this.CreateGraphImage ();
			s.Stop ();
			s.Restart ();
			this.Invalidate ();
			s.Stop ();
			s.Restart ();

			if ( ImageCreated != null ) {
				ImageCreated ();
			}
			//ImageCreated ();
			//this.ImageCreated ();
		}

		
		public void Redraw () {
			if ( this.RedrawThread != null && this.RedrawThread.IsAlive ) {
				this.RedrawThread.Abort ();
			}
			this.RedrawThread = new Thread ( RedrawThreading );
			this.RedrawThread.Start ();
			//RedrawThreading ();
		}

		public void RedrawWithSetAxesData ( List<double> newDataX , List<double> newDataY ) {
			this.dataX = newDataX;
			this.dataY = newDataY;
			this.CreateGraphImage ();
			this.Invalidate ();
		}
        protected virtual void CreateGraphImage()
        {
            this.ImgGraph = new Bitmap(this.Width, this.Height);
            if (this.dataArrayOfArrays.Length > 2)
            {
                
                if (this.GraphHist)
                {
                    int[][] histedArr = this.hist();
                    Graphics g = Graphics.FromImage(this.ImgGraph);
                    for (int i = 0; i < this.dataArrayOfArrays.Length; i++)
                    {
                        for (int j = 0; j < this.countYs; j++)
                        {
                            double yValue = (double)this.YMinValue + j * this.deltaYs;

                            float y = (float)this.UsersToPixel(yValue, Axes.y);
                            float x = (float)this.UsersToPixel((double)this.XMinValue + i * this.deltaXs, Axes.x);

                            if (y < this.Height * 1000 && y > -this.Height * 1000)
                            {
                                int colorVal = histedArr[i][j];
                                if (colorVal > 0)
                                {
                                    Pen p = new Pen(Color.FromArgb(colorVal,0,0,0));
                                    g.DrawEllipse(p, x, y, 1, 1);
                                }
                            }
                        }
                    }
                    g.Save();
                }
                else
                {
                    Graphics g = Graphics.FromImage(this.ImgGraph);
                    for (int i = 0; i < this.dataArrayOfArrays.Length; i++)
                    {
                        for (int j = 0; j < this.dataArrayOfArrays[i].Length; j++)
                        {
                            float y = (float)this.UsersToPixel(this.dataArrayOfArrays[i][j], Axes.y);
                            float x = (float)this.UsersToPixel((double)this.XMinValue + i * this.deltaXs, Axes.x);
                            if (y < this.Height * 1000 && y > -this.Height * 1000)
                                g.DrawEllipse(Pens.Red, x, y, 1, 1);
                        }
                    }
                    g.Save();
                }
                
            }

			
            if (this.Data!=null) {
				
				
				Graphics g = Graphics.FromImage ( this.ImgGraph );
				foreach(var dataVal in this.Data)
				{
					if ( dataVal.dataX.Count != dataVal.dataY.Count )
						continue;

					int delay = dataVal.dataX.Count / 1000;
					if ( delay == 0 ) {
						delay = 1;
					}
					for ( int i = 0 ; i < dataVal.dataX.Count ; i++ ) {
						if ( this.Scatter ) {
							float y = (float) this.UsersToPixel ( dataVal.dataY[i] , Axes.y );
							float x = (float) this.UsersToPixel ( dataVal.dataX[i] , Axes.x );
							if ( y < this.Height * 1000 &&
								y > -this.Height * 1000 &&
								x < this.Width * 1000 &&
								x > -this.Width * 1000 ) {

									g.DrawEllipse ( new Pen ( dataVal.DataColor) , x , y , 1 , 1 );
							} if ( Animate && i % delay == 0 ) {

								Thread.Sleep ( AnimatePeriod );
								g.Save ();
								this.Invalidate ();
							}
						}
						else {
							if ( i == 0 )
								continue;
							float y = (float) this.UsersToPixel ( dataVal.dataY[i] , Axes.y );
							float x = (float) this.UsersToPixel ( dataVal.dataX[i] , Axes.x );
							float yPast = (float) this.UsersToPixel ( dataVal.dataY[i - 1] , Axes.y );
							float xPast = (float) this.UsersToPixel ( dataVal.dataX[i - 1] , Axes.x );
							if ( y < this.Height * 1000 &&
								y > -this.Height * 1000 &&
								yPast > -this.Height * 1000 &&
								yPast < this.Height * 1000 &&
								x < this.Width * 1000 &&
								x > -this.Width * 1000 &&
								xPast > -this.Width * 1000 &&
								xPast < this.Width * 1000
								) {
								PointF p1 = new PointF ( xPast , xPast );
								PointF p2 = new PointF ( x , y );
								g.DrawLine ( new Pen(dataVal.DataColor) , x , y , xPast , yPast );
							}
							if ( Animate && i % delay == 0 ) {

								Thread.Sleep ( AnimatePeriod );
								g.Save ();
								this.Invalidate ();

							}
						}
					}
				}
				g.Save ();
			}
        }

        protected virtual void CreateAxesAndLabelsImage()
        {
            this.ImgAxesAndLabels = new Bitmap(this.Width,this.Height);
            
            Graphics eGraphics = Graphics.FromImage(this.ImgAxesAndLabels);

            eGraphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(new Point(0, 0), this.Size));
            eGraphics.FillRectangle(Brushes.White, new Rectangle(CanvasLocation, CanvasSize));
            if (this.ImgGraph != null)
                eGraphics.DrawImage(this.ImgGraph, new Rectangle(0, 0, this.Width, this.Height));
            if (this.IsAxisVisible)
            {
                int x0Coord = (int)this.UsersToPixel(0, Axes.x);
                int y0Coord = (int)this.UsersToPixel(0, Axes.y);
                if (x0Coord > this.WidthBorderLeft && x0Coord < this.Width - this.WidthBorderRight)
                {
                    eGraphics.DrawLine(Pens.Black, x0Coord, this.HeightBorderUp, x0Coord, this.Height - this.HeightBorderDown);
                    eGraphics.DrawLine(Pens.Black, x0Coord, this.HeightBorderUp, x0Coord + 3, this.HeightBorderUp + 8);
                    eGraphics.DrawLine(Pens.Black, x0Coord, this.HeightBorderUp, x0Coord - 3, this.HeightBorderUp + 8);
                }
                if (y0Coord > this.HeightBorderUp && y0Coord < this.Height - this.HeightBorderDown)
                {
                    eGraphics.DrawLine(Pens.DarkBlue, this.WidthBorderLeft, y0Coord, this.Width - this.WidthBorderRight, (int)y0Coord);
                    eGraphics.DrawLine(Pens.Black, this.Width - this.WidthBorderRight, y0Coord, this.Width - this.WidthBorderRight - 8, y0Coord - 3);
                    eGraphics.DrawLine(Pens.Black, this.Width - this.WidthBorderRight, y0Coord, this.Width - this.WidthBorderRight - 8, y0Coord + 3);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                double deltaX = (this.XMaxValue - this.XMinValue) / 4;
                double deltaY = (this.YMaxValue - this.YMinValue) / 4;
				string xPattern ="0.";
				string yPattern="0.";
				for ( int j = 0 ; j < this.XLabelLength ; j++ ) {
					xPattern += "#";
				}
				for ( int j = 0 ; j < this.XLabelLength ; j++ ) {
					yPattern += "#";
				}

				eGraphics.DrawString ( ( this.YMaxValue - deltaY * i ).ToString ( yPattern ) , Font , Brushes.Black , new PointF ( this.WidthBorderLeft - 34 , ( this.HeightBorderUp - 8 ) + i * ( ( this.Height - this.HeightBorderUp - this.HeightBorderDown ) / 4 ) ) );
                eGraphics.DrawString((this.XMinValue + deltaX * i).ToString(xPattern), Font, Brushes.Black, new PointF((this.WidthBorderLeft - 6) + i * ((this.Width - this.WidthBorderLeft - this.WidthBorderRight) / 4), this.Height - this.HeightBorderDown + 6));

            }
            eGraphics.DrawString(this.AxisXlabel, Font, Brushes.Red, this.Width / 2, this.Height - 15);
            eGraphics.RotateTransform(-90);
            eGraphics.DrawString(this.AxisYlabel, Font, Brushes.Red, -this.Height / 2, 0);
            eGraphics.RotateTransform(90);
 
        }
        /// <summary>
        /// Zoom Out graph for 110 percent
        /// </summary>
        public void zoomOut()
        {
            double deltaX = Math.Abs(this.XMaxValue - this.XMinValue);
            double deltaY = Math.Abs(this.YMaxValue - this.YMinValue);
            deltaY = (deltaY * 1.1 - deltaY) / 2;
            deltaX = (deltaX * 1.1 - deltaX) / 2;
            this.YMinValue -= deltaY;
            this.YMaxValue += deltaY;
            this.XMaxValue += deltaX;
            this.XMinValue -= deltaX;
            this.Draw();
        }
        /// <summary>
        /// Zoom In graph for 110 percent
        /// </summary>
        public void zoomIn()
        {
            double deltaX = Math.Abs(this.XMaxValue - this.XMinValue);
            double deltaY = Math.Abs(this.YMaxValue - this.YMinValue);
            deltaY = (deltaY * 1.1 - deltaY) / 2;
            deltaX = (deltaX * 1.1 - deltaX) / 2;
            if (deltaX != 0 && deltaY != 0)
            {
                this.YMinValue += deltaY;
                this.YMaxValue -= deltaY;
                this.XMaxValue -= deltaX;
                this.XMinValue += deltaX;
                this.Draw();
            }
        }
		public void zoomOut (Axes axes) {
			if ( axes == Axes.x ) {
				double deltaX = Math.Abs ( this.XMaxValue - this.XMinValue );
				deltaX = ( deltaX * 1.1 - deltaX ) / 2;
				this.XMaxValue += deltaX;
				this.XMinValue -= deltaX;
			}
			if ( axes == Axes.y ) {
				double deltaY = Math.Abs ( this.YMaxValue - this.YMinValue );
				deltaY = ( deltaY * 1.1 - deltaY ) / 2;

				this.YMinValue -= deltaY;
				this.YMaxValue += deltaY;
			}
			this.Draw ();
		}
		/// <summary>
		/// Zoom In graph for 110 percent
		/// </summary>
		public void zoomIn (Axes axes) {
			if ( axes == Axes.x ) {
				double deltaX = Math.Abs ( this.XMaxValue - this.XMinValue );
				deltaX = ( deltaX * 1.1 - deltaX ) / 2;
				if(deltaX != 0)
				{
					this.XMaxValue -= deltaX;
					this.XMinValue += deltaX;
					this.Draw ();
				}
			}
			if ( axes == Axes.y ) {
				double deltaY = Math.Abs ( this.YMaxValue - this.YMinValue );
				deltaY = ( deltaY * 1.1 - deltaY ) / 2;

				if ( deltaY != 0 ) {
					this.YMinValue += deltaY;
					this.YMaxValue -= deltaY;
					this.Draw ();
				}
			}
			
		}
        public void moveLeft(double moveValue = 25, MoveAttributes mAttr = MoveAttributes.percents)
        {
            switch (mAttr)
            {
                case MoveAttributes.percents:
                    double deltaMove = this.XMaxValue - this.XMinValue;
                    deltaMove = deltaMove * (moveValue / 100);
                    this.XMinValue -= deltaMove;
                    this.XMaxValue -= deltaMove;
                    break;
                case MoveAttributes.usersCoordinates:
                    this.XMinValue -= moveValue;
                    this.XMaxValue -= moveValue;
                    break;
                default:
                    break;
            }
            this.Draw();
        }
        public void moveRight(double moveValue = 25, MoveAttributes mAttr = MoveAttributes.percents)
        {
            switch (mAttr)
            {
                case MoveAttributes.percents:
                    double deltaMove = this.XMaxValue - this.XMinValue;
                    deltaMove = deltaMove * (moveValue / 100);
                    this.XMinValue += deltaMove;
                    this.XMaxValue += deltaMove;
                    break;
                case MoveAttributes.usersCoordinates:
                    this.XMinValue += moveValue;
                    this.XMaxValue += moveValue;
                    break;
                default:
                    break;
            }
            this.Draw();
        }
        public void moveUp(double moveValue = 25, MoveAttributes mAttr = MoveAttributes.percents)
        {
            switch (mAttr)
            {
                case MoveAttributes.percents:
                    double deltaMove = this.YMaxValue - this.YMinValue;
                    deltaMove = deltaMove * (moveValue / 100);
                    this.YMinValue += deltaMove;
                    this.YMaxValue += deltaMove;
                    break;
                case MoveAttributes.usersCoordinates:
                    this.YMaxValue += moveValue;
                    this.YMinValue += moveValue;
                    break;
                default:
                    break;
            }
            this.Draw();
        }
        public void moveDown(double moveValue = 25, MoveAttributes mAttr = MoveAttributes.percents)
        {
            switch (mAttr)
            {
                case MoveAttributes.percents:
                    double deltaMove = this.YMaxValue - this.YMinValue;
                    deltaMove = deltaMove * (moveValue / 100);
                    this.YMinValue -= deltaMove;
                    this.YMaxValue -= deltaMove;
                    break;
                case MoveAttributes.usersCoordinates:
                    this.YMaxValue -= moveValue;
                    this.YMinValue -= moveValue;
                    break;
                default:
                    break;
            }
            this.Draw();
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
			if ( e.Delta > 0 ) {

				if ( e.X < this.WidthBorderLeft && e.Y < this.Height -this.HeightBorderDown ) {
					this.zoomIn ( Axes.y );
				}
				else {
					if ( e.Y > this.Height - this.HeightBorderDown && e.X > this.WidthBorderLeft ) {
						this.zoomIn ( Axes.x );
					}
					else {

						this.zoomIn ();
					}
				}
			}
			else
				if ( e.X < this.WidthBorderLeft && e.Y <this.Height- this.HeightBorderDown ) {
					this.zoomOut ( Axes.y );
				}
				else {
					if ( e.Y > this.Height - this.HeightBorderDown && e.X > this.WidthBorderLeft ) {
						this.zoomOut ( Axes.x );
					}
					else {

						this.zoomOut ();
					}
				}
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.Focus();
        }
        /// <summary>
        /// Convert pixel coordinate to users
        /// Metod depends of axis, so there is param axis
        /// </summary>
        /// <param name="pixelVal">values you want to convert</param>
        /// <param name="axis">witch axis calculate from enum Axes</param>
        /// <returns>coordinate in users format</returns>
        protected double PixelToUsers(double pixelVal, Axes axis)
        {
            if (axis == Axes.y)
            {
                return ((this.Height - this.HeightBorderUp - this.HeightBorderDown - (pixelVal - this.HeightBorderUp)) * (this.YMaxValue - this.YMinValue) / (this.Height - this.HeightBorderUp - this.HeightBorderDown) + this.YMinValue);
            }
            else
            {
                return (((pixelVal - this.WidthBorderLeft)) * (this.XMaxValue - this.XMinValue) / (this.Width - this.WidthBorderLeft - this.WidthBorderRight) + this.XMinValue);
            }
            
        }
        /// <summary>
        /// Convert users coordinate to pixel
        /// Metod depends of axis, so there is param axis
        /// </summary>
        /// <param name="usersVal">values you want to convert</param>
        /// <param name="axis">witch axis calculate from enum Axes</param>
        /// <returns>coordinate in pixel format</returns>
        protected double UsersToPixel(double usersVal, Axes axis)
        {
            if (axis == Axes.y)
            {
                int graphHeight = this.Height - (this.HeightBorderUp + this.HeightBorderDown);
                double  y = (this.HeightBorderUp + graphHeight) - ((usersVal -
                                                        Convert.ToDouble(this.YMinValue)) /
                                                        (double)(this.YMaxValue - this.YMinValue)) *
                                                        graphHeight;
                return y;
            }
            else
            {
                int graphWidth = this.Width - (this.WidthBorderLeft + this.WidthBorderRight);
                double x = (double)(this.WidthBorderLeft + (usersVal -(double)this.XMinValue) /
                                                                (double)(this.XMaxValue - this.XMinValue) *
                                                                graphWidth);
                return x;
            }
        }
        private void InitializeComponent1()
        {
            if (this.buttonsInited)
                return;
            this.buttonsInited = false;


            int buttonsPosition = 10;
            int deltaButtonPos = 30;
            
            
            this.SuspendLayout();

            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSave.Location = new System.Drawing.Point(this.Width-50, this.Height-20);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(53, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            this.buttonSave.UseVisualStyleBackColor = true;

            this.Controls.Add(this.buttonSave);

            if (this.ZoomButtonsExist)
            {
                this.buttonZoomIn = new System.Windows.Forms.Button();
                this.buttonZoomOut = new System.Windows.Forms.Button();
                // 
                // buttonZoomIn
                // 
                this.buttonZoomIn.Location = new System.Drawing.Point(10, buttonsPosition);
                this.buttonZoomIn.Name = "buttonZoomIn";
                this.buttonZoomIn.Size = new System.Drawing.Size(23, 23);
                this.buttonZoomIn.TabIndex = 0;
                this.buttonZoomIn.Text = "+";
                this.buttonZoomIn.UseVisualStyleBackColor = true;
                this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
                buttonsPosition += deltaButtonPos;
                // 
                // buttonZoomOut
                // 
                this.buttonZoomOut.Location = new System.Drawing.Point(10, buttonsPosition);
                this.buttonZoomOut.Name = "buttonZoomOut";
                this.buttonZoomOut.Size = new System.Drawing.Size(23, 23);
                this.buttonZoomOut.TabIndex = 0;
                this.buttonZoomOut.Text = "-";
                this.buttonZoomOut.UseVisualStyleBackColor = true;
                this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
                buttonsPosition += deltaButtonPos;

                this.Controls.Add(this.buttonZoomIn);
                this.Controls.Add(this.buttonZoomOut);
            }
            if (MoveButtonsExist)
            {
                this.buttonRight = new System.Windows.Forms.Button();
                this.buttonLeft = new System.Windows.Forms.Button();
                this.buttonUp = new System.Windows.Forms.Button();
                this.buttonDown = new System.Windows.Forms.Button();
                // 
                // buttonRight
                // 
                this.buttonRight.Location = new System.Drawing.Point(10, buttonsPosition);
                this.buttonRight.Name = "buttonRight";
                this.buttonRight.Size = new System.Drawing.Size(23, 23);
                this.buttonRight.TabIndex = 0;
                this.buttonRight.Text = "→";
                this.buttonRight.UseVisualStyleBackColor = true;
                this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
                buttonsPosition += deltaButtonPos;
                // 
                // buttonLeft
                // 
                this.buttonLeft.Location = new System.Drawing.Point(10, buttonsPosition);
                this.buttonLeft.Name = "buttonLeft";
                this.buttonLeft.Size = new System.Drawing.Size(23, 23);
                this.buttonLeft.TabIndex = 0;
                this.buttonLeft.Text = "←";
                this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
                this.buttonLeft.UseVisualStyleBackColor = true;
                buttonsPosition += deltaButtonPos;
                // 
                // buttonUp
                // 
                this.buttonUp.Location = new System.Drawing.Point(10, buttonsPosition);
                this.buttonUp.Name = "buttonUp";
                this.buttonUp.Size = new System.Drawing.Size(23, 23);
                this.buttonUp.TabIndex = 0;
                this.buttonUp.Text = "↑";
                this.buttonUp.UseVisualStyleBackColor = true;
                this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
                buttonsPosition += deltaButtonPos;
                // 
                // buttonDown
                // 
                this.buttonDown.Location = new System.Drawing.Point(10, buttonsPosition);
                this.buttonDown.Name = "buttonDown";
                this.buttonDown.Size = new System.Drawing.Size(23, 23);
                this.buttonDown.TabIndex = 0;
                this.buttonDown.Text = "↓";
                this.buttonDown.UseVisualStyleBackColor = true;
                this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
                buttonsPosition += deltaButtonPos;

                this.Controls.Add(this.buttonDown);
                this.Controls.Add(this.buttonUp);
                this.Controls.Add(this.buttonRight);
                this.Controls.Add(this.buttonLeft);
            }
            // 
            // GraphPanel
            // 
            
            
            
            this.ResumeLayout(false);

        }
        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            this.zoomIn();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string path = "D:\\" + DateTime.Now.Minute + ".bmp";

            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //this.img.Save(this.saveFileDialog1.FileName);
                //this.
                this.ImgAxesAndLabels.Save(this.saveFileDialog1.FileName);
            }

            //this.img.Save(path);
        }
        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            this.zoomOut();
        }
        private void buttonRight_Click(object sender, EventArgs e)
        {
            this.moveRight();
        }
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.moveLeft();
        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            this.moveUp();
        }
        private void buttonDown_Click(object sender, EventArgs e)
        {
            this.moveDown();
        }

		private void Graph_Load ( object sender , EventArgs e ) {

		}

		public void zoom100Percent () {
			try {

				if ( this.Data != null ) {

					this.XMinValue = this.Data.Select ( b => b.dataX.
						Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
							.Min () ).ToList ().Min ();

					//this.XMinValue = this.dataX
					//	.Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
					//		.Min ();
					this.XMaxValue = this.Data.Select ( b => b.dataX.
						Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
							.Max () ).ToList ().Max ();
					//this.XMaxValue = this.Data.Select(b=>b.
					//	.Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
					//		.Max ();

					this.YMaxValue = this.Data.Select(b=>b.dataY
						.Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
							.Max ()).ToList().Max();

					this.YMinValue = this.Data.Select(b=>b.dataY
						.Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
							.Min () ).ToList ().Min ();
					this.Draw ();
					
				}
			}
			catch {
			}
		}

		private void button100Percent_Click ( object sender , EventArgs e ) {
			zoom100Percent ();
		}

		

		public Bitmap GetImage () {
			//if ( this.RedrawThread.ThreadState != System.Threading.ThreadState.Stopped ) {
			
			//}
			return this.ImgAxesAndLabels;
			//return null;
		}

		public delegate void ImageCreatedDelegate();
		
		public event ImageCreatedDelegate ImageCreated;

		public event CalculationFinishedHandler CalculationFinished;

		private void Graph_SizeChanged ( object sender , EventArgs e ) {
			this.CanvasSize = new Size ( this.Width - ( this.WidthBorderLeft + this.WidthBorderRight ) , this.Height - ( this.HeightBorderUp + this.HeightBorderDown ) );
			this.button100Percent.Location = new System.Drawing.Point ( -9 , this.Height - 20 );
			try {
				this.checkBoxZoomrRecalc.Location = new Point ( 200 , this.Height - 20 );
				this.buttonSave.Location = new Point ( this.Width - 50 , this.Height - 20 );



			}
			catch ( Exception ex ) {
			}
		}
    }
    
    
}
