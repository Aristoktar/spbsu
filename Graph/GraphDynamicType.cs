using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mathematics.Delegates;
using DynamicCompiling;
using Mathematics.Intergration;
using Mathematics;
using Graph.Events;
using System.Diagnostics;

namespace Graph {
	public partial class GraphDynamicType : Graph {

		public double t0 {
			get;
			set;
		}
		public Dictionary<string , double> f0 {
			get;
			set;
		}
		public Dictionary<string , functionD> functionsD {
			get;
			set;
		}
		public bool UseDynamicFunctions {
			get;
			set;
		}

		public Dictionary<string , List<double>> Solutions {
			get;
			set;
		}

		public IntegrationType IntegrationType {
			get;
			set;
		}
		public Dictionary<string , double> Parameters {
			get;
			set;
		}

		public IntegrationParameters IntergrationParameters {
			get;
			set;
		}

		public bool deletePastData = false;
		public Color ColorForNewData {
			get;
			set;
		}


		protected override void calculate ( out CalculationFinishedEventArgs calculationFinishedEventArgs ) {
			Stopwatch s = new Stopwatch ();
			s.Start ();
			CalculationResults calculationResults = new CalculationResults ();

			if ( this.ColorForNewData.IsEmpty ) {
				this.ColorForNewData = Color.Black;
			}
			//base.calculate ();
			try {

				if ( UseDynamicFunctions ) {
					
					
					Dictionary<string , List<double>> solution = new Dictionary<string , List<double>> ();
					
					switch ( this.IntegrationType ) {
						case IntegrationType.RungeKutta4:
							solution = RungeKutta.Integrate4 ( this.functionsD , t0 , f0 ,this.IntergrationParameters, out calculationResults , Parameters , this );
							break;
						case IntegrationType.EulerMethod:
							solution = Euler.Integrate ( this.functionsD , t0 , f0 , this.IntergrationParameters , out calculationResults , Parameters , this );
							break;
						case Mathematics.Intergration.IntegrationType.EulerMethodImplicit:
							solution = Euler.IntegrateImplicit ( this.functionsD , t0 , f0 , this.IntergrationParameters , out calculationResults , Parameters , this );
							break;
						case Mathematics.Intergration.IntegrationType.Iterative:
							solution = Iterative.Integrate ( this.functionsD , t0 , f0 , Parameters );
							break;
						case Mathematics.Intergration.IntegrationType.PoincareMap:
							solution = Poincare.Calculate ( this.functionsD , t0 , f0 , Parameters );
							break;
						case Mathematics.Intergration.IntegrationType.DormandPrince:
							solution = RungeKutta.DormandPrince ( this.functionsD , t0 , f0 , this.IntergrationParameters , out calculationResults , Parameters , this );
							break;
						case Mathematics.Intergration.IntegrationType.Symplectic4:
							//solution = Heuns.Integrate ( this.functionsD , t0 , f0 , this.IntergrationParameters , out calculationResults , Parameters , this );
							solution = RungeKutta.IntegrateSymplectic ( this.functionsD , t0 , f0 , this.IntergrationParameters , out calculationResults , Parameters , this );
							break;
						case Mathematics.Intergration.IntegrationType.EulerMethodSymplectic:
							solution = RungeKutta.IntegrateEilerSymplectic( this.functionsD , t0 , f0 , this.IntergrationParameters , out calculationResults , Parameters , this );
							break;

						default: break;
					}
					s.Stop ();
					//this.Solutions = solution;
					//if ( this.deletePastData ) {

					//	dataX = solution[this.AxisXlabel];
					//	dataY = solution[this.AxisYlabel];
					//}
					//else {
					//	if ( dataX == null ) dataX = new List<double> ();
					//	if ( dataY == null ) dataY = new List<double> ();

					//	dataX.AddRange(solution[this.AxisXlabel]);
					//	dataY.AddRange(solution[this.AxisYlabel]);
					//}


					if ( this.deletePastData ) {
						this.Data = new List<GraphData> ();
					}
					else {
						if ( this.Data == null ) this.Data = new List<GraphData> ();
					}

					this.Data.Add ( new GraphData {
						dataX = solution[this.AxisXlabel] ,
						dataY = solution[this.AxisYlabel] ,
						Solution = solution,
						DataColor = this.ColorForNewData
					} );
					

					calculationFinishedEventArgs = new CalculationFinishedEventArgs {
						TimeElapsed = s.Elapsed ,
						FuncInvoked = calculationResults.FuncInvoked ,
						IterationsCount = calculationResults.IterationsCount
					};
					return;
				}
				
			}catch(MathematicsCalculationException ex){
				MessageBox.Show(ex.ErrorMessage);
				if ( ex.CalcedValues != null ) {
					s.Stop ();
					//this.Solutions = ex.CalcedValues;
					//dataX = ex.CalcedValues[this.AxisXlabel];
					//dataY = ex.CalcedValues[this.AxisYlabel];]

					if ( this.deletePastData ) {
						this.Data = new List<GraphData> ();
					}
					else {
						if ( this.Data == null ) this.Data = new List<GraphData> ();
					}

					this.Data.Add ( new GraphData {
						dataX = ex.CalcedValues[this.AxisXlabel] ,
						dataY = ex.CalcedValues[this.AxisYlabel] ,
						Solution = ex.CalcedValues,
						DataColor = this.ColorForNewData
					} );

					calculationFinishedEventArgs = new CalculationFinishedEventArgs {
						TimeElapsed = s.Elapsed ,
						FuncInvoked = calculationResults.FuncInvoked ,
						IterationsCount = calculationResults.IterationsCount
					};
					return;
				}
					
			}
			calculationFinishedEventArgs = new CalculationFinishedEventArgs ();
		
			
			
		}
		public void InitFunctionsD ( Dictionary<string , string> functions, Dictionary<string , double> parameters) {
			this.UseDynamicFunctions = true;
			Compilator compilator = new Compilator ( functions , parameters );
			this.Parameters = parameters;
			this.functionsD = compilator.GetFuncs ();
		}

