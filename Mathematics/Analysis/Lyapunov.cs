using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Delegates;

namespace Mathematics.Analysis {
	public static class Lyapunov {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="values"></param>
		/// <param name="iterationCount">if 0 then ==values["t"].Count</param>
		/// <returns></returns>
		public static Dictionary<string , List<double>> Spectrum ( Dictionary<string , List<double>> values ,
																   Dictionary<string , functionD> functions,
																   Dictionary<string , double> parameters,
																   int iterationCount = 200 ) {

			//double[,] test1 = new double[,] { { 1 , 0 } , { 0 , 1 } };
			//double[,] test2 = new double[,] { { 1 , 2 } , { 3 , 4 } };
			//double[,] ttt = MatrixMultiplication ( test2 , test1 );
			try {

				if ( !values.ContainsKey ( "t" ) ) throw new MathematicsException {
					ErrorMessage = "Input values not contain variable \"t\""
				};
				if ( values["t"].Count < 10 ) throw new MathematicsException {
					ErrorMessage = "not enough data"
				};
			}
			catch {
				return null;
			};
			if ( iterationCount == 0 ) {
				iterationCount = values["t"].Count;
			}
			int nit = iterationCount;
			int steptInt = values["t"].Count/iterationCount; //look after error here
			double steptDouble = values["t"][steptInt] - values["t"][0];

			Dictionary<string , int> according = new Dictionary<string,int>();
			{
				int iterator = 0;
				foreach ( var key in values.Keys ) {
					if ( key != "t" ) {
						according.Add ( key , iterator );
							iterator++;
					}
				}
			}

			int n = values.Count - 1;
			int n1 = n;
			int n2 = n1 * ( n1 + 1 );

			double[] y = new double[n2];
			double[] cum = new double[n1];
			var y0 = new double[n2];
			var gsc = new double[n1];
			var znorm = new double[n1];
			var lp = new double[n1];

			Dictionary<string , List<double>> output = new Dictionary<string , List<double>> ();

			foreach ( var v in according ) {
				y[v.Value] = values[v.Key][0];
				output.Add(v.Key,new List<double>());
			}

			for ( int i = 1 ; i <= n1 ; i++ ) {
				y[( n1+1) * i-1] = 1;
			}
			int tInt = 0;
			double t = values["t"][tInt];
			double tstart = values["t"][0];


			for ( int iteration = 0 ; iteration < iterationCount - 1 ; iteration++ ) {

				var temp = Diff ( values ,
								  according ,
								  functions ,
								  parameters, 
								  y ,
								  n2 ,
								  tInt+steptInt );
				tInt+=steptInt;
				t = values["t"][tInt];
				//for ( int i = 1 ; i <= n1 ; i++ ) {
				//	for ( int j = 1 ; j <= n1 ; j++ ) {
				//		y0[n1 * i + j-1] = y[n1 * j + i-1];
				//	}
				//}
				y0 = new List<double> ( temp ).ToArray ();
				#region construct new orthonormal basis by gram-schmidt

				znorm[0] = 0;
				for ( int j = 1 ; j <= n1 ; j++ ) {
					znorm[0] += Math.Pow ( y0[n1 * j] , 2 );
				}
				znorm[0] = Math.Sqrt ( znorm[0] );
				for ( int j = 1 ; j <= n1 ; j++ ) {
					y0[n1 * j] = y0[n1 * j] / znorm[0];
				}

				for ( int j = 2 ; j <= n1 ; j++ ) {
					for ( int k = 1 ; k <= ( j - 1 ) ; k++ ) {
						gsc[k - 1] = 0;
						for ( int l = 1 ; l <= n1 ; l++ ) {
							gsc[k - 1] = gsc[k - 1] + y0[n1 * l + j - 1] * y0[n1 * l + k - 1];
						}
					}

					for ( int k = 1 ; k <= n1 ; k++ ) {
						for ( int l = 1 ; l <= ( j - 1 ) ; l++ ) {
							y0[n1 * k + j - 1] = y0[n1 * k + j - 1] - gsc[l - 1] * y0[n1 * k + l - 1];
						}
					}
					znorm[j - 1] = 0;
					for ( int k = 1 ; k <= n1 ; k++ ) {
						znorm[j - 1] = znorm[j - 1] + Math.Pow ( y0[n1 * k + j - 1] , 2 );
					}
					znorm[j - 1] = Math.Sqrt ( znorm[j - 1] );
					for ( int k = 1 ; k <= n1 ; k++ ) {
						y0[n1 * k + j - 1] = y0[n1 * k + j - 1] / znorm[j - 1];
					}
				} 
				#endregion
				
				#region update running vector magnitudes
				for ( int k = 1 ; k <= n1 ; k++ ) {
					cum[k - 1] = cum[k - 1] + Math.Log ( znorm[k - 1] );
				} 
				#endregion

				for ( int k = 1 ; k <= n1 ; k++ ) {
					lp [k-1] = cum [ k-1 ] / ( t - tstart ); 
				}

				foreach ( var v in according ) {
					output[v.Key].Add (lp[v.Value]);
				}
				for ( int i = 1 ; i <= n1 ; i++ ) {
					for ( int j = 1 ; j <= n1 ; j++ ) {
						y [ n1 * j + i-1] = y0 [ n1 * i + j -1];
					}
				}

			}
			return output;
		}

