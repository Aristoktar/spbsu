using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mathematics.SystemSolver;

namespace SPBSU.Dynamic {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main () {

			//string s = "y+y+x*xy+y*y+y";
			
			//string vari = "xy";
			
			//var matchingTemp = Regex.Matches ( s , @"\W" + vari );
			//foreach ( var t in matchingTemp ) {
			//	s = s.Replace ( t.ToString() , " " + t );
			//}
			//var matching = Regex.Replace ( s , @"(^|\W)" + vari + @"($|\W)",new MatchEvaluator((a)=>{
			//	string output = "";
			//	if ( !char.IsLetter ( a.Value[0] ) ) {
			//		output += a.Value[0].ToString ();
			//	}
			//	output += "f[\"" + vari + "\"]";
			//	if ( !char.IsLetter ( a.Value[a.Value.Length-1] ) ) {
			//		output += a.Value[a.Value.Length - 1].ToString ();
			//	}
			//	return output;
			//}));
			//matching = matching.Replace ( " " , "" );
			////for ( int i = 0 ; i < matching.Count ; i++ ) {
			////	string temp = s.
			////	s = s.Replace ( matching[i].ToString () , matching[i].ToString ().Replace ( vari , "f[" + vari + "]" ) );
			////}
			//var q = matching;
			//var y = matching1;
			//var dic = new Dictionary<string,Mathematics.Delegates.functionD>();
			//dic.Add("x1",fu1);
			//dic.Add("x2",fu2);
			//var dic1 = new Dictionary<string,double>();
			//dic1.Add("x1",1.0);
			//dic1.Add("x2",4.0);
			//var ty = SystemSolver.Solve (dic,0,dic1,new Dictionary<string,double>());

			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault ( false );
			Application.Run ( new FormDynamicEquations () );
		}
		//static double fu1 ( double t , Dictionary<string , double> f , Dictionary<string , double> parameters = null ) {
		//	return 3.0*f["x2"]-1;
		//}
		//static double fu2 ( double t , Dictionary<string , double> f , Dictionary<string , double> parameters = null ) {
		//	return -5-f["x1"];
		//}

	}
}
