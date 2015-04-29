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
			Dictionary<string , double> k1R = new Dictionary<string,double>();
			Dictionary<string , double> k2R = new Dictionary<string,double>();
			Dictionary<string , double> k3R = new Dictionary<string,double>();
			Dictionary<string , double> k4R = new Dictionary<string,double>();

			Dictionary<string , double> k1L = new Dictionary<string , double> ();
			Dictionary<string , double> k2L = new Dictionary<string , double> ();
			Dictionary<string , double> k3L = new Dictionary<string , double> ();
			Dictionary<string , double> k4L = new Dictionary<string , double> ();

			double tR = t0;
			double tL = t0;
			Dictionary<string , double> fR = new Dictionary<string , double> ( f0 );
			Dictionary<string , double> fL = new Dictionary<string , double> ( f0 );
			double hR=0.001;
			double hL = -hR;

			Dictionary<string , List<double>> outputR = new Dictionary<string , List<double>> ();
			Dictionary<string , List<double>> outputL = new Dictionary<string , List<double>> ();

			foreach ( var func in functions ) {
				outputR.Add (func.Key, new List<double>());
				outputL.Add ( func.Key , new List<double> () );
			}
			List<double> tOutR = new List<double> ();
			List<double> tOutL = new List<double> ();

			for ( int i = 0 ; i < iterationsCount ; i++ ) {
				
				Dictionary<string , double> tempf1R = new Dictionary<string , double> (fR);
				Dictionary<string , double> tempf2R = new Dictionary<string , double> (fR);
				Dictionary<string , double> tempf3R = new Dictionary<string , double> (fR);

				Dictionary<string , double> tempf1L = new Dictionary<string , double> ( fL );
				Dictionary<string , double> tempf2L = new Dictionary<string , double> ( fL );
				Dictionary<string , double> tempf3L = new Dictionary<string , double> ( fL );

				foreach ( var key in functions.Keys ) {
					k1R[key] = functions[key].Invoke(tR, fR,parameters);
					tempf1R[key] = fR[key] + hR * k1R[key] / 2;

					k1L[key] = functions[key].Invoke ( tL , fL , parameters );
					tempf1L[key] = fL[key] + hL * k1L[key] / 2;
				}
				foreach ( var key in functions.Keys ) {
					k2R[key] = functions[key].Invoke ( tR+hR/2 , tempf1R,parameters );
					tempf2R[key] = fR[key] + hR * k2R[key] / 2;

					k2L[key] = functions[key].Invoke ( tL + hL / 2 , tempf1L , parameters );
					tempf2L[key] = fL[key] + hL * k2L[key] / 2;
				}
				foreach ( var key in functions.Keys ) {
					k3R[key] = functions[key].Invoke ( tR + hR / 2 , tempf2R,parameters );
					tempf3R[key] = fR[key] + hR * k3R[key] ;

					k3L[key] = functions[key].Invoke ( tL + hL / 2 , tempf2L , parameters );
					tempf3L[key] = fL[key] + hL * k3L[key];
				}
				foreach ( var key in functions.Keys ) {
					k4R[key] = functions[key].Invoke ( tR + hR , tempf3R ,parameters);
					k4L[key] = functions[key].Invoke ( tL + hL , tempf3L , parameters );
				}
				
				
				foreach ( var key in functions.Keys ) {
					if ( fR["x"] > 0 && fR["x"] < 0.05 ) {
						outputR[key].Add ( fR[key] );
						tOutR.Add ( tR );
					}
					fR[key] = fR[key] + (hR/6) * ( k1R[key] + 2 * k2R[key] + 2 * k3R[key] + k4R[key] );

					if ( fL["x"] > 0 && fL["x"] < 0.05 ) {
						outputL[key].Add ( fL[key] );
						tOutL.Add ( tL );
					}
					fL[key] = fL[key] + ( hL / 6 ) * ( k1L[key] + 2 * k2L[key] + 2 * k3L[key] + k4L[key] );
				}
				tR += hR;
				tL += hL;
			}
			//output["x"] = output["x"].Select ( a => a ).Where (a=>a>0&&a<0.05).ToList();

			
			Dictionary<string , List<double>> output = new Dictionary<string,List<double>>();//= outputL.Reverse ().ToDictionary ( a => a.Key , a => a.Value ).Union ( outputR ).ToDictionary ( a => a.Key , a => a.Value );
			foreach ( var key in functions.Keys ) {
				outputL[key].Remove ( outputL[key][0] );
			}
			foreach ( var key in functions.Keys ) {
				output.Add ( key , new List<double> () );
				outputL[key].Reverse ();
				outputL[key].AddRange( outputR[key]);
				output[key] = outputL[key];
			}
			tOutL.Remove ( tOutL[0] );
			tOutL.Reverse ();
			tOutL.AddRange(tOutR);
			List<double> tOut = tOutL;
			output.Add ( "t" , tOut );
			return output;
			
		}
	}
}
