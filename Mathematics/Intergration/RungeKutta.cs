using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Delegates;

namespace Mathematics.Intergration {

	

	public static class RungeKutta {

		//public static double Integrate4 ( functionVector[] func,double[] valuesX, double[] valuesY,double h,int iterationCount=100 ) {
		//	double[] k1 = new double[valuesX.Length];
		//	double[] k2 = new double[valuesX.Length];
		//	double[] k3 = new double[valuesX.Length];
		//	double[] k4 = new double[valuesX.Length];

		//	for ( int i = 0 ; i < iterationCount ; i++ ) {
		//		k1 = func.Invoke ( valuesX , valuesY );

		//	}
		//		return func.Invoke ( 4 );
		//}

		public static List<double> Integrate4 ( function func , double X , double Y , double h , out List<double> Xout , out List<double> YDiffOut , int iterationCount = 100 ) {
			double k1;
			double k2;
			double k3;
			double k4;
			List<double> answerY = new List<double> ();
			Xout = new List<double>();
			YDiffOut = new List<double> ();

			double Xnext;
			double Ynext;

			for ( int i = 0 ; i < iterationCount ; i++ ) {
				
				k1 = func.Invoke ( X , Y );
				k2 = func.Invoke ( X + h / 2 , Y + k1 * h / 2 );
				k3 = func.Invoke ( X + h / 2 , Y + k2 * h / 2 );
				k4 = func.Invoke ( X + h , Y + k3 * h );

				Ynext = Y + h * ( k1 + 2 * k2 + 2 * k3 + k4 );
				Xnext = X + h;
				answerY.Add (Y);
				Xout.Add(X);
				YDiffOut.Add ( k1 );
				X = Xnext;
				Y = Ynext;
			}
			return answerY;
		}

		public static List<double>[] Integrate4 ( functionVector[] func , double X , double[] Y ,out List<double> Xout , double h , int iterationCount = 100 ) {
			int count =Y.Length; 
			double[] k1 = new double[count];
			double[] k2 = new double[count];
			double[] k3 = new double[count];
			double[] k4 = new double[count];

			Xout = new List<double>();

			List<double>[] answerY = new List<double> [count];
			for ( int i = 0 ; i < answerY.Length ; i++ ) {
				answerY[i] = new List<double> ();
			}

			for ( int i = 0 ; i < iterationCount ; i++ ) {
				double[] tempYs2 = new double[count];
				double[] tempYs3 = new double[count];
				double[] tempYs4 = new double[count];
				Y.CopyTo ( tempYs2 , 0 );
				Y.CopyTo ( tempYs3 , 0 );
				Y.CopyTo ( tempYs4 , 0 );
				for ( int j = 0 ; j < count ; j++ ) {//
					k1[j] = func[j].Invoke ( X , Y );
					tempYs2[j] = Y[j] + h * k1[j] / 2;
				}
				for ( int j = 0 ; j < count ; j++ ) {//
					k2[j] = func[j].Invoke(X+h/2,tempYs2);
					tempYs3[j] = Y[j] + h * k2[j] / 2;
				}
				for ( int j = 0 ; j < count ; j++ ) {
					k3[j] = func[j].Invoke ( X + h , tempYs3 );
					tempYs4[j] = Y[j] + h * k3[j];
				}
				for ( int j = 0 ; j < count ; j++ ) {
					k4[j] = func[j].Invoke ( X + h / 2 , tempYs4 );
				}
				Xout.Add ( X );
				for ( int j = 0 ; j < count ; j++ ) {
					answerY[j].Add ( Y[j] );
					
					Y [j] = Y[j] + h * ( k1[j] + 2 * k2[j] + 2 * k3[j] + k4[j] );
					
				}
				X = X + h;
			}


			return answerY;
		}

		public static Dictionary<string , List<double>> Integrate4 ( Dictionary<string , functionD> functions , double t0 , Dictionary<string , double> f0 ,Dictionary<string , double> parameters=null, int iterationsCount = 100000 ) {
			Dictionary<string , double> k1 = new Dictionary<string,double>();
			Dictionary<string , double> k2 = new Dictionary<string,double>();
			Dictionary<string , double> k3 = new Dictionary<string,double>();
			Dictionary<string , double> k4 = new Dictionary<string,double>();

			double t = t0;
			Dictionary<string , double> f = new Dictionary<string , double> (f0);

			double h=0.001;

			Dictionary<string , List<double>> output = new Dictionary<string , List<double>> ();
			foreach ( var func in functions ) {
				output.Add (func.Key, new List<double>());
			}
			List<double> tOut = new List<double> ();

			for ( int i = 0 ; i < iterationsCount ; i++ ) {
				
				Dictionary<string , double> tempf1 = new Dictionary<string , double> (f);
				Dictionary<string , double> tempf2 = new Dictionary<string , double> (f);
				Dictionary<string , double> tempf3 = new Dictionary<string , double> (f);

				foreach ( var key in functions.Keys ) {
					k1[key] = functions[key].Invoke(t, f,parameters);
					tempf1[key] = f[key] + h * k1[key] / 2;
				}
				foreach ( var key in functions.Keys ) {
					k2[key] = functions[key].Invoke ( t+h/2 , tempf1,parameters );
					tempf2[key] = f[key] + h * k2[key] / 2;
				}
				foreach ( var key in functions.Keys ) {
					k3[key] = functions[key].Invoke ( t + h / 2 , tempf2,parameters );
					tempf3[key] = f[key] + h * k3[key] / 2;
				}
				foreach ( var key in functions.Keys ) {
					k4[key] = functions[key].Invoke ( t + h , tempf3 ,parameters);
				}
				tOut.Add (t);
				foreach ( var key in functions.Keys ) {
					output[key].Add ( f[key] );
					f[key] = f[key] + h * ( k1[key] + 2 * k2[key] + 2 * k3[key] + k4[key] );
				}
				t += h;
			}
			output.Add ( "t" , tOut );
			return output;
			
		}
	}
}
