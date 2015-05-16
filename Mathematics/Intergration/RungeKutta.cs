using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Mathematics.Delegates;

namespace Mathematics.Intergration {

	

	public static class RungeKutta {

		//public static double Integrate4 ( functionVector[] func,double[] valuesX, double[] valuesY,double h,int iterationCount=100 ) {
		//	double[] k1 = new double[valuesX.Length];
		//	double[] k2 = new double[valuesX.Length];
		//	double[] k3 = new double[valuesX.Length];
		//	double[] k4 = new double[valuesX.Length];

		//	for ( int i = 0 ; i < iterationCount ; i++ ) {
		//		k1 = func.Invoke ( valuesX , valuesY );

		//	}
		//		return func.Invoke ( 4 );
		//}

		//public static List<double> Integrate4 ( function func , double X , double Y , double h , out List<double> Xout , out List<double> YDiffOut , int iterationCount = 100 ) {
		//	double k1;
		//	double k2;
		//	double k3;
		//	double k4;
		//	List<double> answerY = new List<double> ();
		//	Xout = new List<double>();
		//	YDiffOut = new List<double> ();

		//	double Xnext;
		//	double Ynext;

		//	for ( int i = 0 ; i < iterationCount ; i++ ) {
				
		//		k1 = func.Invoke ( X , Y );
		//		k2 = func.Invoke ( X + h / 2 , Y + k1 * h / 2 );
		//		k3 = func.Invoke ( X + h / 2 , Y + k2 * h / 2 );
		//		k4 = func.Invoke ( X + h , Y + k3 * h );

		//		Ynext = Y + h * ( k1 + 2 * k2 + 2 * k3 + k4 );
		//		Xnext = X + h;
		//		answerY.Add (Y);
		//		Xout.Add(X);
		//		YDiffOut.Add ( k1 );
		//		X = Xnext;
		//		Y = Ynext;
		//	}
		//	return answerY;
		//}

		//public static List<double>[] Integrate4 ( functionVector[] func , double X , double[] Y ,out List<double> Xout , double h , int iterationCount = 100 ) {
		//	int count =Y.Length; 
		//	double[] k1 = new double[count];
		//	double[] k2 = new double[count];
		//	double[] k3 = new double[count];
		//	double[] k4 = new double[count];

		//	Xout = new List<double>();

		//	List<double>[] answerY = new List<double> [count];
		//	for ( int i = 0 ; i < answerY.Length ; i++ ) {
		//		answerY[i] = new List<double> ();
		//	}

		//	for ( int i = 0 ; i < iterationCount ; i++ ) {
		//		double[] tempYs2 = new double[count];
		//		double[] tempYs3 = new double[count];
		//		double[] tempYs4 = new double[count];
		//		Y.CopyTo ( tempYs2 , 0 );
		//		Y.CopyTo ( tempYs3 , 0 );
		//		Y.CopyTo ( tempYs4 , 0 );
		//		for ( int j = 0 ; j < count ; j++ ) {//
		//			k1[j] = func[j].Invoke ( X , Y );
		//			tempYs2[j] = Y[j] + h * k1[j] / 2;
		//		}
		//		for ( int j = 0 ; j < count ; j++ ) {//
		//			k2[j] = func[j].Invoke(X+h/2,tempYs2);
		//			tempYs3[j] = Y[j] + h * k2[j] / 2;
		//		}
		//		for ( int j = 0 ; j < count ; j++ ) {
		//			k3[j] = func[j].Invoke ( X + h , tempYs3 );
		//			tempYs4[j] = Y[j] + h * k3[j];
		//		}
		//		for ( int j = 0 ; j < count ; j++ ) {
		//			k4[j] = func[j].Invoke ( X + h / 2 , tempYs4 );
		//		}
		//		Xout.Add ( X );
		//		for ( int j = 0 ; j < count ; j++ ) {
		//			answerY[j].Add ( Y[j] );
					
		//			Y [j] = Y[j] + h * ( k1[j] + 2 * k2[j] + 2 * k3[j] + k4[j] );
					
		//		}
		//		X = X + h;
		//	}


		//	return answerY;
		//}

