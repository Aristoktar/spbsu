using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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
			
			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault ( false );
			Application.Run ( new FormDynamicEquations () );
		}
	}
}
