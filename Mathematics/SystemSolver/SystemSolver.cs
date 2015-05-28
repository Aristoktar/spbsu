using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Delegates;

namespace Mathematics.SystemSolver {
	public static class SystemSolver {

		public static Dictionary<string , double> Solve (Dictionary<string,functionD> functions,double t,Dictionary<string , double> initials,Dictionary<string , double> parameters) {
			double delta = 0.00000001;
			
			while ( true ) {
				Dictionary<string , double> tempF = new Dictionary<string , double> ();
				foreach ( var key in functions.Keys ) {
					tempF[key] = functions[key].Invoke ( t , initials , parameters );
										
				}
				double test = Norm(initials,tempF);
				test = test;
				double test2 = Norm ( functions.ToDictionary (b=>b.Key, a => a.Value.Invoke ( t , initials , parameters ) ) , functions.ToDictionary (b=>b.Key, a => a.Value.Invoke ( t , tempF , parameters ) ) );
				test2 = test2;
				if ( test2 > test )
					throw new Exception ();
				if (Norm(initials,tempF)<delta ) {
					initials = tempF;
					break;
				}
				else {
					initials = tempF;
				}
			}
			return initials;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="functions"></param>
		/// <param name="t"></param>
		/// <param name="initials"></param>
		/// <param name="parameters"></param>
		/// <param name="notOrig">if calc not original variable</param>
		/// <returns></returns>
		public static Dictionary<string , double> Newton ( Dictionary<string , functionD> functions , double t , Dictionary<string , double> initials , Dictionary<string , double> parameters,bool notOrig) {
			double delta = 0.0000000001;

			while ( true ) {
				Dictionary<string , double> lastInitals = new Dictionary<string , double> ( initials );
				Dictionary<string , double> func = new Dictionary<string , double> ( initials );
				foreach ( var key in functions.Keys ) {
					func[key] = functions[key].Invoke ( t , lastInitals , parameters );
					double der = Differential.Diff ( functions , key , t , lastInitals , parameters, notOrig);
					if(der !=0)
						initials[key] = lastInitals[key] - func[key]/der;
				}
				if ( Norm ( lastInitals , initials ) < delta ) {
					break;
				}
			}
			return initials;
		}
		private static double Norm ( Dictionary<string , double> vector1 , Dictionary<string , double> vector2 ) {
			double ans = 0;
			foreach ( var key in vector1.Keys ) {
				ans += Math.Pow ( vector1[key]-vector2[key] , 2 );
			}
			ans = Math.Sqrt ( ans );
			return ans;
		}
	}
}
