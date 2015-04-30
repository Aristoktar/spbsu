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
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Graph {

	public delegate void CalculationProgress(int percent);
	public partial class Graph2 : UserControl {

		

		/// <summary>
		/// Gets or sets a value indicating whether the Axes are displayed.
		/// </summary>\
		public bool IsAxisVisible {
			get;
			set;
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Zoom buttons are displayed.
		/// </summary>
		public bool ZoomButtonsExist {
			get;
			set;
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Zoom buttons are displayed.
		/// </summary>
		public bool MoveButtonsExist {
			get;
			set;
		}
		
		/// <summary>
		/// axis x label
		/// </summary>
		public string AxisXlabel {
			get;
			set;
		}
		
		/// <summary>
		/// axis Y label
		/// </summary>
		public string AxisYlabel {
			get;
			set;
		}

		public bool Scatter {
			get;
			set;
		}

		#region Canvas Properties

		protected Point CanvasLocation;
		protected Size CanvasSize;
		
		protected int HeightBorderUp = 10;
		protected int HeightBorderDown = 45;
		protected int WidthBorderLeft = 70;
		protected int WidthBorderRight = 10; 
		#endregion

		protected bool IsDataTrimmVisible = false;

		protected int MouseX;
		protected int MouseY;

		protected List<PointF> ZoomBoxList;

		protected double XMinValue {
			get;
			set;
		}
		protected double XMaxValue {
			get;
			set;
		}
		protected double YMinValue {
			get;
			set;
		}
		protected double YMaxValue {
			get;
			set;
		}

		private Thread CalculationThread;

		public Dictionary<string , ObservableCollection<double>> Data {
			get;
			set;
		}

		public int DrawnPoints {
			get;
			set;
		}

		protected Bitmap ImgGraph {
			get;
			set;
		}
		protected Bitmap ImgAxesAndLabels {
			get;
			set;
		}

		public Graph2 () {

			InitializeComponent ();
			AxisXlabel = "x";
			AxisYlabel = "y";
			this.InitializeComponent ();
			this.AxisXlabel = "x";
			this.AxisYlabel = "y";
			this.IsAxisVisible = true;
			this.MoveButtonsExist = true;
			this.ZoomButtonsExist = true;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.CanvasLocation = new Point ( WidthBorderLeft , HeightBorderUp );
			this.CanvasSize = new Size ( this.Width - ( this.WidthBorderLeft + this.WidthBorderRight ) , this.Height - ( this.HeightBorderUp + this.HeightBorderDown ) );

			this.ZoomBoxList = new List<PointF> ();
			//Allow UserControl children class use property DoubleBuffered - for correct drawing
			typeof ( Control ).GetProperty (
				"DoubleBuffered" ,
				BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty
				).SetValue ( this , true , null );

			this.DrawRecalc ();
		}

		protected override void OnSizeChanged ( EventArgs e ) {
			this.CanvasSize = new Size ( this.Width - ( this.WidthBorderLeft + this.WidthBorderRight ) , this.Height - ( this.HeightBorderUp + this.HeightBorderDown ) );
		}

		protected override void OnPaint ( PaintEventArgs e ) {

			this.CreateAxesAndLabelsImage ();
			e.Graphics.DrawImage ( this.ImgAxesAndLabels , new Rectangle ( 0 , 0 , this.Width , this.Height ) );

			if ( this.IsDataTrimmVisible ) {
				if ( !( MouseX < this.WidthBorderLeft || MouseX > this.Width - this.WidthBorderRight ) ) {
					if ( !( MouseY < this.HeightBorderUp || MouseY > this.Height - this.HeightBorderDown ) ) {
						e.Graphics.DrawLine ( Pens.DarkBlue , this.WidthBorderLeft , MouseY , this.Width - this.WidthBorderRight , MouseY );
						e.Graphics.DrawLine ( Pens.DarkBlue , MouseX , this.HeightBorderUp , MouseX , this.Height - this.HeightBorderDown );
						decimal x = (decimal) ( ( (decimal) this.MouseX - this.WidthBorderLeft ) * (decimal) ( this.XMaxValue - this.XMinValue ) / ( this.Width - this.WidthBorderLeft - this.WidthBorderRight ) + (decimal) this.XMinValue );
						decimal y = (decimal) ( ( this.Height - this.HeightBorderUp - this.HeightBorderDown - ( (decimal) this.MouseY - this.HeightBorderUp ) ) * (decimal) ( this.YMaxValue - this.YMinValue ) / ( this.Height - this.HeightBorderUp - this.HeightBorderDown ) + (decimal) this.YMinValue );

						e.Graphics.DrawString ( x.ToString ( "0.####" ) , Font , Brushes.Black , new Point ( MouseX , this.HeightBorderUp ) );

						e.Graphics.DrawString ( y.ToString ( "0.####" ) , Font , Brushes.Black , new Point ( this.WidthBorderLeft , MouseY ) );
					}
				}
			}
			if ( this.ZoomBoxList.Count > 1 ) {
				e.Graphics.DrawLine ( Pens.Black , new PointF ( ZoomBoxList[0].X , ZoomBoxList[0].Y ) , new PointF ( ZoomBoxList[0].X , ZoomBoxList[ZoomBoxList.Count - 1].Y ) );
				e.Graphics.DrawLine ( Pens.Black , new PointF ( ZoomBoxList[ZoomBoxList.Count - 1].X , ZoomBoxList[ZoomBoxList.Count - 1].Y ) , new PointF ( ZoomBoxList[0].X , ZoomBoxList[ZoomBoxList.Count - 1].Y ) );
				e.Graphics.DrawLine ( Pens.Black , new PointF ( ZoomBoxList[0].X , ZoomBoxList[0].Y ) , new PointF ( ZoomBoxList[ZoomBoxList.Count - 1].X , ZoomBoxList[0].Y ) );
				e.Graphics.DrawLine ( Pens.Black , new PointF ( ZoomBoxList[ZoomBoxList.Count - 1].X , ZoomBoxList[0].Y ) , new PointF ( ZoomBoxList[ZoomBoxList.Count - 1].X , ZoomBoxList[ZoomBoxList.Count - 1].Y ) );
			}


		}
		protected override void OnMouseDown ( MouseEventArgs e ) {
			if ( !this.IsDataTrimmVisible && e.Button == MouseButtons.Middle ) {
				this.MouseX = e.X;
				this.MouseY = e.Y;
				this.IsDataTrimmVisible = true;
			}
			else {
				if ( this.IsDataTrimmVisible && ( e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right ) ) {
					this.IsDataTrimmVisible = false;

				}
			}
			base.OnMouseDown ( e );
		}
		protected override void OnMouseUp ( MouseEventArgs e ) {
			if ( this.ZoomBoxList.Count < 1 ) {
				this.ZoomBoxList = new List<PointF> ();
				this.DrawContinue ();
				return;
			}
			float minDelta = 7;//px
			double minDeltaUsers = 0.0000001;
			float xMax;
			float yMax;
			float xMin;
			float yMin;

			float[] Xs = new float[2];
			float[] Ys = new float[2];

			Xs[0] = ZoomBoxList.First().X;
			Ys[0] = ZoomBoxList.First().Y;
			Xs[1] = ZoomBoxList.Last().X;
			Ys[1] = ZoomBoxList.Last().Y;

			xMax = Xs.Max ();
			yMax = Ys.Min ();
			xMin = Xs.Min ();
			yMin = Ys.Max ();
			if ( xMax - xMin < minDelta || yMin - yMax < minDelta ) {
				this.ZoomBoxList = new List<PointF> ();
				
				return;
			}

			double yStart = this.PixelToUsers ( yMin , Axes.y );
			double yEnd = this.PixelToUsers ( yMax , Axes.y );
			double xStart = this.PixelToUsers ( xMin , Axes.x );
			double xEnd = this.PixelToUsers ( xMax , Axes.x );
			if ( Math.Abs ( yEnd - yStart ) < minDeltaUsers || Math.Abs ( xEnd - xStart ) < minDeltaUsers ) {
				this.ZoomBoxList = new List<PointF> ();
				MessageBox.Show ( "reached maximun zoom" );
				return;
			}
			this.YMaxValue = yEnd;
			this.YMinValue = yStart;
			this.XMaxValue = xEnd;
			this.XMinValue = xStart;
			this.ZoomBoxList = new List<PointF> ();

			this.DrawContinue ();
		}

		/// <summary>
		/// you have to redefine this method co calculate
		/// values for graph if you what to use
		/// not analitic function
		/// </summary>
		protected virtual void Calculate () {
			//if ( !string.IsNullOrWhiteSpace ( this.equation ) ) {
			//	this.countXs = 100;
			//	this.deltaXs = (double) ( this.XMaxValue - this.XMinValue ) / this.countXs;

			//	treeParse.treeParse tree = new treeParse.treeParse ( this.equation );
			//	tree.init ();

			//	this.dataX = new double[0];
			//	this.dataY = new double[0];
			//	var timer = Stopwatch.StartNew ();

			//	for ( int i = 0 ; i <= this.countXs ; i++ ) {
			//		double dtemp = (double) this.XMinValue + deltaXs * i;
			//		double tempt = tree.calculate ( "x" , dtemp );

			//		Array.Resize<double> ( ref this.dataX , this.dataX.Length + 1 );
			//		Array.Resize<double> ( ref this.dataY , this.dataY.Length + 1 );
			//		this.dataX[this.dataX.Length - 1] = dtemp;
			//		this.dataY[this.dataY.Length - 1] = tempt;
			//	}
			//	timer.Stop ();
				//MessageBox.Show(timer.Elapsed.ToString());

			//}
			double temp = 0;
			Data["x"].Clear(  );
			Data["y"].Clear();
			for(int i=0; i<1000000;i++) {
				
				Data["x"].Add (temp);
				Data["y"].Add ( Math.Sin(i) );
				temp+=0.01;
			}
			zoom100Percent ();
		}

		public void CalculationThreading () {
			this.Data = new Dictionary<string , ObservableCollection<double>> ();
			this.Data.Add ( this.AxisXlabel , new ObservableCollection<double> () );
			this.Data.Add ( this.AxisYlabel , new ObservableCollection<double> () );
			this.Data[this.AxisXlabel].CollectionChanged += Data_Add;
			this.DrawnPoints = 0;
			this.Calculate ();
			this.DrawContinue ();
			this.Invalidate ();
		}

		private void Data_Add ( object sender , System.Collections.Specialized.NotifyCollectionChangedEventArgs e ) {
			
			if ( e.Action == NotifyCollectionChangedAction.Add ) {
				if(this.Data[this.AxisXlabel].Count%10000==0) {

					this.DrawnPoints = this.Data[this.AxisXlabel].Count;
				
					this.DrawContinue ();
				}
			}
		}

		public void DrawRecalc () {
			if ( this.CalculationThread != null && this.CalculationThread.IsAlive ) {
				this.CalculationThread.Abort ();
			}
			this.CalculationThread = new Thread (this.CalculationThreading);
			this.CalculationThread.Start ();
		}
		public void DrawContinue () {
			this.CreateGraphImage ();
			this.Invalidate ();
		}

		public void ZoomRedraw () {
			this.DrawnPoints = 0;
			this.CreateGraphImage ();
			this.Invalidate ();
		}
		protected virtual void CreateGraphImage () {
			

			if ( this.Data != null ) {
				if ( this.DrawnPoints == 0 ) {
					this.ImgGraph = new Bitmap ( this.Width , this.Height );
				}
				if ( this.Data[this.AxisYlabel].Count != this.Data[this.AxisXlabel].Count )
					return;
				Graphics g = Graphics.FromImage ( this.ImgGraph );
				//g.DrawImage ( ttyt , new Point ( 0 , 0 ) );
				for ( int i = 0 ; i < this.Data[this.AxisXlabel].Count ; i++ ) {
					if ( this.Scatter ) {
						float y = (float) this.UsersToPixel ( this.Data[this.AxisYlabel][i] , Axes.y );
						float x = (float) this.UsersToPixel ( this.Data[this.AxisXlabel][i] , Axes.x );
						if ( y < this.Height * 1000 &&
							y > -this.Height * 1000 &&
							x < this.Width * 1000 &&
							x > -this.Width * 1000 ) {

							g.DrawEllipse ( Pens.Blue , x , y , 1 , 1 );
						}
					}
					else {
						if ( i == 0 )
							continue;
						float y = (float) this.UsersToPixel ( this.Data[this.AxisYlabel][i] , Axes.y );
						float x = (float) this.UsersToPixel ( this.Data[this.AxisXlabel][i] , Axes.x );
						float yPast = (float) this.UsersToPixel ( this.Data[this.AxisYlabel][i - 1] , Axes.y );
						float xPast = (float) this.UsersToPixel ( this.Data[this.AxisXlabel][i - 1] , Axes.x );
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
							g.DrawLine ( Pens.Blue , x , y , xPast , yPast );
						}
					}
				}
				g.Save ();
			}
		}
		protected virtual void CreateAxesAndLabelsImage () {
			this.ImgAxesAndLabels = new Bitmap ( this.Width , this.Height );

			Graphics eGraphics = Graphics.FromImage ( this.ImgAxesAndLabels );

			eGraphics.FillRectangle ( new SolidBrush ( this.BackColor ) , new Rectangle ( new Point ( 0 , 0 ) , this.Size ) );
			eGraphics.FillRectangle ( Brushes.White , new Rectangle ( CanvasLocation , CanvasSize ) );
			if ( this.ImgGraph != null )
				eGraphics.DrawImage ( this.ImgGraph , new Rectangle ( 0 , 0 , this.Width , this.Height ) );
			if ( this.IsAxisVisible ) {
				int x0Coord = (int) this.UsersToPixel ( 0 , Axes.x );
				int y0Coord = (int) this.UsersToPixel ( 0 , Axes.y );
				if ( x0Coord > this.WidthBorderLeft && x0Coord < this.Width - this.WidthBorderRight ) {
					eGraphics.DrawLine ( Pens.Black , x0Coord , this.HeightBorderUp , x0Coord , this.Height - this.HeightBorderDown );
					eGraphics.DrawLine ( Pens.Black , x0Coord , this.HeightBorderUp , x0Coord + 3 , this.HeightBorderUp + 8 );
					eGraphics.DrawLine ( Pens.Black , x0Coord , this.HeightBorderUp , x0Coord - 3 , this.HeightBorderUp + 8 );
				}
				if ( y0Coord > this.HeightBorderUp && y0Coord < this.Height - this.HeightBorderDown ) {
					eGraphics.DrawLine ( Pens.DarkBlue , this.WidthBorderLeft , y0Coord , this.Width - this.WidthBorderRight , (int) y0Coord );
					eGraphics.DrawLine ( Pens.Black , this.Width - this.WidthBorderRight , y0Coord , this.Width - this.WidthBorderRight - 8 , y0Coord - 3 );
					eGraphics.DrawLine ( Pens.Black , this.Width - this.WidthBorderRight , y0Coord , this.Width - this.WidthBorderRight - 8 , y0Coord + 3 );
				}
			}
			for ( int i = 0 ; i < 5 ; i++ ) {
				double deltaX = ( this.XMaxValue - this.XMinValue ) / 4;
				double deltaY = ( this.YMaxValue - this.YMinValue ) / 4;
				eGraphics.DrawString ( ( this.YMaxValue - deltaY * i ).ToString ( "0.###" ) , Font , Brushes.Black , new PointF ( this.WidthBorderLeft - 34 , ( this.HeightBorderUp - 8 ) + i * ( ( this.Height - this.HeightBorderUp - this.HeightBorderDown ) / 4 ) ) );
				eGraphics.DrawString ( ( this.XMinValue + deltaX * i ).ToString ( "0.###" ) , Font , Brushes.Black , new PointF ( ( this.WidthBorderLeft - 6 ) + i * ( ( this.Width - this.WidthBorderLeft - this.WidthBorderRight ) / 4 ) , this.Height - this.HeightBorderDown + 6 ) );

			}
			eGraphics.DrawString ( this.AxisXlabel , Font , Brushes.Red , this.Width / 2 , this.Height - 15 );
			eGraphics.RotateTransform ( -90 );
			eGraphics.DrawString ( this.AxisYlabel , Font , Brushes.Red , -this.Height / 2 , 0 );
			eGraphics.RotateTransform ( 90 );

		}
		/// <summary>
		/// Convert pixel coordinate to users
		/// Metod depends of axis, so there is param axis
		/// </summary>
		/// <param name="pixelVal">values you want to convert</param>
		/// <param name="axis">witch axis calculate from enum Axes</param>
		/// <returns>coordinate in users format</returns>
		protected double PixelToUsers ( double pixelVal , Axes axis ) {
			if ( axis == Axes.y ) {
				return ( ( this.Height - this.HeightBorderUp - this.HeightBorderDown - ( pixelVal - this.HeightBorderUp ) ) * ( this.YMaxValue - this.YMinValue ) / ( this.Height - this.HeightBorderUp - this.HeightBorderDown ) + this.YMinValue );
			}
			else {
				return ( ( ( pixelVal - this.WidthBorderLeft ) ) * ( this.XMaxValue - this.XMinValue ) / ( this.Width - this.WidthBorderLeft - this.WidthBorderRight ) + this.XMinValue );
			}

		}
		/// <summary>
		/// Convert users coordinate to pixel
		/// Metod depends of axis, so there is param axis
		/// </summary>
		/// <param name="usersVal">values you want to convert</param>
		/// <param name="axis">witch axis calculate from enum Axes</param>
		/// <returns>coordinate in pixel format</returns>
		protected double UsersToPixel ( double usersVal , Axes axis ) {
			if ( axis == Axes.y ) {
				int graphHeight = this.Height - ( this.HeightBorderUp + this.HeightBorderDown );
				double y = ( this.HeightBorderUp + graphHeight ) - ( ( usersVal -
														Convert.ToDouble ( this.YMinValue ) ) /
														(double) ( this.YMaxValue - this.YMinValue ) ) *
														graphHeight;
				return y;
			}
			else {
				int graphWidth = this.Width - ( this.WidthBorderLeft + this.WidthBorderRight );
				double x = (double) ( this.WidthBorderLeft + ( usersVal - (double) this.XMinValue ) /
																(double) ( this.XMaxValue - this.XMinValue ) *
																graphWidth );
				return x;
			}
		}

		public void zoom100Percent () {
			try {

				if ( this.Data[this.AxisXlabel] != null && this.Data[this.AxisYlabel] != null ) {

					this.XMinValue = this.Data[this.AxisXlabel]
						.Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
							.Min ();
					this.XMaxValue = this.Data[this.AxisXlabel]
						.Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
							.Max ();

					this.YMaxValue = this.Data[this.AxisYlabel]
						.Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
							.Max ();
					this.YMinValue = this.Data[this.AxisYlabel]
						.Where ( a => !( Double.IsInfinity ( a ) || Double.IsNaN ( a ) ) && ( a < Int16.MaxValue ) && ( a > Int16.MinValue ) )
							.Min ();
					this.ZoomRedraw ();
				}
			}
			catch {
			}
		}

		private void Graph2_MouseEnter ( object sender , EventArgs e ) {
			this.Focus ();
		}
	}
}