		public void SetAxisToShow (string x="t", string y="x") {
			this.AxisXlabel = x;
			this.AxisYlabel = y;
		}

		public GraphDynamicType () {
			InitializeComponent ();
			this.Scatter = true;
		}

		private void GraphDynamicType_Load ( object sender , EventArgs e ) {

		}
		public List<double> GetAxisData ( Axes axis ) {

			switch ( axis ) {
				case Axes.x: return new List<double> ( this.dataX );
				case Axes.y: return new List<double> ( this.dataY );
				default: return null;
			}
		}

		private void checkBoxScatter_CheckedChanged ( object sender , EventArgs e ) {
			if ( this.checkBoxScatter.Checked ) this.Scatter = true;
			else this.Scatter = false;
			//if ( this.dataX != null && this.dataY != null)
			//	this.RedrawWithSetAxesData ( this.dataX.ToList () , this.dataY.ToList () );
			
		}

		private void buttonZoom100_Click ( object sender , EventArgs e ) {
			
			
				//if ( Double.IsInfinity ( xMinValue ) || Double.IsNaN ( xMinValue ) ) {
				//	xMinValue = -1000;
				//	xMinValue = dataX.Where(a=)
				//}
				//if ( Double.IsInfinity ( xMaxValue ) || Double.IsNaN ( xMaxValue ) ) {
				//	xMaxValue = 1000;
				//}
				//if ( Double.IsInfinity ( yMinValue ) || Double.IsNaN ( yMinValue ) ) {
				//	yMinValue = -1000;
				//}
				//if ( Double.IsInfinity ( yMaxValue ) || Double.IsNaN ( yMaxValue ) ) {
				//	yMaxValue = 1000;
				//}
			
			this.Redraw ();
		}

		private void GraphDynamicType_SizeChanged ( object sender , EventArgs e ) {
			//try {
			this.checkBoxScatter.Location = new Point ( 300 , this.Height - 20 );
			//}
			//catch ( Exception ex ) {
			//}
		}

		public void RedrawWithChangeData(string X,string Y) {
			
			this.AxisXlabel = X;
			this.AxisYlabel = Y;
			if ( this.Data == null ) return;
			foreach ( var data in this.Data ) {
				data.dataX = data.Solution[X];
				data.dataY = data.Solution[Y];
			}
			this.CreateGraphImage ();
			this.Invalidate ();
		}
	}
}
