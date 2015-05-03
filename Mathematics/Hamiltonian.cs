using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Delegates;

namespace Mathematics {
	public static class Hamiltonian {
		public static Dictionary<string , List<double>> Calc ( Dictionary<string , functionD> functions , Dictionary<string , List<double>> calcedData , Dictionary<string , double> parameters) {
			Dictionary<string , List<double>> output = new Dictionary<string,List<double>>();
			output.Add("H",new List<double>());
			output.Add("t",new List<double>());

			for(int i =0;i< calcedData["t"].Count;i++)
			{
				output["t"].Add ( calcedData["t"][i] );
				var temp = calcedData.ToDictionary ( a => a.Key , a => a.Value[i] );
				var t = functions["H"].Invoke ( calcedData["t"][i] , temp , parameters );
				output["H"].Add (t );
			}
			return output;
		}
	}
}
