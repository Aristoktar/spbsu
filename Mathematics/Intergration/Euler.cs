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
																		IntegrationParameters integrationParameters ,
																		out CalculationResults calculationResults ,
																		Dictionary<string , double> parameters = null ,
																		Control parent = null ) {

			calculationResults = new CalculationResults {
				IterationsCount = 0 ,
				FuncInvoked = 0
			};

			bool left = integrationParameters.LeftDirection;
			bool right = integrationParameters.RightDirection;
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

			double hR = integrationParameters.Step;
			double hL = -hR;



			CalculationProgress progress = new CalculationProgress ( integrationParameters.PoincareParameters == null ? integrationParameters.IterationsCount : integrationParameters.PoincareParameters.HitPointsCount , parent );

			for ( int i = 0 ; i < integrationParameters.IterationsCount ; i++ ) {
				calculationResults.IterationsCount++;

				if ( integrationParameters.PoincareParameters != null ) {
					i--;
					if ( tOutL.Count + tOutR.Count >= integrationParameters.PoincareParameters.HitPointsCount ) {
						break;
					}
				}
				var tempFR = new Dictionary<string , double> ( fR );
				var tempFL = new Dictionary<string , double> ( fL );

				bool isAddL = false;
				bool isAddR = false;

				if ( integrationParameters.PoincareParameters != null ) {

					if ( right ) {
						if ( integrationParameters.PoincareParameters.TimePeriodSection ) {
							if ( ( Math.Abs ( tR - t0 ) % integrationParameters.PoincareParameters.PointOfSection ) < integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddR = true;
							}
						}
						else {
							if ( fR[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
										fR[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddR = true;
							}
						}

					}
					if ( left ) {
						if ( integrationParameters.PoincareParameters.TimePeriodSection ) {
							if ( ( Math.Abs ( tL - t0 ) % integrationParameters.PoincareParameters.PointOfSection ) < integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddL = true;
							}
						}
						else {
							if ( fL[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
											fL[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddL = true;
							}
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
					if ( integrationParameters.LeftDirection ) {
						if ( double.IsNaN ( fL[key] ) || double.IsInfinity ( fL[key] ) ) throw new MathematicsCalculationException {
							ErrorMessage = "During calculations one or more variables became infinity or NaN in L!" ,
							CalcedValues = CreateOutput ( left , right , outputL , outputR , tOutL , tOutR , functions.Keys )
						};
					}
					if ( integrationParameters.RightDirection ) {
						if ( double.IsNaN ( fR[key] ) || double.IsInfinity ( fR[key] ) ) throw new MathematicsCalculationException {
							ErrorMessage = "During calculations one or more variables became infinity or NaN in R!" ,
							CalcedValues = CreateOutput ( left , right , outputL , outputR , tOutL , tOutR , functions.Keys )
						};
					}

					if ( right ) {
						if ( isAddR ) {
							outputR[key].Add ( fR[key] );
						} 
						fR[key] = fR[key] + hR * functions[key].Invoke ( tR , tempFR , parameters );
						calculationResults.FuncInvoked++;
						
					}

					if ( left ) {
						if ( isAddL ) {
							outputL[key].Add ( fL[key] );
						}
						fL[key] = fL[key] + hL * functions[key].Invoke ( tL , tempFL , parameters );
						calculationResults.FuncInvoked++;
					}
					
				}
				tR = tR + hR;
				tL = tL + hL;
				if ( integrationParameters == null ) {
					progress.NextValue ( i );
				}
				else {
					progress.NextValue ( tOutL.Count + tOutR.Count );
				}
			}
			progress.Close ();
			return CreateOutput ( left , right , outputL , outputR , tOutL , tOutR,functions.Keys);
		}
		public static Dictionary<string , List<double>> IntegrateImplicit ( Dictionary<string , functionD> functions ,
																		double t0 ,
																		Dictionary<string , double> f0 ,
																		IntegrationParameters integrationParameters ,
																		out CalculationResults calculationResults ,
																		Dictionary<string , double> parameters = null ,
																		Control parent = null ) {

			calculationResults = new CalculationResults {
				IterationsCount = 0 ,
				FuncInvoked = 0
			};

			bool left = integrationParameters.LeftDirection;
			bool right = integrationParameters.RightDirection;
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

			double hR = integrationParameters.Step;
			double hL = -hR;



			CalculationProgress progress = new CalculationProgress ( integrationParameters.PoincareParameters == null ? integrationParameters.IterationsCount : integrationParameters.PoincareParameters.HitPointsCount , parent );

			for ( int i = 0 ; i < integrationParameters.IterationsCount ; i++ ) {
				calculationResults.IterationsCount++;

				if ( integrationParameters.PoincareParameters != null ) {
					i--;
					if ( tOutL.Count + tOutR.Count >= integrationParameters.PoincareParameters.HitPointsCount ) {
						break;
					}
				}
				var tempFR = new Dictionary<string , double> ( fR );
				var tempFL = new Dictionary<string , double> ( fL );

				bool isAddL = false;
				bool isAddR = false;

				if ( integrationParameters.PoincareParameters != null ) {

					if ( right ) {
						if ( integrationParameters.PoincareParameters.TimePeriodSection ) {
							if ( ( Math.Abs ( tR - t0 ) % integrationParameters.PoincareParameters.PointOfSection ) < integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddR = true;
							}
						}
						else {
							if ( fR[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
										fR[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddR = true;
							}
						}

					}
					if ( left ) {
						if ( integrationParameters.PoincareParameters.TimePeriodSection ) {
							if ( ( Math.Abs ( tL - t0 ) % integrationParameters.PoincareParameters.PointOfSection ) < integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddL = true;
							}
						}
						else {
							if ( fL[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
											fL[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddL = true;
							}
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

				//foreach ( var key in functions.Keys ) {
				//	if ( right ) {
				//		tempFR[key] = tempFR[key] + hR * 0.5 * tempFR[key];
				//	}
				//	if ( left ) {

				//		tempFL[key] = tempFL[key] + hL * 0.5 * tempFL[key];
				//	}
				//}
				//foreach ( var key in functions.Keys ) {
				//	if ( right ) {
				//		if ( isAddR ) {
				//			outputR[key].Add ( fR[key] );
				//		}
				//		fR[key] = fR[key] + hR * functions[key].Invoke ( tR + hR / 2 , tempFR , parameters );
				//		calculationResults.FuncInvoked++;

				//	}

				//	if ( left ) {
				//		if ( isAddL ) {
				//			outputL[key].Add ( fL[key] );
				//		}
				//		fL[key] = fL[key] + hL * functions[key].Invoke ( tL + hL / 2 , tempFL , parameters );
				//		calculationResults.FuncInvoked++;
				//	}

				//}
				Dictionary<string , functionD> functionsTemp = new Dictionary<string , functionD> ();
				foreach ( var key in functions.Keys ) {
					functionsTemp[key] = ( t1 , f1 , parameters1 ) => {
						return -f1[key] +fR[key] + hR * functions[key].Invoke ( t1 , f1 , parameters1 );
					};
				}
				var solve = SystemSolver.SystemSolver.Newton ( functionsTemp , tR , tempFR,parameters,false);
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						if ( isAddR ) {
							outputR[key].Add ( fR[key] );
						}
						fR[key] = solve[key];
						calculationResults.FuncInvoked++;

					}
				}
				tR = tR + hR;
				tL = tL + hL;
				if ( integrationParameters == null ) {
					progress.NextValue ( i );
				}
				else {
					progress.NextValue ( tOutL.Count + tOutR.Count );
				}
			}
			progress.Close ();
			return CreateOutput ( left , right , outputL , outputR , tOutL , tOutR , functions.Keys );
		}
		public static Dictionary<string , List<double>> IntegrateSymplectic ( Dictionary<string , functionD> functions ,
																		double t0 ,
																		Dictionary<string , double> f0 ,
																		IntegrationParameters integrationParameters ,
																		out CalculationResults calculationResults ,
																		Dictionary<string , double> parameters = null ,
																		Control parent = null ) {

			calculationResults = new CalculationResults {
				IterationsCount = 0 ,
				FuncInvoked = 0
			};

			bool left = false;// integrationParameters.LeftDirection;
			bool right = integrationParameters.RightDirection;
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

			double hR = integrationParameters.Step;
			double hL = -hR;



			CalculationProgress progress = new CalculationProgress ( integrationParameters.PoincareParameters == null ? integrationParameters.IterationsCount : integrationParameters.PoincareParameters.HitPointsCount , parent );

			for ( int i = 0 ; i < integrationParameters.IterationsCount ; i++ ) {
				calculationResults.IterationsCount++;

				if ( integrationParameters.PoincareParameters != null ) {
					i--;
					if ( tOutL.Count + tOutR.Count >= integrationParameters.PoincareParameters.HitPointsCount ) {
						break;
					}
				}
				var tempFR = new Dictionary<string , double> ( fR );
				var tempFL = new Dictionary<string , double> ( fL );

				bool isAddL = false;
				bool isAddR = false;

				if ( integrationParameters.PoincareParameters != null ) {

					if ( right ) {
						if ( integrationParameters.PoincareParameters.TimePeriodSection ) {
							if ( ( Math.Abs ( tR - t0 ) % integrationParameters.PoincareParameters.PointOfSection ) < integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddR = true;
							}
						}
						else {
							if ( fR[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
										fR[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddR = true;
							}
						}

					}
					if ( left ) {
						if ( integrationParameters.PoincareParameters.TimePeriodSection ) {
							if ( ( Math.Abs ( tL - t0 ) % integrationParameters.PoincareParameters.PointOfSection ) < integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddL = true;
							}
						}
						else {
							if ( fL[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
											fL[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
								isAddL = true;
							}
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

				//foreach ( var key in functions.Keys ) {
				//	if ( right ) {
				//		tempFR[key] = tempFR[key] + hR * 0.5 * tempFR[key];
				//	}
				//	if ( left ) {

				//		tempFL[key] = tempFL[key] + hL * 0.5 * tempFL[key];
				//	}
				//}
				//foreach ( var key in functions.Keys ) {
				//	if ( right ) {
				//		if ( isAddR ) {
				//			outputR[key].Add ( fR[key] );
				//		}
				//		fR[key] = fR[key] + hR * functions[key].Invoke ( tR + hR / 2 , tempFR , parameters );
				//		calculationResults.FuncInvoked++;

				//	}

				//	if ( left ) {
				//		if ( isAddL ) {
				//			outputL[key].Add ( fL[key] );
				//		}
				//		fL[key] = fL[key] + hL * functions[key].Invoke ( tL + hL / 2 , tempFL , parameters );
				//		calculationResults.FuncInvoked++;
				//	}

				//}
				Dictionary<string , double> k1R = new Dictionary<string , double> ();
				Dictionary<string , functionD> functionsTempR = new Dictionary<string , functionD> ();
				foreach ( var key in functions.Keys ) {
					k1R[key] = 1.0;//functions[key].Invoke ( tR , fR , parameters );
				}
				foreach ( var key in functions.Keys ) {
					functionsTempR[key] = ( t1 , f1 , parameters1 ) => {
						foreach ( var key1 in functions.Keys ) {
							f1[key1] += (1/2)*k1R[key1];
						}
						double k = k1R[key];
						double func = functions[key].Invoke ( tR , fR , parameters1 );
						return hR *func/2- k;
					};
				}
				
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						k1R = SystemSolver.SystemSolver.Newton ( functionsTempR , tR , k1R , parameters, true);						
					}

					//if ( left ) {
					//	k3L[key] = functions[key].Invoke ( tL + hL / 2 , tempf2L , parameters );
					//	calculationResults.FuncInvoked++;
					//	tempf3L[key] = fL[key] + hL * k3L[key];
					//}
				}

				//Dictionary<string , functionD> functionsTemp = new Dictionary<string , functionD> ();
				//foreach ( var key in functions.Keys ) {
				//	functionsTemp[key] = ( t1 , f1 , parameters1 ) => {
				//		return -f1[key] + fR[key] + hR * functions[key].Invoke ( t1 , f1 , parameters1 );
				//	};
				//}
				//var solve = SystemSolver.SystemSolver.Newton ( functionsTemp , tR , tempFR , parameters );
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						if ( isAddR ) {
							outputR[key].Add ( fR[key] );
						}
						fR[key] = fR[key]+hR* k1R[key];
						calculationResults.FuncInvoked++;

					}
				}
				tR = tR + hR;
				tL = tL + hL;
				if ( integrationParameters == null ) {
					progress.NextValue ( i );
				}
				else {
					progress.NextValue ( tOutL.Count + tOutR.Count );
				}
				progress.RefreshCounter ();
			}
			progress.Close ();
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
