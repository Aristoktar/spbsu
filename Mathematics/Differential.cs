using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Delegates;

namespace Mathematics {
	public static class Differential {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="functions"></param>
		/// <param name="var"></param>
		/// <param name="t"></param>
		/// <param name="values"></param>
		/// <param name="parameters"></param>
		/// <param name="notOrig">if calc not original variable(koeff of integr)</param>
		/// <returns></returns>
		public static double Diff ( Dictionary<string , functionD> functions , string var , double t , Dictionary<string , double> values , Dictionary<string , double> parameters, bool notOrig) {
			double delta = 0.0000000001;
			var tempValues = new Dictionary<string , double>(values);
			
			tempValues[var] += delta;

			double t1 = functions[var].Invoke ( t , tempValues , parameters );
			if ( notOrig ) {
				t1 -= delta;
			}
			double t2 = functions[var].Invoke ( t , values , parameters );
			if ( ( t1 - t2 ) == 0 ) return 0;
			double ans = (t1-t2)/ delta;
			return ans;
		}
	}
}
