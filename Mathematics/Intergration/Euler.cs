using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Delegates;

namespace Mathematics.Intergration {
	public static class Euler {
		public static Dictionary<string , List<double>> Integrate ( Dictionary<string , functionD> functions , double t0 , Dictionary<string , double> f0 ,Dictionary<string , double> parameters=null, int iterationsCount = 100000 ) {

			Dictionary<string , List<double>> output = new Dictionary<string , List<double>> ();
			foreach ( var func in functions ) {
				output.Add ( func.Key , new List<double> () );
			}
			List<double> tOut = new List<double> ();
			double t = t0;
			Dictionary<string , double> f = new Dictionary<string , double> ( f0 );

			double h = 0.001;

			for ( int i = 0 ; i < iterationsCount ; i++ ) {
				var tempF = new Dictionary<string , double> ( f );
				foreach ( var key in functions.Keys ) {
					f[key] = f[key] + h * functions[key].Invoke ( t , tempF , parameters );
					output[key].Add ( f[key] );
					
				}
				tOut.Add (t);
				t = t + h;
			}
			output.Add ("t",tOut);
				return output;
		}
		public static Dictionary<string , List<double>> IntegrateSymplectic ( Dictionary<string , functionD> functions , double t0 , Dictionary<string , double> f0 , Dictionary<string , double> parameters = null , int iterationsCount = 100000 ) {

			Dictionary<string , List<double>> output = new Dictionary<string , List<double>> ();
			foreach ( var func in functions ) {
				output.Add ( func.Key , new List<double> () );
				//output[func.Key].Add(f0[func.Key]);
				
			}
			List<double> tOut = new List<double> ();
			
			double t = t0;
			Dictionary<string , double> f = new Dictionary<string , double> ( f0 );

			double h = 0.001;

			for ( int i = 0 ; i < iterationsCount ; i++ ) {
				var tempF = new Dictionary<string , double> ( f );
				foreach ( var key in functions.Keys ) {
					tempF[key] = 0.5 * tempF[key];
				}
				foreach ( var key in functions.Keys ) {
					
					output[key].Add ( f[key] );
					f[key] = f[key] + h * functions[key].Invoke ( t , tempF , parameters );
				}
				tOut.Add ( t );
				t = t + h/2;
			}
			output.Add ( "t" , tOut );
			return output;
		}
	}
}