		public static Dictionary<string , List<double>> Integrate4 ( Dictionary<string , functionD> functions,
																		double t0,
																		Dictionary<string , double> f0 ,																		
																		IntegrationParameters integrationParameters,
																		out CalculationResults calculationResults,
																		Dictionary<string , double> parameters = null,
																		Control parent = null) {
						
			CalculationProgress progress = new CalculationProgress(integrationParameters.PoincareParameters == null?integrationParameters.IterationsCount:integrationParameters.PoincareParameters.HitPointsCount, parent);


			calculationResults = new CalculationResults {
				IterationsCount = 0 ,
				FuncInvoked = 0
			};

			Dictionary<string , double> k1R = new Dictionary<string,double>();
			Dictionary<string , double> k2R = new Dictionary<string,double>();
			Dictionary<string , double> k3R = new Dictionary<string,double>();
			Dictionary<string , double> k4R = new Dictionary<string , double> ();

			Dictionary<string , double> k1L = new Dictionary<string , double> ();
			Dictionary<string , double> k2L = new Dictionary<string , double> ();
			Dictionary<string , double> k3L = new Dictionary<string , double> ();
			Dictionary<string , double> k4L = new Dictionary<string , double> ();

			double tR = t0;
			double tL = t0;
			Dictionary<string , double> fR = new Dictionary<string , double> ( f0 );
			Dictionary<string , double> fL = new Dictionary<string , double> ( f0 );
			double hR=integrationParameters.Step;
			double hL = -hR;

			bool left = integrationParameters.LeftDirection;
			bool right = integrationParameters.RightDirection;
			

			Dictionary<string , List<double>> outputR = new Dictionary<string , List<double>> ();
			Dictionary<string , List<double>> outputL = new Dictionary<string , List<double>> ();

			foreach ( var func in functions ) {
				outputR.Add (func.Key, new List<double>());
				outputL.Add ( func.Key , new List<double> () );
			}
			List<double> tOutR = new List<double> ();
			List<double> tOutL = new List<double> ();
			//var thread = new Thread(() =>
			//{
			int iter = 0;
			for ( int i = 0 ; i <integrationParameters.IterationsCount; i++ ) {
				iter++;
				calculationResults.IterationsCount++;

				if ( integrationParameters.PoincareParameters != null ) {
					i--;
					if ( tOutL.Count + tOutR.Count >= integrationParameters.PoincareParameters.HitPointsCount ) {
						break;
					}
				}
				
				Dictionary<string , double> tempf1R = new Dictionary<string , double> (fR);
				Dictionary<string , double> tempf2R = new Dictionary<string , double> (fR);
				Dictionary<string , double> tempf3R = new Dictionary<string , double> (fR);

				Dictionary<string , double> tempf1L = new Dictionary<string , double> ( fL );
				Dictionary<string , double> tempf2L = new Dictionary<string , double> ( fL );
				Dictionary<string , double> tempf3L = new Dictionary<string , double> ( fL );

				foreach ( var key in functions.Keys ) {

					if ( right ) {
						k1R[key] = functions[key].Invoke ( tR , fR , parameters );
						calculationResults.FuncInvoked++;
						tempf1R[key] = fR[key] + hR * k1R[key] / 2; 
					}

					if ( left ) {
						k1L[key] = functions[key].Invoke ( tL , fL , parameters );
						calculationResults.FuncInvoked++;
						tempf1L[key] = fL[key] + hL * k1L[key] / 2; 
					}
				}
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						k2R[key] = functions[key].Invoke ( tR + hR / 2 , tempf1R , parameters );
						calculationResults.FuncInvoked++;
						tempf2R[key] = fR[key] + hR * k2R[key] / 2; 
					}

					if ( left ) {
						k2L[key] = functions[key].Invoke ( tL + hL / 2 , tempf1L , parameters );
						calculationResults.FuncInvoked++;
						tempf2L[key] = fL[key] + hL * k2L[key] / 2; 
					}
				}
				foreach ( var key in functions.Keys ) {
					if ( right  ) {
						k3R[key] = functions[key].Invoke ( tR + hR / 2 , tempf2R , parameters );
						calculationResults.FuncInvoked++;
						tempf3R[key] = fR[key] + hR * k3R[key]; 
					}

					if ( left ) {
						k3L[key] = functions[key].Invoke ( tL + hL / 2 , tempf2L , parameters );
						calculationResults.FuncInvoked++;
						tempf3L[key] = fL[key] + hL * k3L[key]; 
					}
				}
				foreach ( var key in functions.Keys ) {
					if ( right  ) {
						k4R[key] = functions[key].Invoke ( tR + hR , tempf3R , parameters );
						calculationResults.FuncInvoked++; 
					}
					if ( left ) {
						k4L[key] = functions[key].Invoke ( tL + hL , tempf3L , parameters );
						calculationResults.FuncInvoked++; 
					}
				}

