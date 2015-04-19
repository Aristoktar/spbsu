using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Analysis {
	public static class Function {

		public static FunctionInfo PeriodicAnalysis(double[] values, int errorStep =10,double errorValues = 0.0006) {

			double period = 0;
			bool isPeriodic = true;

			//for ( int i=0; i< values.Length;i++ ) {
			//	for ( int j = i ; j < values.Length ; j++ ) {
			//		if ( (values[i] - values[j]) < errorValues ) {
			//			if ( period == 0 ? true : Math.Abs ( ( j - i ) - period ) < errorStep ) {
			//				period = period == 0 ? (double) ( j - i ) : ( period + (double) ( j - i ) ) / 2;
			//			}
			//			else {
			//				return new FunctionInfo {
			//					PeriodValue = 0 ,
			//					Periodic = false ,
			//					PointsCount = values.Length
			//				};
			//			}
			//		}
			//	}
			//}

			List<double> per = new List<double> ();
			double testV = values[0];
			for ( int i=1; i< values.Length;i++ ) {
				if ( Math.Abs ( values[i] - testV ) < errorValues ) {
					per.Add ( values[i] );
				}
			}
			return new FunctionInfo {
				PeriodValue = period,
				Periodic= true,
				PointsCount = values.Length
			};
		}

		public static FunctionInfo Analyse ( double[] values ) {
			double eps = 0.001;

			double error = 0.001;
			List<double> maxes = new List<double> ();
			List<double> mins = new List<double> ();
			for ( int i=1; i< values.Length-1;i++ ) {
				if ( values[i] > values[i - 1] && values[i] > values[i + 1] ) maxes.Add ( values[i] );
				if ( values[i] < values[i - 1] && values[i] < values[i + 1] ) mins.Add ( values[i] );
			}
			int maxdes = 0;
			int minassend = 0;
			for ( int i = maxes.Count-1 ; i >0  ; i-- ) {
				if (  maxes[i] - maxes[i - 1]<error ) {
					maxdes++;
				}
				else {
					break;
				}
			}
			for ( int i = mins.Count - 1 ; i > 0 ; i-- ) {
				if ( -mins[i] + mins[i - 1]<error ) {
					minassend++;
				}
				else {
					break;
				}
			}
			if ( (double) minassend > (double) ( mins.Count / 2 ) && (double) maxdes > (double) ( maxes.Count / 2 ) )
				return new FunctionInfo {
				isConverges = true
				};
			//double delta = Math.Abs( values[0]-values[1]);
			//for ( int i = 0 ; i < values.Length ; i++ ) {
			//	for ( int j = 0 ; j < values.Length ; j++ ) {
			//		if ( Math.Abs ( values[i] - values[j] ) < delta ) {
			//			delta = Math.Abs ( values[i] - values[j] );
			//		}
			//	}
			//}

			return new FunctionInfo ();
		}
	}
}
