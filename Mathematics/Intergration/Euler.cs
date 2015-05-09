using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mathematics.Delegates;

namespace Mathematics.Intergration {
	public static class Euler {
		public static Dictionary<string , List<double>> Integrate ( Dictionary<string , functionD> functions ,
																		double t0 ,
																		Dictionary<string , double> f0 ,
																		Dictionary<string , double> parameters = null ,
																		PoincareSectionParameters poincareSectionParameters = null ,
																		Control parent = null ,
																		int iterationsCount = 100000 ) {

			Dictionary<string , List<double>> outputR = new Dictionary<string , List<double>> ();
			Dictionary<string , List<double>> outputL = new Dictionary<string , List<double>> ();
			foreach ( var func in functions ) {
				outputL.Add ( func.Key , new List<double> () );
				outputR.Add ( func.Key , new List<double> () );
			}
			List<double> tOutR = new List<double> ();
			List<double> tOutL = new List<double> ();
			double tR = t0;
			double tL = t0;
			Dictionary<string , double> fR = new Dictionary<string , double> ( f0 );
			Dictionary<string , double> fL = new Dictionary<string , double> ( f0 );

			double hR = 0.001;
			double hL = -hR;

			CalculationProgress progress = new CalculationProgress ( poincareSectionParameters == null ? iterationsCount : poincareSectionParameters.HitPointsCount , parent );

			for ( int i = 0 ; i < iterationsCount ; i++ ) {

				if ( poincareSectionParameters != null ) {
					i--;
					if ( tOutL.Count + tOutR.Count >= poincareSectionParameters.HitPointsCount ) {
						break;
					}
				}
				var tempFR = new Dictionary<string , double> ( fR );
				var tempFL = new Dictionary<string , double> ( fL );

				bool isAddL = false;
				bool isAddR = false;

				if ( poincareSectionParameters != null ) {

					if ( fR[poincareSectionParameters.VariableForSection] > poincareSectionParameters.PointOfSection &&
						fR[poincareSectionParameters.VariableForSection] < poincareSectionParameters.PointOfSection + poincareSectionParameters.ThicknessOfLayer ) {
						isAddR = true;
					}
					if ( fL[poincareSectionParameters.VariableForSection] > poincareSectionParameters.PointOfSection &&
						fL[poincareSectionParameters.VariableForSection] < poincareSectionParameters.PointOfSection + poincareSectionParameters.ThicknessOfLayer ) {
						isAddL = true;
					}
				}
				else {
					isAddL = true;
					isAddR = true;
				}
				if ( isAddL ) {
					tOutL.Add ( tL );
				}
				if ( isAddR ) {
					tOutR.Add ( tR );
				}


				foreach ( var key in functions.Keys ) {
					fR[key] = fR[key] + hR * functions[key].Invoke ( tR , tempFR , parameters );
					fL[key] = fL[key] + hL * functions[key].Invoke ( tL , tempFL , parameters );
					//if ( f["x"] > 0 && f["x"] < 0.0001 )
					if ( isAddR ) {
						outputR[key].Add ( fR[key] );
					}
					if ( isAddL ) {
						outputL[key].Add ( fL[key] );
					}
					
				}
				tR = tR + hR;
				tL = tL + hL;
				if ( poincareSectionParameters == null ) {
					progress.NextValue ( i );
				}
				else {
					progress.NextValue ( tOutL.Count + tOutR.Count );
				}
			}
			Dictionary<string , List<double>> output = new Dictionary<string , List<double>> ();//= outputL.Reverse ().ToDictionary ( a => a.Key , a => a.Value ).Union ( outputR ).ToDictionary ( a => a.Key , a => a.Value );
			if ( tOutL.Count != 0 ) {

				foreach ( var key in functions.Keys ) {
					outputL[key].Remove ( outputL[key][0] );
				}

				foreach ( var key in functions.Keys ) {
					output.Add ( key , new List<double> () );
					outputL[key].Reverse ();
					outputL[key].AddRange ( outputR[key] );
					output[key] = outputL[key];
				}

				tOutL.Remove ( tOutL[0] );
				tOutL.Reverse ();
				tOutL.AddRange ( tOutR );
				List<double> tOut = tOutL;
				output.Add ( "t" , tOut );
			}
			else {
				foreach ( var key in functions.Keys ) {
					output[key] = outputR[key];
				}
				output.Add ( "t" , tOutR );
			}
			progress.Close ();
			//if(progressBar) parent.Invoke ( new Action ( () => {
			//		bar1.Close ();
			//		//bar1 = null;
			//	} ) );
			return output;
		}
		public static Dictionary<string , List<double>> IntegrateSymplectic ( Dictionary<string , functionD> functions ,
																		double t0 ,
																		Dictionary<string , double> f0 ,
																		Dictionary<string , double> parameters = null ,
																		PoincareSectionParameters poincareSectionParameters = null ,
																		Control parent = null ,
																		int iterationsCount = 100000 ) {

			Dictionary<string , List<double>> output = new Dictionary<string , List<double>> ();
			foreach ( var func in functions ) {
				output.Add ( func.Key , new List<double> () );
				//output[func.Key].Add(f0[func.Key]);
				
			}
			List<double> tOut = new List<double> ();
			CalculationProgress progress = new CalculationProgress ( poincareSectionParameters == null ? iterationsCount : poincareSectionParameters.HitPointsCount , parent );
			double t = t0;
			Dictionary<string , double> f = new Dictionary<string , double> ( f0 );

			double h = 0.002;

			for ( int i = 0 ; i < iterationsCount ; i++ ) {
				//if ( poincareSectionParameters != null ) {
				//	i--;
				//	if ( tOutL.Count + tOutR.Count >= poincareSectionParameters.HitPointsCount ) {
				//		break;
				//	}
				//}

				var tempF = new Dictionary<string , double> ( f );
				foreach ( var key in functions.Keys ) {
					tempF[key] = 0.5 * tempF[key];
				}
				foreach ( var key in functions.Keys ) {
					
					output[key].Add ( f[key] );
					f[key] = f[key] + h * functions[key].Invoke ( t+h/2 , tempF , parameters );
				}
				tOut.Add ( t );
				t = t + h;

				if ( poincareSectionParameters == null ) {
					progress.NextValue ( i );
				}
				else {
					//progress.NextValue ( tOutL.Count + tOutR.Count );
				}
			}
			output.Add ( "t" , tOut );
			progress.Close ();
			return output;
		}
	}
}