				bool isAddL = false;
				bool isAddR = false;
				if ( integrationParameters.PoincareParameters != null ) {

					if ( right  ) {
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
						ErrorMessage = "During calculations one or more variables became infinity or NaN!",
						CalcedValues = CreateOutput ( left , right , outputL , outputR , tOutL , tOutR,functions.Keys)
					};
					if ( right ) {
						if ( isAddR ) {
							outputR[key].Add ( fR[key] );

						}
						fR[key] = fR[key] + ( hR / 6 ) * ( k1R[key] + 2 * k2R[key] + 2 * k3R[key] + k4R[key] ); 
					}

					if ( left ) {
						if ( isAddL ) {
							outputL[key].Add ( fL[key] );

						}
						fL[key] = fL[key] + ( hL / 6 ) * ( k1L[key] + 2 * k2L[key] + 2 * k3L[key] + k4L[key] ); 
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
			return CreateOutput ( left , right , outputL , outputR , tOutL , tOutR,functions.Keys);
			
		}
		private static Dictionary<string , List<double>> CreateOutput ( bool left , bool right ,
															Dictionary<string , List<double>> outputL ,
															Dictionary<string , List<double>> outputR ,
															List<double> tOutL ,
															List<double> tOutR,
															Dictionary<string , functionD>.KeyCollection keys) {
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

		public static Dictionary<string , List<double>> DormandPrince ( Dictionary<string , functionD> functions ,
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
			Dictionary<string , double> k2R = new Dictionary<string , double> ();
			Dictionary<string , double> k3R = new Dictionary<string , double> ();
			Dictionary<string , double> k4R = new Dictionary<string , double> ();
			Dictionary<string , double> k5R = new Dictionary<string , double> ();
			Dictionary<string , double> k6R = new Dictionary<string , double> ();
			Dictionary<string , double> k7R = new Dictionary<string , double> ();

			Dictionary<string , double> k1L = new Dictionary<string , double> ();
			Dictionary<string , double> k2L = new Dictionary<string , double> ();
			Dictionary<string , double> k3L = new Dictionary<string , double> ();
			Dictionary<string , double> k4L = new Dictionary<string , double> ();
			Dictionary<string , double> k5L = new Dictionary<string , double> ();
			Dictionary<string , double> k6L = new Dictionary<string , double> ();
			Dictionary<string , double> k7L = new Dictionary<string , double> ();


			bool left = integrationParameters.LeftDirection;
			bool right = integrationParameters.RightDirection;

			double tR = t0;
			double tL = t0;
			Dictionary<string , double> fR = new Dictionary<string , double> ( f0 );
			Dictionary<string , double> fL = new Dictionary<string , double> ( f0 );
			double hR = integrationParameters.Step;
			double hL = -hR;


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
			bool rNaN = false;
			bool lNaN = false;

			for ( int i = 0 ; i < integrationParameters.IterationsCount ; i++ ) {
				calculationResults.IterationsCount++;

				if ( integrationParameters.PoincareParameters != null ) {
					i--;
					if ( tOutL.Count + tOutR.Count >= integrationParameters.PoincareParameters.HitPointsCount ) {
						break;
					}
				}

				Dictionary<string , double> tempf1R = new Dictionary<string , double> ( fR );
				Dictionary<string , double> tempf2R = new Dictionary<string , double> ( fR );
				Dictionary<string , double> tempf3R = new Dictionary<string , double> ( fR );
				Dictionary<string , double> tempf4R = new Dictionary<string , double> ( fR );
				Dictionary<string , double> tempf5R = new Dictionary<string , double> ( fR );
				Dictionary<string , double> tempf6R = new Dictionary<string , double> ( fR );

				Dictionary<string , double> tempf1L = new Dictionary<string , double> ( fL );
				Dictionary<string , double> tempf2L = new Dictionary<string , double> ( fL );
				Dictionary<string , double> tempf3L = new Dictionary<string , double> ( fL );
				Dictionary<string , double> tempf4L = new Dictionary<string , double> ( fL );
				Dictionary<string , double> tempf5L = new Dictionary<string , double> ( fL );
				Dictionary<string , double> tempf6L = new Dictionary<string , double> ( fL );

				foreach ( var key in functions.Keys ) {
					if ( right ) {

						k1R[key] = hR * functions[key].Invoke ( tR , fR , parameters );//---1
						calculationResults.FuncInvoked++;
						tempf1R[key] = fR[key] + k1R[key] / 5;//---2
					}

					if ( left ) {
						k1L[key] = hL * functions[key].Invoke ( tL , fL , parameters );
						calculationResults.FuncInvoked++;
						tempf1L[key] = fL[key] + k1L[key] / 5; 
					}
				}
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						k2R[key] = hR * functions[key].Invoke ( tR + hR / 5 , tempf1R , parameters );//---2
						calculationResults.FuncInvoked++;
						tempf2R[key] = fR[key] + k1R[key] * ( 3.0 / 40.0 ) + k2R[key] * ( 9.0 / 40.0 ); ;//---3 
					}

					if ( left ) {
						k2L[key] = hL * functions[key].Invoke ( tL + hL / 5 , tempf1L , parameters );
						calculationResults.FuncInvoked++;
						tempf2L[key] = fL[key] + k1L[key] * ( 3.0 / 40.0 ) + k2L[key] * ( 9.0 / 40.0 );//---3 
					}
				}
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						k3R[key] = hR * functions[key].Invoke ( tR + hR * ( 3.0 / 10.0 ) , tempf2R , parameters );//---3
						calculationResults.FuncInvoked++;
						tempf3R[key] = fR[key] + k1R[key] * ( 44.0 / 45.0 ) - k2R[key] * ( 56.0 / 15.0 ) + k3R[key] * ( 32.0 / 9.0 );//---4 
					}

					if ( left ) {
						k3L[key] = hL * functions[key].Invoke ( tL + hL * ( 3.0 / 10.0 ) , tempf2L , parameters );
						calculationResults.FuncInvoked++;
						tempf3L[key] = fL[key] + k1L[key] * ( 44.0 / 45.0 ) - k2L[key] * ( 56.0 / 15.0 ) + k3L[key] * ( 32.0 / 9.0 ); 
					}
				}
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						k4R[key] = hR * functions[key].Invoke ( tR + hR * ( 4.0 / 5.0 ) , tempf3R , parameters );//---4
						calculationResults.FuncInvoked++;
						tempf4R[key] = fR[key] + k1R[key] * ( 19372.0 / 6561.0 ) - k2R[key] * ( 25360.0 / 2187.0 ) + k3R[key] * ( 64448.0 / 6561.0 ) - k4R[key] * ( 212.0 / 729.0 );//---5 
					}

