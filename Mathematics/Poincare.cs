using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Delegates;

namespace Mathematics {
	public static class Poincare {
		public static Dictionary<string , List<double>> Calculate ( Dictionary<string , functionD> functions , double t0 , Dictionary<string , double> f0 , Dictionary<string , double> parameters = null , int iterationsCount = 100000 ) {

			double t = t0;
			Dictionary<string , double> f = new Dictionary<string , double> ( f0 );

			double h = 0.1;

			Dictionary<string , List<double>> output = new Dictionary<string , List<double>> ();
			foreach ( var func in functions ) {
				output.Add ( func.Key , new List<double> () );
				output[func.Key].Add ( f[func.Key] );
			}
			List<double> tOut = new List<double> ();

			for ( int i = 0 ; i < iterationsCount ; i++ ) {
				Dictionary<string , double> temp = new Dictionary<string , double> ( output.ToDictionary ( a => a.Key , a => a.Value.Last () ) );

				foreach ( var key in functions.Keys ) {
					output[key].Add ( functions[key].Invoke ( t , temp , parameters ) );

				}
				tOut.Add ( t );
				t += h;
			}
			output.Add ( "t" , tOut );
			return output;
		}
	}
}
