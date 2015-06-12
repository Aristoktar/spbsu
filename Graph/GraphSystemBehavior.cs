using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicCompiling;
using Mathematics.Analysis;
using Mathematics.Delegates;
using Mathematics.Intergration;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using plane;
using Wolfram.NETLink;
using Wolfram.NETLink.Internal;

namespace Graph {
	public class GraphSystemBehavior :Graph{


		public double t0 {
			get;
			set;
		}
		public Dictionary<string , double> f0 {
			get;
			set;
		}
		public Dictionary<string , functionD> functionsD {
			get;
			set;
		}
		public bool UserDynamicFunctions {
			get;
			set;
		}
		public double GrowthX {
			get;
			set;
		}

		public double GrowthY {
			get;
			set;
		}
		public double alfa {
			get;
			set;
		}

		public double betta {
			get;
			set;
		}
		public double initialX {
			get;
			set;
		}
		public double initialY {
			get;
			set;
		}

		public void InitFunctionsD ( Dictionary<string , string> functions , Dictionary<string , double> parameters ) {
			
			Compilator compilator = new Compilator ( functions , parameters );
			this.functionsD = compilator.GetFuncs ();
		}

		protected override void calculate () {
			//base.calculate ();
			GrowthX = 1.3;
			GrowthY = 1.1;
			//double dt = 0.01;
			//alfa -= 1;
			//betta -= 1;

			//double initialX = 0.6;
			//initialY = 0.4;
			List<double> arrX = new List<double> ();
			List<double> arrY = new List<double> ();
			List<double> arrZ = new List<double> ();
			//arrX.Add ( 0.6 );
			//arrY.Add ( 0.2 );
			//arrX.Add ( initialX+0.5 );
			//arrY.Add ( initialY);
			//arrZ.Add (15 );
			double nextX;
			double nextY;
			double nextZ;

			//-------lorenz
			//double x1;
			//double y1;
			//double z1;
			//double x;
			//double y;
			//double z;
			double x = 3.051522 , y = 1.582542 , z = 15.62388 , x1 , y1 , z1;
			double dt = 0.0001;
			int a = 5 , b = 15 , c = 1;
			arrX.Add ( x );
			arrY.Add ( y );
			arrZ.Add ( z );

			for ( int i = 0 ; i < 5000 ; i++ ) {
				double lastX = arrX.Last ();
				double lastY = arrY.Last ();
				//double lastZ = arrZ.Last ();

				//-----------Complex System Slides
				//nextX = lastX * ( 1 + alfa ) - alfa * lastX * lastX - lastY;
				//nextY = lastY * ( 1 + betta ) - betta * ( ( lastY * lastY ) / lastX );
				
				//-----------wikipedia
				//nextX = lastX + 5*( -lastX + lastY ) *dt;
				//nextY = lastY + ( -15*lastX-lastY-lastZ*lastX ) *dt;
				//nextZ = lastZ + ( lastZ + lastX * lastY ) * dt;

				//-----------henon map
				nextX = 1 - alfa * lastX * lastX + lastY;
				nextY = betta * lastX;

				//-----------logistic
				//double r = 3.6;
				//nextX = lastX + 0.001;
				//nextY = alfa * lastY * ( 1 - lastY );


				//----------function info test
				//nextX = lastX + 1;
				//nextY = Math.Pow(-1,nextX)/nextX;

				//--------lorenz
				//x1 = x + a * ( -x + y ) * dt;
				//y1 = y + ( b * x - y - z * x ) * dt;
				//z1 = z + ( -c * z + x * y ) * dt;
				//x = x1; y = y1; z = z1;
				arrX.Add ( x );
				arrY.Add ( y );
				//arrZ.Add ( z );
				//arrX.Add ( nextX );
				//arrY.Add ( nextY );
				//if ( nextX < -1000 || nextY < -1000 )
				//	break;

			}
			//------------Pendulum


			double w2 = 0.5;
			List<double> Xes;
			List<double> YDiffs;
			//List<double> Yes = RungeKutta.Integrate4 ( (x,y)=>{return Math.Sin(x);} , 0 , 0 , 0.001 , out Xes,out YDiffs , 10000 );

			//---------------potential henon heilis
			//var Yes = RungeKutta.Integrate4 ( new functionVector[4] { 
			//						( t , y ) => { return y[2]; } , 
			//						( t , y ) => { return y[3]; },
			//						( t , y ) => { return -y[0]-2*y[0]*y[1];} , 
			//						( t , y ) => { return -y[1]-y[0]*y[0]+y[1]*y[1]; }} , 0.15 , new double[4] { alfa , betta,0,0 } , out Xes , 0.01 , 10000 );


			//--------------attractor lorenz
			//var Yes = RungeKutta.Integrate4 ( new functionVector[3] { 
			//						( t , y ) => { return 10*(y[1]-y[0]); } , 
			//						( t , y ) => { return y[0]*(28-y[2])-y[1]; },
			//						( t , y ) => { return y[0]*y[1] - y[2]*8/3; }} , 0.15 , new double[3] { alfa , betta , 0} , out Xes , 0.01 , 10000 );

			//-----------dynamic

			//if ( UserDynamicFunctions ) {

			//	var tt = RungeKutta.Integrate4 ( this.functionsD , t0 , f0 );
			//	dataX = tt["t"].ToArray ();
			//	dataY = tt["x"].ToArray ();
			//}

			//------runge
			//dataX = Yes[0].ToArray ();
			//dataY = Yes[1].ToArray ();

			//-----fase portraits
			dataX = arrX;
			dataY = arrY;

			//-----dict
			

			//----------------
			//var t = Function.Analyse ( dataY );


			//this.xMaxValue = 10;
			//this.yMaxValue = 300;
			try {

				//MWCharArray mw_func = new MWCharArray ( func );//преобразование строки функции в тип MWCharArray
				

				//testmatlab obj_plane = new testmatlab(); //экземпляр класса компонента               
				//var t = obj_plane.plane ();//обращение к методу plane, первый параметр - это кол-во возвращаемых аргументов

			  //  descriptor = (MWNumericArray) res[0]; //выбор первого элемента из массива MWArray и преобразование в числовой тип MWNumericArray
			  //  double[,] d_descriptor = (double[,]) descriptor.ToArray ( MWArrayComponent.Real );//преобразование массива MWNUmericArray  к масииву типа double  

			  //  for ( int i = 0 ; i < d_descriptor.Length ; i++ )//вывод массива d_descriptor в RichBox
			  //{
			  //	  richTextBox1.Text += i.ToString () + '\t';
			  //	  richTextBox1.Text += d_descriptor[i , 0].ToString ( "0.000" ) + '\n';//преобразование элеметна массива double в string
			  //  }
				//MathKernel mathematica = new MathKernel ();
				//mathematica.Compute ( "f[x_] := -0.75 x^2 - 6*x + 7.5;" );
				//mathematica.Compute ( "xm = x /. Last[FindMaximum[f[x], {x}]];" );
				//System.Windows.Forms.MessageBox.Show ( mathematica.Result.ToString () );
			}
			catch ( Exception ex )//обработка исключения 
		  {
				System.Windows.Forms.MessageBox.Show ( ex.Message );
			}

			
		}
		public List<double> GetAxisData ( Axes axis ) {

			switch ( axis ) {
				case Axes.x: return new List<double> ( this.dataX );
				case Axes.y: return new List<double> ( this.dataY );
				default: return null;
			}
		}

		private void InitializeComponent () {
			this.SuspendLayout();
			// 
			// GraphSystemBehavior
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "GraphSystemBehavior";
			this.Load += new System.EventHandler(this.GraphSystemBehavior_Load);
			this.ResumeLayout(false);

		}

		private void GraphSystemBehavior_Load ( object sender , EventArgs e ) {

		}
	}
}