		/// <summary>
		/// Staff method (only one usage)
		/// </summary>
		/// <param name="values"></param>
		/// <param name="according"></param>
		/// <param name="n"></param>
		/// <param name="tInt"></param>
		/// <returns></returns>
		private static double[] Diff ( Dictionary<string , List<double>> values,
									   Dictionary<string , int> according,
									   Dictionary<string , functionD> functions,
									   Dictionary<string , double> parameters,
									   double[]X,
									   int n,
									   int tInt) {

			double [] output = new double[n];
			Dictionary<int , string> accordingBack = new Dictionary<int,string>();
			foreach ( var a in according ) {
				output[a.Value] = values[a.Key][tInt];
				accordingBack.Add(a.Value,a.Key);
			}
			double tStep = values["t"][1] - values["t"][0];
			int count = values.Count - 1;
			double[,] Y = new double[ count, count];
			double[,] Jac = new double[count , count];
			for ( int i = 0 ; i < count ; i++ ) {
				for ( int j = 0 ; j < count ; j++ ) {
					//
					Y[j , i] = X[count + j +count*i];

					//derivatives
					string dVariable = accordingBack[j];
					string dFunc = accordingBack[i];
					var tempV1 = values.ToDictionary(a=>a.Key,a=>a.Value[tInt]);
					var tempV2 = new Dictionary<string,double>(tempV1);
					double delta = values[dVariable][tInt+1] - tempV1[dVariable];
					tempV1[dVariable] +=delta;
					
					double df1 = functions[dFunc].Invoke(values["t"][tInt],tempV1,parameters );
						double df2 = functions[dFunc].Invoke(values["t"][tInt],tempV2,parameters );
					double result = (df1-df2) / delta;
					if ( df1 == df2 ) result = 0;
					Jac[j , i] = result;
				}
			}
			var mult = MatrixMultiplication (Y,Jac);
			for ( int i = count ; i < n ; i++ ) {
				output[i] = mult[(i-count) / count , (i-count) % count];
			}
				return output;
		}


		public static double[,] MatrixMultiplication (double[,]a , double[,] b) {

			int outputSize=b.GetLength ( 0 );

			double[,] output = new double[ outputSize, outputSize];
			for ( int i = 0 ; i < outputSize ; i++ ) {
				for ( int j = 0 ; j < outputSize ; j++ ) {
					double temp = 0;
					for(int k= 0;k< b.GetLength(1);k++)
					{
						temp+=a[i,k]*b[k,j];
					}
					output[i , j] = temp;
				}
			}
			return output;
		}
	}
}
