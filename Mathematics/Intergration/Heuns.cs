using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mathematics.Delegates;

namespace Mathematics.Intergration {
	public static class Heuns {
		public static Dictionary<string , List<double>> Integrate ( Dictionary<string , functionD> functions ,
																		double t0 ,
																		Dictionary<string , double> f0 ,
																		IntegrationParameters integrationParameters ,
																		out CalculationResults calculationResults ,
																		Dictionary<string , double> parameters = null ,
																		Control parent = null ) {

			CalculationProgress progress = new CalculationProgress ( integrationParameters.PoincareParameters == null ? integrationParameters.IterationsCount : integrationParameters.PoincareParameters.HitPointsCount , parent );


			calculationResults = new CalculationResults {
				IterationsCount = 0 ,
				FuncInvoked = 0
			};

			Dictionary<string , double> k1R = new Dictionary<string , double> ();

			Dictionary<string , double> k1L = new Dictionary<string , double> ();
			

			double tR = t0;
			double tL = t0;
			Dictionary<string , double> fR = new Dictionary<string , double> ( f0 );
			Dictionary<string , double> fL = new Dictionary<string , double> ( f0 );
			double hR = integrationParameters.Step;
			double hL = -hR;

			bool left = integrationParameters.LeftDirection;
			bool right = integrationParameters.RightDirection;


			Dictionary<string , List<double>> outputR = new Dictionary<string , List<double>> ();
			Dictionary<string , List<double>> outputL = new Dictionary<string , List<double>> ();

			foreach ( var func in functions ) {
				outputR.Add ( func.Key , new List<double> () );
				outputL.Add ( func.Key , new List<double> () );
			}
			List<double> tOutR = new List<double> ();
			List<double> tOutL = new List<double> ();
			//var thread = new Thread(() =>
			//{
			int iter = 0;
			for ( int i = 0 ; i < integrationParameters.IterationsCount ; i++ ) {
				iter++;
				calculationResults.IterationsCount++;

				if ( integrationParameters.PoincareParameters != null ) {
					i--;
					if ( tOutL.Count + tOutR.Count >= integrationParameters.PoincareParameters.HitPointsCount ) {
						break;
					}
				}

				Dictionary<string , double> tempfR = new Dictionary<string , double> ( );
				

				Dictionary<string , double> tempfL = new Dictionary<string , double> (  );
				

				foreach ( var key in functions.Keys ) {
					if ( right ) {
						tempfR[key] = fR[key] + hR * functions[key].Invoke ( tR , fR , parameters );
						calculationResults.FuncInvoked++;
					}
					if ( left ) {
						tempfL[key] = fL[key] + hL * functions[key].Invoke ( tL , fL , parameters );
						calculationResults.FuncInvoked++;
					}
				}

				bool isAddL = false;
				bool isAddR = false;
				if ( integrationParameters.PoincareParameters != null ) {

					if ( right ) {
						if ( fR[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
										fR[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
							isAddR = true;
						}
					}
					if ( left ) {
						if ( fL[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
										fL[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
							isAddL = true;
						}
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
					if ( double.IsNaN ( fR[key] ) || double.IsNaN ( fL[key] ) || double.IsInfinity ( fR[key] ) || double.IsInfinity ( fL[key] ) ) throw new MathematicsCalculationException {
						ErrorMessage = "During calculations one or more variables became infinity or NaN!" ,
						CalcedValues = CreateOutput ( left , right , outputL , outputR , tOutL , tOutR , functions.Keys )
					};
					if ( right ) {
						if ( isAddR ) {
							outputR[key].Add ( fR[key] );

						}
						fR[key] = fR[key] + ( hR / 2 ) * ( functions[key].Invoke ( tR , fR , parameters ) + functions[key].Invoke ( tR + hR , tempfR , parameters ) );
					}

					if ( left ) {
						if ( isAddL ) {
							outputL[key].Add ( fL[key] );

						}
						fL[key] = fL[key] + ( hL / 2 ) * ( functions[key].Invoke ( tL , fL , parameters ) + functions[key].Invoke ( tL + hL , tempfL , parameters ) );
					}
				}

				tR += hR;
				tL += hL;

				if ( integrationParameters.PoincareParameters == null ) {
					progress.NextValue ( i );
				}
				else {
					progress.NextValue ( tOutL.Count + tOutR.Count );
				}
			}
			//});
			//thread.Start ();
			//output["x"] = output["x"].Select ( a => a ).Where (a=>a>0&&a<0.05).ToList();



			progress.Close ();
			//if(progressBar) parent.Invoke ( new Action ( () => {
			//		bar1.Close ();
			//		//bar1 = null;
			//	} ) );
			return CreateOutput ( left , right , outputL , outputR , tOutL , tOutR , functions.Keys );

		}
		private static Dictionary<string , List<double>> CreateOutput ( bool left , bool right ,
															Dictionary<string , List<double>> outputL ,
															Dictionary<string , List<double>> outputR ,
															List<double> tOutL ,
															List<double> tOutR ,
															Dictionary<string , functionD>.KeyCollection keys ) {
			Dictionary<string , List<double>> output = new Dictionary<string , List<double>> ();//= outputL.Reverse ().ToDictionary ( a => a.Key , a => a.Value ).Union ( outputR ).ToDictionary ( a => a.Key , a => a.Value );
			if ( left && right ) {
				if ( tOutL.Count != 0 ) {

					foreach ( var key in keys ) {
						outputL[key].Remove ( outputL[key][0] );
					}

					foreach ( var key in keys ) {
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
					foreach ( var key in keys ) {
						output[key] = outputR[key];
					}
					output.Add ( "t" , tOutR );
				}
			}
			else {
				if ( right ) {
					output = outputR;
					output.Add ( "t" , tOutR );
				}
				if ( left ) {
					output = outputL;
					output.Add ( "t" , tOutL );
					//foreach ( var key in functions.Keys ) {
					//	output[key].Reverse ();//??
					//}
				}
			}
			return output;
		}
	}
}
