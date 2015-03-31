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
        public string axisXlabel
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
        public string axisYlabel
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
        public bool graphHist { get; set; }
        public bool scatterGraph { get; set; }


        protected Point point1;
        protected Size size1;
        protected int heightBorderUp = 10;
        protected int heightBorderDown = 45;
        protected int widthBorderLeft = 70;
        protected int widthBorderRight = 10;
        
        protected bool isDataTrimmVisible = false;

        protected int mouseX;
        protected int mouseY;

        protected double xMinValue;
        protected double xMaxValue;
        protected double yMinValue;
        protected double yMaxValue;
        protected List<PointF> zoomList;
        protected Bitmap imgGraph;
        protected Bitmap imgAxesAndLabels;
        protected Bitmap imgOut;
        

        protected double[][] dataArrayOfArrays;
        protected double[] dataY;
        protected double[] dataX;
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

        public Graph()
        {
            this.InitializeComponent();
            this.axisXlabel = "x";
            this.axisYlabel = "y";
            this.IsAxisVisible = true;
            this.MoveButtonsExist = true;
            this.ZoomButtonsExist = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.point1 = new Point(widthBorderLeft, heightBorderUp);
            this.size1 = new Size(this.Width - (this.widthBorderLeft + this.widthBorderRight), this.Height - (this.heightBorderUp + this.heightBorderDown));
            typeof(Control).GetProperty(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty
                ).SetValue(this, true, null);
            zoomList = new List<PointF>();
            this.dataArrayOfArrays = new double[0][];
        }

        /// <summary>
        /// you have to redefine this method co calculate
        /// values for graph if you what to use
        /// not analitic function
        /// </summary>
        protected virtual void calculate()
        {
            if (!string.IsNullOrWhiteSpace(this.equation))
            {
                this.countXs = 100;
                this.deltaXs = (double)(this.xMaxValue - this.xMinValue) / this.countXs;

                treeParse.treeParse tree = new treeParse.treeParse(this.equation);
                tree.init();

                this.dataX = new double[0];
                this.dataY = new double[0];
                var timer = Stopwatch.StartNew();

                for (int i = 0; i <= this.countXs; i++)
                {
                    double dtemp = (double)this.xMinValue + deltaXs * i;
                    double tempt = tree.calculate("x",dtemp);

                    Array.Resize<double>(ref this.dataX, this.dataX.Length + 1);
                    Array.Resize<double>(ref this.dataY, this.dataY.Length + 1);
                    this.dataX[this.dataX.Length - 1] = dtemp;
                    this.dataY[this.dataY.Length - 1] = tempt;
                }
                timer.Stop();
                //MessageBox.Show(timer.Elapsed.ToString());

            }
        }

        protected int[][] hist()
        {           
            int[][] histARR = new int[this.countXs][];
            this.deltaYs = (double)(this.yMaxValue - this.yMinValue) / this.countYs;
            for (int i = 0; i < countXs; i++)
            {
                int[] histTempArr = new int[this.countYs];
                int max = 0;
                for (int j = 0; j < this.countYs; j++)
                {
                    double dtemp = (double)this.yMinValue + deltaYs * j;
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
            
            //e.Graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(new Point(0, 0), this.Size));
            //e.Graphics.FillRectangle(Brushes.White, new Rectangle(point1, size1));

            this.createAxesAndLabelsImage();
            e.Graphics.DrawImage(this.imgAxesAndLabels, new Rectangle(0, 0, this.Width, this.Height));
            
            /*
            if (this.IsAxisVisible)
            {
                int x0Coord = (int)this.UsersToPixel(0, Axes.x);
                int y0Coord = (int)this.UsersToPixel(0, Axes.y);
                if (x0Coord > this.widthBorderLeft && x0Coord < this.Width - this.widthBorderRight)
                {
                    e.Graphics.DrawLine(Pens.Black, x0Coord, this.heightBorderUp, x0Coord, this.Height - this.heightBorderDown);
                    e.Graphics.DrawLine(Pens.Black, x0Coord, this.heightBorderUp, x0Coord + 3, this.heightBorderUp + 8);
                    e.Graphics.DrawLine(Pens.Black, x0Coord, this.heightBorderUp, x0Coord - 3, this.heightBorderUp + 8);
                }
                if (y0Coord > this.heightBorderUp && y0Coord < this.Height - this.heightBorderDown)
                {
                    e.Graphics.DrawLine(Pens.DarkBlue, this.widthBorderLeft, y0Coord, this.Width - this.widthBorderRight, (int)y0Coord);
                    e.Graphics.DrawLine(Pens.Black, this.Width - this.widthBorderRight, y0Coord, this.Width - this.widthBorderRight - 8, y0Coord - 3);
                    e.Graphics.DrawLine(Pens.Black, this.Width - this.widthBorderRight, y0Coord, this.Width - this.widthBorderRight - 8, y0Coord + 3);
                }
            }*/
            if (this.isDataTrimmVisible)
            {
                if (!(mouseX < this.widthBorderLeft || mouseX > this.Width - this.widthBorderRight))
                {
                    if (!(mouseY < this.heightBorderUp || mouseY > this.Height - this.heightBorderDown))
                    {
                        e.Graphics.DrawLine(Pens.DarkBlue, this.widthBorderLeft, mouseY, this.Width - this.widthBorderRight, mouseY);
                        e.Graphics.DrawLine(Pens.DarkBlue, mouseX, this.heightBorderUp, mouseX, this.Height - this.heightBorderDown);
                        decimal x = (decimal)(((decimal)this.mouseX - this.widthBorderLeft) * (decimal)(this.xMaxValue - this.xMinValue) / (this.Width - this.widthBorderLeft - this.widthBorderRight) + (decimal)this.xMinValue);
                        decimal y = (decimal)((this.Height - this.heightBorderUp - this.heightBorderDown - ((decimal)this.mouseY - this.heightBorderUp)) * (decimal)(this.yMaxValue - this.yMinValue) / (this.Height - this.heightBorderUp - this.heightBorderDown) + (decimal)this.yMinValue);

                        e.Graphics.DrawString(x.ToString("0.####"), Font, Brushes.Black, new Point(mouseX, this.heightBorderUp));

                        e.Graphics.DrawString(y.ToString("0.####"), Font, Brushes.Black, new Point(this.widthBorderLeft, mouseY));
                    }
                }
            }
            if (this.zoomList.Count > 1)
            {
                e.Graphics.DrawLine(Pens.Black, new PointF(zoomList[0].X, zoomList[0].Y), new PointF(zoomList[0].X, zoomList[zoomList.Count - 1].Y));
                e.Graphics.DrawLine(Pens.Black, new PointF(zoomList[zoomList.Count - 1].X, zoomList[zoomList.Count - 1].Y), new PointF(zoomList[0].X, zoomList[zoomList.Count - 1].Y));
                e.Graphics.DrawLine(Pens.Black, new PointF(zoomList[0].X, zoomList[0].Y), new PointF(zoomList[zoomList.Count - 1].X, zoomList[0].Y));
                e.Graphics.DrawLine(Pens.Black, new PointF(zoomList[zoomList.Count - 1].X, zoomList[0].Y), new PointF(zoomList[zoomList.Count - 1].X, zoomList[zoomList.Count - 1].Y));
            }
            
            /*
            for (int i = 0; i < 5; i++)
            {
                double deltaX = (this.xMaxValue - this.xMinValue) / 4;
                double deltaY = (this.yMaxValue - this.yMinValue) / 4;
                e.Graphics.DrawString((this.yMaxValue - deltaY * i).ToString("0.###"), Font, Brushes.Black, new PointF(this.widthBorderLeft - 34, (this.heightBorderUp - 8) + i * ((this.Height - this.heightBorderUp - this.heightBorderDown) / 4)));
                e.Graphics.DrawString((this.xMinValue + deltaX * i).ToString("0.###"), Font, Brushes.Black, new PointF((this.widthBorderLeft - 6) + i * ((this.Width - this.widthBorderLeft - this.widthBorderRight) / 4), this.Height - this.heightBorderDown + 6));

            }
            
            e.Graphics.DrawString(this.axisXlabel, Font, Brushes.Red, this.Width / 2, this.Height - 15);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString(this.axisYlabel, Font, Brushes.Red, -this.Height / 2, 0);
            e.Graphics.RotateTransform(90);*/
            
            
           /* e.Graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(new Point(0, 0), this.Size));
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(point1, size1));
            if (this.img != null)
                e.Graphics.DrawImage(this.img, new Rectangle(0, 0, this.Width, this.Height));

            if (this.IsAxisVisible)
            {
                int x0Coord = (int)this.UsersToPixel(0, Axes.x);
                int y0Coord = (int)this.UsersToPixel(0, Axes.y);
                if (x0Coord > this.widthBorderLeft && x0Coord < this.Width - this.widthBorderRight)
                {
                    e.Graphics.DrawLine(Pens.Black, x0Coord, this.heightBorderUp, x0Coord, this.Height - this.heightBorderDown);
                    e.Graphics.DrawLine(Pens.Black, x0Coord, this.heightBorderUp, x0Coord + 3, this.heightBorderUp + 8);
                    e.Graphics.DrawLine(Pens.Black, x0Coord, this.heightBorderUp, x0Coord - 3, this.heightBorderUp + 8);
                }
                if (y0Coord > this.heightBorderUp && y0Coord < this.Height - this.heightBorderDown)
                {
                    e.Graphics.DrawLine(Pens.DarkBlue, this.widthBorderLeft, y0Coord, this.Width - this.widthBorderRight, (int)y0Coord);
                    e.Graphics.DrawLine(Pens.Black, this.Width - this.widthBorderRight, y0Coord, this.Width - this.widthBorderRight - 8, y0Coord - 3);
                    e.Graphics.DrawLine(Pens.Black, this.Width - this.widthBorderRight, y0Coord, this.Width - this.widthBorderRight - 8, y0Coord + 3);
                }
            }
            if (this.isDataTrimmVisible)
            {
                if (!(mouseX < this.widthBorderLeft || mouseX > this.Width - this.widthBorderRight))
                {
                    if (!(mouseY < this.heightBorderUp || mouseY > this.Height - this.heightBorderDown))
                    {
                        e.Graphics.DrawLine(Pens.DarkBlue, this.widthBorderLeft, mouseY, this.Width - this.widthBorderRight, mouseY);
                        e.Graphics.DrawLine(Pens.DarkBlue, mouseX, this.heightBorderUp, mouseX, this.Height - this.heightBorderDown);
                        decimal x = (decimal)(((decimal)this.mouseX - this.widthBorderLeft) * (decimal)(this.xMaxValue - this.xMinValue) / (this.Width - this.widthBorderLeft - this.widthBorderRight) + (decimal)this.xMinValue);
                        decimal y = (decimal)((this.Height - this.heightBorderUp - this.heightBorderDown - ((decimal)this.mouseY - this.heightBorderUp)) * (decimal)(this.yMaxValue - this.yMinValue) / (this.Height - this.heightBorderUp - this.heightBorderDown) + (decimal)this.yMinValue);

                        e.Graphics.DrawString(x.ToString("0.####"), Font, Brushes.Black, new Point(mouseX, this.heightBorderUp));

                        e.Graphics.DrawString(y.ToString("0.####"), Font, Brushes.Black, new Point(this.widthBorderLeft, mouseY));
                    }
                }
            }
            if (this.zoomList.Count > 1)
            {
                e.Graphics.DrawLine(Pens.Black, new PointF(zoomList[0].X, zoomList[0].Y), new PointF(zoomList[0].X, zoomList[zoomList.Count - 1].Y));
                e.Graphics.DrawLine(Pens.Black, new PointF(zoomList[zoomList.Count - 1].X, zoomList[zoomList.Count - 1].Y), new PointF(zoomList[0].X, zoomList[zoomList.Count - 1].Y));
                e.Graphics.DrawLine(Pens.Black, new PointF(zoomList[0].X, zoomList[0].Y), new PointF(zoomList[zoomList.Count - 1].X, zoomList[0].Y));
                e.Graphics.DrawLine(Pens.Black, new PointF(zoomList[zoomList.Count - 1].X, zoomList[0].Y), new PointF(zoomList[zoomList.Count - 1].X, zoomList[zoomList.Count - 1].Y));
            }
            for (int i = 0; i < 5; i++)
            {
                double deltaX = (this.xMaxValue - this.xMinValue) / 4;
                double deltaY = (this.yMaxValue - this.yMinValue) / 4;
                e.Graphics.DrawString((this.yMaxValue - deltaY * i).ToString("0.###"), Font, Brushes.Black, new PointF(this.widthBorderLeft - 34, (this.heightBorderUp - 8) + i * ((this.Height - this.heightBorderUp - this.heightBorderDown) / 4)));
                e.Graphics.DrawString((this.xMinValue + deltaX * i).ToString("0.###"), Font, Brushes.Black, new PointF((this.widthBorderLeft - 6) + i * ((this.Width - this.widthBorderLeft - this.widthBorderRight) / 4), this.Height - this.heightBorderDown + 6));

            }
           e.Graphics.DrawString(this.axisXlabel, Font, Brushes.Red, this.Width / 2, this.Height - 15);
           e.Graphics.RotateTransform(-90);
           e.Graphics.DrawString(this.axisYlabel, Font, Brushes.Red, -this.Height/2, 0);
           e.Graphics.RotateTransform(90);
           this.imgOut = new Bitmap(this.Width,this.Height,e.Graphics);
            * */
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            this.size1 = new Size(this.Width - (this.widthBorderLeft + this.widthBorderRight), this.Height - (this.heightBorderUp + this.heightBorderDown));
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            
            if (this.isDataTrimmVisible)
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;
            }
            if (MouseButtons.Left == e.Button)
            {
                if (!(e.X < this.widthBorderLeft || e.X > this.Width - this.widthBorderRight))
                {
                    if (!(e.Y < this.heightBorderUp || e.Y > this.Height - this.heightBorderDown))
                    {
                        zoomList.Add(new PointF(e.X, e.Y));
                    }
                }
            }
            this.Refresh();
           // base.OnMouseMove(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!this.isDataTrimmVisible && e.Button == MouseButtons.Middle)
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;
                this.isDataTrimmVisible = true;
            }
            else
            {
                if (this.isDataTrimmVisible && (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right))
                {
                    this.isDataTrimmVisible = false;

                }
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.zoomList.Count < 1)
            {
                this.zoomList = new List<PointF>();
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
            Xs[0] = zoomList[0].X;
            Ys[0] = zoomList[0].Y;
            Xs[1] = zoomList[zoomList.Count - 1].X;
            Ys[1] = zoomList[zoomList.Count - 1].Y;
            xMax = Xs.Max();
            yMax = Ys.Min();
            xMin = Xs.Min();
            yMin = Ys.Max();
            if (xMax - xMin < minDelta || yMin - yMax < minDelta)
            {
                this.zoomList = new List<PointF>();
                return;
            }
            

            double yStart = this.PixelToUsers(yMin, Axes.y);
            double yEnd = this.PixelToUsers(yMax, Axes.y);
            double xStart = this.PixelToUsers(xMin, Axes.x);
            double xEnd = this.PixelToUsers(xMax, Axes.x);
            if (yEnd - yStart < minDeltaUsers || xEnd - xStart < minDeltaUsers)
            {
                this.zoomList = new List<PointF>();
                MessageBox.Show("reached maximun zoom");
                return;
            }
            this.yMaxValue = yEnd;
            this.yMinValue = yStart;
            this.xMaxValue = xEnd;
            this.xMinValue = xStart;
            this.zoomList = new List<PointF>();
            
            this.draw();
        }
        public void setData(double xMax, double xMin, double yMax, double yMin, string equationString = "")
        {
            this.xMaxValue = xMax;
            this.xMinValue = xMin;
            this.yMaxValue = yMax;
            this.yMinValue = yMin;
            this.equation = equationString;
            InitializeComponent1();
            this.draw();
        }
        /// <summary>
        /// use it to re-calculate and redraw
        /// if you do not want to re-calculate values-
        /// use Refersh() or Invalidate();
        /// </summary>
        protected void draw()
        {
            this.calculate();
            this.createGraphImage();
            this.Refresh();
        }
		public void Redraw () {
			this.draw ();
		}
        protected virtual void createGraphImage()
        {
            this.imgGraph = new Bitmap(this.Width, this.Height);
            if (this.dataArrayOfArrays.Length > 2)
            {
                
                if (this.graphHist)
                {
                    int[][] histedArr = this.hist();
                    Graphics g = Graphics.FromImage(this.imgGraph);
                    for (int i = 0; i < this.dataArrayOfArrays.Length; i++)
                    {
                        for (int j = 0; j < this.countYs; j++)
                        {
                            double yValue = (double)this.yMinValue + j * this.deltaYs;

                            float y = (float)this.UsersToPixel(yValue, Axes.y);
                            float x = (float)this.UsersToPixel((double)this.xMinValue + i * this.deltaXs, Axes.x);

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
                    Graphics g = Graphics.FromImage(this.imgGraph);
                    for (int i = 0; i < this.dataArrayOfArrays.Length; i++)
                    {
                        for (int j = 0; j < this.dataArrayOfArrays[i].Length; j++)
                        {
                            float y = (float)this.UsersToPixel(this.dataArrayOfArrays[i][j], Axes.y);
                            float x = (float)this.UsersToPixel((double)this.xMinValue + i * this.deltaXs, Axes.x);
                            if (y < this.Height * 1000 && y > -this.Height * 1000)
                                g.DrawEllipse(Pens.Red, x, y, 1, 1);
                        }
                    }
                    g.Save();
                }
                
            }
            if (this.dataX != null && this.dataY  != null)
            {
                if (this.dataY.Length != this.dataX.Length)
                    return;
                Graphics g = Graphics.FromImage(this.imgGraph);
                for (int i = 0; i < this.dataX.Length; i++)
                {
                    if (this.scatterGraph)
                    {
                        float y = (float)this.UsersToPixel(this.dataY[i], Axes.y);
                        float x = (float)this.UsersToPixel(this.dataX[i], Axes.x);
                        if (y < this.Height * 1000 &&
							y > -this.Height * 1000 &&
							x < this.Width * 1000 &&
							x > -this.Width * 1000)
                        {
                            
                            g.DrawEllipse(Pens.Blue, x, y, 1, 1);
                        }
                    }
                    else
                    {
                        if (i == 0)
                            continue;
                        float y = (float)this.UsersToPixel(this.dataY[i], Axes.y);
                        float x = (float)this.UsersToPixel(this.dataX[i], Axes.x);
                        float yPast = (float)this.UsersToPixel(this.dataY[i-1], Axes.y);
                        float xPast = (float)this.UsersToPixel(this.dataX[i-1], Axes.x);
                        if (y < this.Height * 1000 && 
							y > -this.Height * 1000 && 
							yPast > -this.Height * 1000 && 
							yPast < this.Height * 1000 &&
							x < this.Width * 1000 &&
							x > -this.Width * 1000 &&
							xPast > -this.Width * 1000 &&
							xPast < this.Width * 1000
							)
                        {
                            PointF p1 = new PointF(xPast,xPast);
                            PointF p2 = new PointF(x, y);
                            g.DrawLine(Pens.Blue, x,y,xPast,yPast);
                        }
                    }
                }
                g.Save();
            }
        }

        protected virtual void createAxesAndLabelsImage()
        {
            this.imgAxesAndLabels = new Bitmap(this.Width,this.Height);
            
            Graphics eGraphics = Graphics.FromImage(this.imgAxesAndLabels);

            eGraphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(new Point(0, 0), this.Size));
            eGraphics.FillRectangle(Brushes.White, new Rectangle(point1, size1));
            if (this.imgGraph != null)
                eGraphics.DrawImage(this.imgGraph, new Rectangle(0, 0, this.Width, this.Height));
            if (this.IsAxisVisible)
            {
                int x0Coord = (int)this.UsersToPixel(0, Axes.x);
                int y0Coord = (int)this.UsersToPixel(0, Axes.y);
                if (x0Coord > this.widthBorderLeft && x0Coord < this.Width - this.widthBorderRight)
                {
                    eGraphics.DrawLine(Pens.Black, x0Coord, this.heightBorderUp, x0Coord, this.Height - this.heightBorderDown);
                    eGraphics.DrawLine(Pens.Black, x0Coord, this.heightBorderUp, x0Coord + 3, this.heightBorderUp + 8);
                    eGraphics.DrawLine(Pens.Black, x0Coord, this.heightBorderUp, x0Coord - 3, this.heightBorderUp + 8);
                }
                if (y0Coord > this.heightBorderUp && y0Coord < this.Height - this.heightBorderDown)
                {
                    eGraphics.DrawLine(Pens.DarkBlue, this.widthBorderLeft, y0Coord, this.Width - this.widthBorderRight, (int)y0Coord);
                    eGraphics.DrawLine(Pens.Black, this.Width - this.widthBorderRight, y0Coord, this.Width - this.widthBorderRight - 8, y0Coord - 3);
                    eGraphics.DrawLine(Pens.Black, this.Width - this.widthBorderRight, y0Coord, this.Width - this.widthBorderRight - 8, y0Coord + 3);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                double deltaX = (this.xMaxValue - this.xMinValue) / 4;
                double deltaY = (this.yMaxValue - this.yMinValue) / 4;
                eGraphics.DrawString((this.yMaxValue - deltaY * i).ToString("0.###"), Font, Brushes.Black, new PointF(this.widthBorderLeft - 34, (this.heightBorderUp - 8) + i * ((this.Height - this.heightBorderUp - this.heightBorderDown) / 4)));
                eGraphics.DrawString((this.xMinValue + deltaX * i).ToString("0.###"), Font, Brushes.Black, new PointF((this.widthBorderLeft - 6) + i * ((this.Width - this.widthBorderLeft - this.widthBorderRight) / 4), this.Height - this.heightBorderDown + 6));

            }
            eGraphics.DrawString(this.axisXlabel, Font, Brushes.Red, this.Width / 2, this.Height - 15);
            eGraphics.RotateTransform(-90);
            eGraphics.DrawString(this.axisYlabel, Font, Brushes.Red, -this.Height / 2, 0);
            eGraphics.RotateTransform(90);
 
        }
        /// <summary>
        /// Zoom Out graph for 110 percent
        /// </summary>
        public void zoomOut()
        {
            double deltaX = Math.Abs(this.xMaxValue - this.xMinValue);
            double deltaY = Math.Abs(this.yMaxValue - this.yMinValue);
            deltaY = (deltaY * 1.1 - deltaY) / 2;
            deltaX = (deltaX * 1.1 - deltaX) / 2;
            this.yMinValue -= deltaY;
            this.yMaxValue += deltaY;
            this.xMaxValue += deltaX;
            this.xMinValue -= deltaX;
            this.draw();
        }
        /// <summary>
        /// Zoom In graph for 110 percent
        /// </summary>
        public void zoomIn()
        {
            double deltaX = Math.Abs(this.xMaxValue - this.xMinValue);
            double deltaY = Math.Abs(this.yMaxValue - this.yMinValue);
            deltaY = (deltaY * 1.1 - deltaY) / 2;
            deltaX = (deltaX * 1.1 - deltaX) / 2;
            if (deltaX != 0 && deltaY != 0)
            {
                this.yMinValue += deltaY;
                this.yMaxValue -= deltaY;
                this.xMaxValue -= deltaX;
                this.xMinValue += deltaX;
                this.draw();
            }
        }
        public void moveLeft(double moveValue = 25, MoveAttributes mAttr = MoveAttributes.percents)
        {
            switch (mAttr)
            {
                case MoveAttributes.percents:
                    double deltaMove = this.xMaxValue - this.xMinValue;
                    deltaMove = deltaMove * (moveValue / 100);
                    this.xMinValue -= deltaMove;
                    this.xMaxValue -= deltaMove;
                    break;
                case MoveAttributes.usersCoordinates:
                    this.xMinValue -= moveValue;
                    this.xMaxValue -= moveValue;
                    break;
                default:
                    break;
            }
            this.draw();
        }
        public void moveRight(double moveValue = 25, MoveAttributes mAttr = MoveAttributes.percents)
        {
            switch (mAttr)
            {
                case MoveAttributes.percents:
                    double deltaMove = this.xMaxValue - this.xMinValue;
                    deltaMove = deltaMove * (moveValue / 100);
                    this.xMinValue += deltaMove;
                    this.xMaxValue += deltaMove;
                    break;
                case MoveAttributes.usersCoordinates:
                    this.xMinValue += moveValue;
                    this.xMaxValue += moveValue;
                    break;
                default:
                    break;
            }
            this.draw();
        }
        public void moveUp(double moveValue = 25, MoveAttributes mAttr = MoveAttributes.percents)
        {
            switch (mAttr)
            {
                case MoveAttributes.percents:
                    double deltaMove = this.yMaxValue - this.yMinValue;
                    deltaMove = deltaMove * (moveValue / 100);
                    this.yMinValue += deltaMove;
                    this.yMaxValue += deltaMove;
                    break;
                case MoveAttributes.usersCoordinates:
                    this.yMaxValue += moveValue;
                    this.yMinValue += moveValue;
                    break;
                default:
                    break;
            }
            this.draw();
        }
        public void moveDown(double moveValue = 25, MoveAttributes mAttr = MoveAttributes.percents)
        {
            switch (mAttr)
            {
                case MoveAttributes.percents:
                    double deltaMove = this.yMaxValue - this.yMinValue;
                    deltaMove = deltaMove * (moveValue / 100);
                    this.yMinValue -= deltaMove;
                    this.yMaxValue -= deltaMove;
                    break;
                case MoveAttributes.usersCoordinates:
                    this.yMaxValue -= moveValue;
                    this.yMinValue -= moveValue;
                    break;
                default:
                    break;
            }
            this.draw();
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
                this.zoomIn();
            else
                this.zoomOut();
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
                return ((this.Height - this.heightBorderUp - this.heightBorderDown - (pixelVal - this.heightBorderUp)) * (this.yMaxValue - this.yMinValue) / (this.Height - this.heightBorderUp - this.heightBorderDown) + this.yMinValue);
            }
            else
            {
                return (((pixelVal - this.widthBorderLeft)) * (this.xMaxValue - this.xMinValue) / (this.Width - this.widthBorderLeft - this.widthBorderRight) + this.xMinValue);
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
                int graphHeight = this.Height - (this.heightBorderUp + this.heightBorderDown);
                double  y = (this.heightBorderUp + graphHeight) - ((usersVal -
                                                        Convert.ToDouble(this.yMinValue)) /
                                                        (double)(this.yMaxValue - this.yMinValue)) *
                                                        graphHeight;
                return y;
            }
            else
            {
                int graphWidth = this.Width - (this.widthBorderLeft + this.widthBorderRight);
                double x = (double)(this.widthBorderLeft + (usersVal -(double)this.xMinValue) /
                                                                (double)(this.xMaxValue - this.xMinValue) *
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
                this.imgAxesAndLabels.Save(this.saveFileDialog1.FileName);
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
    }
    public enum Axes : int {x = 0, y = 1 };
    public enum MoveAttributes : int {percents, usersCoordinates};
}