					if ( left ) {
						k4L[key] = hL * functions[key].Invoke ( tL + hL * ( 4.0 / 5.0 ) , tempf3L , parameters );
						calculationResults.FuncInvoked++;
						tempf4L[key] = fL[key] + k1L[key] * ( 19372.0 / 6561.0 ) - k2L[key] * ( 25360.0 / 2187.0 ) + k3L[key] * ( 64448.0 / 6561.0 ) - k4L[key] * ( 212.0 / 729.0 );//---5
						
					}
				}
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						k5R[key] = hR * functions[key].Invoke ( tR + hR * ( 8.0 / 9.0 ) , tempf4R , parameters );//---5
						calculationResults.FuncInvoked++;
						tempf5R[key] = fR[key] + k1R[key] * ( 9017.0 / 3168.0 ) - k2R[key] * ( 355.0 / 33.0 ) + k3R[key] * ( 46732.0 / 5247.0 ) + k4R[key] * ( 49.0 / 176.0 ) - k5R[key] * ( 5103.0 / 18656.0 );//---6 
					}

					if ( left ) {
						k5L[key] = hL * functions[key].Invoke ( tL + hL * ( 8.0 / 9.0 ) , tempf4L , parameters );
						calculationResults.FuncInvoked++;
						tempf5L[key] = fL[key] + k1L[key] * ( 9017.0 / 3168.0 ) - k2L[key] * ( 355.0 / 33.0 ) + k3L[key] * ( 46732.0 / 5247.0 ) + k4L[key] * ( 49.0 / 176.0 ) - k5L[key] * ( 5103.0 / 18656.0 );//---6
						
					}
				}
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						k6R[key] = hR * functions[key].Invoke ( tR + hR , tempf5R , parameters );//---6
						calculationResults.FuncInvoked++;
						tempf6R[key] = fR[key] + k1R[key] * ( 35.0 / 384.0 ) + k3R[key] * ( 500.0 / 1113.0 ) + k4R[key] * ( 125.0 / 192.0 ) - k5R[key] * ( 2187.0 / 6784.0 ) + k6R[key] * ( 11.0 / 84.0 );//---7 
					}

					if ( left ) {
						k6L[key] = hL * functions[key].Invoke ( tL + hL , tempf5L , parameters );
						calculationResults.FuncInvoked++;
						tempf6L[key] = fL[key] + k1L[key] * ( 35.0 / 384.0 ) + k3L[key] * ( 500.0 / 1113.0 ) + k4L[key] * ( 125.0 / 192.0 ) - k5L[key] * ( 2187.0 / 6784.0 ) + k6L[key] * ( 11.0 / 84.0 );//---7 
					}

				}
				foreach ( var key in functions.Keys ) {
					if ( right ) {
						k7R[key] = hR * functions[key].Invoke ( tR + hR , tempf6R , parameters );//---7 
						calculationResults.FuncInvoked++;
					}
					if ( left ) {
						k7L[key] = hL * functions[key].Invoke ( tL + hL , tempf6L , parameters );
						calculationResults.FuncInvoked++;
					}
				}

				bool isAddL = false;
				bool isAddR = false;
				if ( integrationParameters.PoincareParameters != null ) {

					if ( fR[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
						fR[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
						isAddR = true;
					}
					if ( fL[integrationParameters.PoincareParameters.VariableForSection] > integrationParameters.PoincareParameters.PointOfSection &&
						fL[integrationParameters.PoincareParameters.VariableForSection] < integrationParameters.PoincareParameters.PointOfSection + integrationParameters.PoincareParameters.ThicknessOfLayer ) {
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
					if ( integrationParameters.LeftDirection ) {
						if ( double.IsNaN ( fL[key] ) || double.IsInfinity ( fL[key] ) ) throw new MathematicsCalculationException {
							ErrorMessage = "During calculations one or more variables became infinity or NaN in L!"
						}; 
					}
					if ( integrationParameters.RightDirection ) {
						if ( double.IsNaN ( fR[key] ) || double.IsInfinity ( fR[key] ) ) throw new MathematicsCalculationException {
							ErrorMessage = "During calculations one or more variables became infinity or NaN in R!"
						}; 
					}
					if ( right ) {
						if ( isAddR ) {
							outputR[key].Add ( fR[key] );
						}
						//fR[key] = fR[key] + k1R[key] * ( 5179.0 / 5600.0 ) + k3R[key] * ( 7571.0 / 16695.0 ) + k4R[key] * ( 393.0 / 640.0 ) - k5R[key] * ( 92097.0 / 339200.0 ) + k6R[key] * ( 187.0 / 2100.0 ) + k7R[key] * ( 1.0 / 40.0 );
						fR[key] = fR[key] + k1R[key] * ( 35.0 / 384.0 ) + k3R[key] * ( 500.0 / 1113.0 ) + k4R[key] * ( 125.0 / 192 ) - k5R[key] * ( 2187.0 / 6784.0 ) + k6R[key] * ( 11.0 / 84.0 ) ;
					}
					if ( left) {
						if ( isAddL ) {
							outputL[key].Add ( fL[key] );

						}
						//fL[key] = fL[key] + k1L[key] * ( 5179.0 / 57600.0 ) + k3L[key] * ( 7571.0 / 16695.0 ) + k4L[key] * ( 393.0 / 640.0 ) - k5L[key] * ( 92097.0 / 339200.0 ) + k6L[key] * ( 187.0 / 2100.0 ) + k7L[key] * ( 1.0 / 40.0 );
						fL[key] = fL[key] + k1L[key] * ( 35.0 / 384.0 ) + k3L[key] * ( 500.0 / 1113.0 ) + k4L[key] * ( 125.0 / 192 ) - k5L[key] * ( 2187.0 / 6784.0 ) + k6L[key] * ( 11.0 / 84.0 );
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


			//Dictionary<string , List<double>> output = new Dictionary<string , List<double>> ();//= outputL.Reverse ().ToDictionary ( a => a.Key , a => a.Value ).Union ( outputR ).ToDictionary ( a => a.Key , a => a.Value );
			//if ( tOutL.Count != 0 ) {

			//	foreach ( var key in functions.Keys ) {
			//		outputL[key].Remove ( outputL[key][0] );
			//	}

			//	foreach ( var key in functions.Keys ) {
			//		output.Add ( key , new List<double> () );
			//		outputL[key].Reverse ();
			//		outputL[key].AddRange ( outputR[key] );
			//		output[key] = outputL[key];
			//	}

			//	tOutL.Remove ( tOutL[0] );
			//	tOutL.Reverse ();
			//	tOutL.AddRange ( tOutR );
			//	List<double> tOut = tOutL;
			//	output.Add ( "t" , tOut );
			//}
			//else {
			//	foreach ( var key in functions.Keys ) {
			//		output[key] = outputR[key];
			//	}
			//	output.Add ( "t" , tOutR );
			//}
			progress.Close ();
			//if(progressBar) parent.Invoke ( new Action ( () => {
			//		bar1.Close ();
			//		//bar1 = null;
			//	} ) );
			return CreateOutput ( left , right , outputL , outputR , tOutL , tOutR , functions.Keys ); ;
		}
	}
}
