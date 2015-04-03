using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Intergration {

	public delegate double[] functionVector ( double[] inputX,double[] inputY );

	public delegate double functionScalar(double inputX, double inputY);

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

		public static List<double> Integrate4 ( functionScalar func , double X , double Y , double h , out List<double> Xout , out List<double> YDiffOut , int iterationCount = 100 ) {
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
	}
}
