using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Delegates;

namespace Mathematics.SystemSolver {
	public static class SystemSolver {

		public static Dictionary<string , double> Solve (Dictionary<string,functionD> functions,double t,Dictionary<string , double> initials,Dictionary<string , double> parameters) {
			double delta = 0.01;
			while ( true ) {
				Dictionary<string , double> tempF = new Dictionary<string , double> ();
				foreach ( var key in functions.Keys ) {
					tempF[key] = functions[key].Invoke ( t , initials , parameters );
										
				}
				int co = tempF.Select ( a => a ).Where ( a => a.Value - initials[a.Key] < delta ).ToList ().Count;
				if ( co == functions.Count ) {
					initials = tempF;
					break;
				}
				else {
					initials = tempF;
				}
			}
			return initials;
		}
	}
}
