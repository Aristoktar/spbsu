using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicCompiling;
using Mathematics;
using Mathematics.Analysis;
using Mathematics.Intergration;

namespace SPBSU.Dynamic {
	public partial class FormDynamicEquations : Form {
		private List<TextBox> Equations;
		private List<TextBox> Initials;
		private List<Label> Dts;
		private List<Label> Var0;
		private List<TextBox> Variables;
		private List<Button> DeleteButtons;

		private Dictionary<string , TrackBar> ParamterTrackBars;
		private Dictionary<string , TextBox> ParamterTextBoxes;
		private Dictionary<string , Button> ParametersButtonsEdit;

		private int SplitBetweenEquations = 30;

		private List<string> VarsNames;

		private bool initedgraphGrabli = false;

		public Dictionary<string , Delegate> Funcs;

		public int MaxEquationsCount {
			get;
			set;
		}

		public FormDynamicEquations () {
			InitializeComponent ();
			
			VarsNames = new List<string> ();
			VarsNames.AddRange ( new string[] { "x" , "y" , "z" } );
			MaxEquationsCount = 6;
			Equations = new List<TextBox> ();
			Initials = new List<TextBox> ();
			Dts = new List<Label> ();
			Variables = new List<TextBox> ();
			Var0 = new List<Label> ();

			TextBox InitialTextBox = new TextBox ();
			InitialTextBox.Location = new Point ( 550 , 12 );
			InitialTextBox.Text = "sin(t)";

			TextBox initialInitial = new TextBox ();
			initialInitial.Location = new Point ( 690 , 12 );
			initialInitial.Size = new System.Drawing.Size ( 30 , 20 );
			initialInitial.Text = "0";

			Label initDt = new Label ();
			initDt.Location = new Point ( 500 , 10 );
			initDt.Size = new System.Drawing.Size (20,30);
			initDt.Text =
				@"d
				dt";

			Label initVar0 = new Label ();
			initVar0.Location = new Point (660,15);
			initVar0.Text = VarsNames[Equations.Count ()]+"(t0)=";
			initVar0.Size = new System.Drawing.Size (50,20);
			

			TextBox initVar = new TextBox ();
			initVar.Text = VarsNames[Equations.Count()];
			initVar.Location = new Point (520,12);
			initVar.Size = new System.Drawing.Size (20,10);
			initVar.TextChanged += VariablesChanged;

			Button initDelButton = new Button ();
			initDelButton.Location = new Point (730,12);
			initDelButton.Text = "del";
			initDelButton.Size = new System.Drawing.Size ( 40 , 20 );
			initDelButton.Enabled = false;

			Initials.Add ( initialInitial );
			Equations.Add (InitialTextBox);
			Dts.Add ( initDt );
			Variables.Add ( initVar );
			Var0.Add ( initVar0 );
			this.Controls.Add ( InitialTextBox );
			this.Controls.Add ( initialInitial );
			this.Controls.Add ( initDt );
			this.Controls.Add ( initVar );
			this.Controls.Add ( initVar0 );

			this.Controls.Add ( initDelButton );
			VariablesChanged (null,new EventArgs());
		}

		private void Form1_Load ( object sender , EventArgs e ) {
			////Делаем кнопку круглой
			//System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath ();
			//Button_Path.AddEllipse ( 0 , 0 , this.buttonCalc.Height-5 , this.buttonCalc.Height-5 );
			//Region Button_Region = new Region ( Button_Path );
			//this.buttonCalc.Region = Button_Region;
			this.ParametersButtonsEdit = new Dictionary<string , Button> ();
			this.ParamterTextBoxes = new Dictionary<string , TextBox> ();
			this.ParamterTrackBars = new Dictionary<string , TrackBar> ();

			this.ParamterTextBoxes.Add ( "A" , this.textBoxA );
			this.ParamterTextBoxes.Add ( "B" , this.textBoxB );
			this.ParamterTextBoxes.Add ( "C" , this.textBoxC );
			this.ParamterTextBoxes.Add ( "D" , this.textBoxD );
			this.ParamterTextBoxes.Add ( "E" , this.textBoxE );
			this.ParamterTextBoxes.Add ( "F" , this.textBoxF );

			this.ParamterTrackBars.Add ( "A" , this.trackBarA );
			this.ParamterTrackBars.Add ( "B" , this.trackBarB );
			this.ParamterTrackBars.Add ( "C" , this.trackBarC );
			this.ParamterTrackBars.Add ( "D" , this.trackBarD );
			this.ParamterTrackBars.Add ( "E" , this.trackBarE );
			this.ParamterTrackBars.Add ( "F" , this.trackBarF );

			this.ParametersButtonsEdit.Add ( "A" , this.buttonA );
			this.ParametersButtonsEdit.Add ( "B" , this.buttonB );
			this.ParametersButtonsEdit.Add ( "C" , this.buttonC );
			this.ParametersButtonsEdit.Add ( "D" , this.buttonD );
			this.ParametersButtonsEdit.Add ( "E" , this.buttonE );
			this.ParametersButtonsEdit.Add ( "F" , this.buttonF );
		}

		private void button1_Click ( object sender , EventArgs e ) {

			if ( this.Equations.Count < MaxEquationsCount ) {


				string newVarName;

				if(Equations.Count>=VarsNames.Count){
					newVarName = "v" + ( Equations.Count - VarsNames.Count ).ToString ();
				}else
				{
					newVarName = VarsNames[Equations.Count ()];
				}

				TextBox newTextBox = new TextBox ();
				newTextBox.Location = new Point ( 550 , this.Equations.Last ().Location.Y + this.SplitBetweenEquations );
				

				TextBox newInitial = new TextBox();
				newInitial.Location = new Point ( 690 , this.Equations.Last ().Location.Y + this.SplitBetweenEquations );
				newInitial.Size = new System.Drawing.Size ( 30 , 20 );
				newInitial.Text = "0";

				Label newDt = new Label ();
				newDt.Location = new Point ( 500 , this.Equations.Last ().Location.Y + this.SplitBetweenEquations-2 );
				newDt.Size = new System.Drawing.Size ( 20 , 30 );
				newDt.Text =
					@"d
					dt";

				Label newVar0 = new Label ();
				newVar0.Location = new Point ( 660 , this.Var0.Last().Location.Y+this.SplitBetweenEquations );
				newVar0.Text = newVarName+"(t0)=";

				TextBox newVar = new TextBox ();
				newVar.Text = newVarName;
				newVar.Location = new Point ( 520 , this.Equations.Last ().Location.Y + this.SplitBetweenEquations );
				newVar.Size = new System.Drawing.Size ( 20 , 10 );
				newVar.TextChanged += VariablesChanged;


				this.buttonAddEquation.Location = new Point ( this.buttonAddEquation.Location.X , this.buttonAddEquation.Location.Y + this.SplitBetweenEquations );

				this.Equations.Add ( newTextBox );
				this.Initials.Add ( newInitial );
				Dts.Add ( newDt );
				Variables.Add ( newVar );
				Var0.Add ( newVar0 );

				this.Controls.Add ( newTextBox );
				this.Controls.Add ( newInitial );
				this.Controls.Add ( newDt );
				this.Controls.Add ( newVar );
				this.Controls.Add ( newVar0 );
				VariablesChanged ( null , new EventArgs () );
				if ( this.Equations.Count == MaxEquationsCount ) {
					this.buttonAddEquation.Visible = false;
				}
			}
			else {
				this.buttonAddEquation.Visible = false;
			}
		}


		private void VariablesChanged ( object sender , EventArgs e ) {
			
			int selectedIndexX = this.listBoxX.SelectedIndex;
			int selectedIndexY = this.listBoxY.SelectedIndex;

			this.listBoxX.Items.Clear ();
			this.listBoxY.Items.Clear ();

			this.listBoxX.Items.Add ( "t" );
			this.listBoxY.Items.Add ( "t" );
			foreach ( var str in this.Variables ) {
				this.listBoxX.Items.Add (str.Text);
				this.listBoxY.Items.Add ( str.Text );
			}
			for ( int i = 0 ; i < this.Var0.Count ;i++ ) {
				this.Var0[i].Text = this.Variables[i].Text+"(t0)=";
			}
			if (selectedIndexX != -1) this.listBoxX.SetSelected(selectedIndexX,true);
			else this.listBoxX.SetSelected ( 0 , true );
			if ( selectedIndexY != -1 ) this.listBoxY.SetSelected ( selectedIndexY , true );
			else this.listBoxY.SetSelected ( 1 , true );
			
		}
		private void buttonCalc_Click ( object sender , EventArgs e ) {
			Dictionary<string , double> parameters = new Dictionary<string,double>();
			try {
				Dictionary<string , string> Eques = new Dictionary<string , string> ();
				Dictionary<string , double> initials = new Dictionary<string , double> ();
				for ( int i = 0 ; i < this.Equations.Count ; i++ ) {
					Eques.Add ( Variables[i].Text , Equations[i].Text );
					initials.Add ( Variables[i].Text , Convert.ToDouble ( Initials[i].Text ) );
				}
				parameters = this.ParamterTextBoxes.ToDictionary ( a => a.Key , b => Convert.ToDouble(b.Value.Text) );

				//Compilator compilator = new Compilator ( Eques );
				//var funcs= compilator.GetFuncs ();
				//for ( int i = 0 ; i < this.Initials.Count ; i++ ) {

				//	this.Initials[i].Text = funcs.Skip(i).First().Value.Invoke ( 0 , new Dictionary<string,double>(){{"x",0}}).ToString ();
					
				//}

				//Dictionary<string , double> f0 = new Dictionary<string , double> ();
				//foreach ( var f in funcs ) {
					
				//}
				//var w =RungeKutta.Integrate4 ( funcs , 0 , new Dictionary<string , double> () { { "x" , 0 } } );
				this.graphSystemBehavior1.InitFunctionsD (Eques,parameters);
				this.graphSystemBehavior1.SetAxisToShow ( this.listBoxX.SelectedItem.ToString () , this.listBoxY.SelectedItem.ToString () );
				this.graphSystemBehavior1.f0 = initials;
				this.graphSystemBehavior1.t0 = Convert.ToDouble ( this.textBoxt0.Text );
				if ( !this.initedgraphGrabli ) {

					this.graphSystemBehavior1.setData ( 1 , 0 , 1 , 0 );
					this.initedgraphGrabli = true;
				}
				else {
					this.graphSystemBehavior1.Redraw ();
				}

				//----test
				
			}
			catch(Exception ex)
			{
				if ( ex is DynamicCompilationException ) {
					MessageBox.Show ( ( ex as DynamicCompilationException ).Message );
				}
				else
				{
				MessageBox.Show (ex.Message);
				}
			}
			
			
			
		}

		private void listBoxSystemName_DoubleClick ( object sender , EventArgs e ) {
			switch ( ( sender as ListBox ).SelectedItem.ToString() ) {
				case "Complex System Slides":
					if ( this.Equations.Count >= 2 ) {
						this.Equations[0].Text = "a";
					}
					break;
				case "Harmonic oscillator":
					if ( this.Equations.Count < 2 ) {
						button1_Click ( null , new EventArgs () );					
					}
					this.Equations[0].Text = "p";
					this.Equations[1].Text = "-q";
					this.Variables[0].Text = "q";
					this.Variables[1].Text = "p";
					this.Initials[0].Text = "2";
					this.Initials[1].Text = "1";
					this.textBoxHamiltonian.Text = "p+q";
					break;
				case "Henon-Heilis":
					if ( this.Equations.Count < 4 ) {
						while ( this.Equations.Count != 4 ) {
							button1_Click ( null , new EventArgs () );
						}
					}
					this.Equations[0].Text = "px";
					this.Equations[1].Text = "py";
					this.Variables[0].Text = "x";
					this.Variables[1].Text = "y";
					this.Initials[0].Text = "0";
					this.Initials[1].Text = "0";

					this.Equations[2].Text = "-x-2*x*y";
					this.Equations[3].Text = "-y-x*x+y*y";
					this.Variables[2].Text = "px";
					this.Variables[3].Text = "py";
					this.Initials[2].Text = "0.288790581";
					this.Initials[3].Text = "0";
					this.textBoxHamiltonian.Text = "(px*px+py*py)/2+(x*x+y*y)+x*x*y-y*y*y";
					break;
				case "WikipediaRungeSample":
					if ( this.Equations.Count < 2 ) {
						button1_Click ( null , new EventArgs () );
					}
					this.Equations[0].Text = "y";
					this.Equations[1].Text = "cos(3*t)-4*dy";
					this.Variables[0].Text = "dy";
					this.Variables[1].Text = "y";
					this.Initials[0].Text = "2";
					this.Initials[1].Text = "0.8";
					this.textBoxHamiltonian.Text = "y+dy";
					break;
				case "Lorenz Equation":
					if ( this.Equations.Count < 3 ) {
						button1_Click ( null , new EventArgs () );
						button1_Click ( null , new EventArgs () );
					}
					
					this.Variables[0].Text = "x";
					this.Equations[0].Text = "A*(y - x)";
					this.Initials[0].Text = "0";

					this.Variables[1].Text = "y";
					this.Equations[1].Text = "B*x - y -x*z";
					this.Initials[1].Text = "1";

					this.Variables[2].Text = "z";
					this.Equations[2].Text = "x*y - C*z";
					this.Initials[2].Text = "0";

					this.ParamterTextBoxes["A"].Text = "10";
					this.ParamterTextBoxes["B"].Text = "28";
					this.ParamterTextBoxes["C"].Text = "2.6666";
					break;
				case"Henon Map":
					if ( this.Equations.Count < 2 ) {
						button1_Click ( null , new EventArgs () );
					}
					this.Variables[0].Text = "x";
					this.Equations[0].Text = "1-A*x*x+y";
					this.Initials[0].Text = "0.6313";

					this.Variables[1].Text = "y";
					this.Equations[1].Text = "B*x";
					this.Initials[1].Text = "0.1894";

					this.ParamterTextBoxes["A"].Text = "1.4";
					this.ParamterTextBoxes["B"].Text = "0.3";
					break;
				default: break;
			}
			this.graphSystemBehavior1.Redraw ();
		}

		private void buttonParameterEdit_Click ( object sender , EventArgs e ) {
			
			string key = this.ParametersButtonsEdit.FirstOrDefault ( a => a.Value == ( sender as Button ) ).Key;
			EditPatameterValuesArea form = new EditPatameterValuesArea ( this.ParamterTrackBars[key] );
			form.Text = "Edit " + key;
			form.Show ();
			//form.numericUpDownMin.Value = this.ParamterTrackBars[key].Minimum / ( form.numericUpDownMin.DecimalPlaces * 10 );
			//form.numericUpDownMax.Value = this.ParamterTrackBars[key].Maximum / ( form.numericUpDownMax.DecimalPlaces * 10 );
			
			form.FormClosed += new FormClosedEventHandler ( ( sender1 , e1 ) => {
				this.WindowState = FormWindowState.Normal;
				
			} );
			
			this.WindowState = FormWindowState.Minimized;
			
		}


		
		private void trackBarParameter_Scroll ( object sender , EventArgs e ){
			
			string key = this.ParamterTrackBars.FirstOrDefault ( a => a.Value == ( sender as TrackBar ) ).Key;
			this.ParamterTextBoxes[key].Text = ((double)( sender as TrackBar ).Value/10000).ToString ();
			this.graphSystemBehavior1.Parameters = this.ParamterTextBoxes.ToDictionary ( a => a.Key , b => Convert.ToDouble ( b.Value.Text ) );
			this.graphSystemBehavior1.Redraw ();
			
		}

		private void radioButtonRungeKutta4_CheckedChanged ( object sender , EventArgs e ) {
			this.graphSystemBehavior1.IntegrationType = IntegrationType.RungeKutta4;
		}

		private void radioButton1_CheckedChanged ( object sender , EventArgs e ) {
			this.graphSystemBehavior1.IntegrationType = IntegrationType.EulerMethod;
		}

		private void radioButtonEulerSymplectic_CheckedChanged ( object sender , EventArgs e ) {
			this.graphSystemBehavior1.IntegrationType = IntegrationType.EulerMethodSymplectic;
		}

		private void buttonHamiltonian_Click ( object sender , EventArgs e ) {
			try {

				HamiltonianPlot form = new HamiltonianPlot ();

				Dictionary<string , string> eques = new Dictionary<string , string> ();
				Dictionary<string , double> initials = new Dictionary<string , double> ();
				for ( int i = 0 ; i < this.Equations.Count ; i++ ) {
					eques.Add ( Variables[i].Text , Equations[i].Text );
				}
				Compilator compilator = new Compilator ( new Dictionary<string , string> { { "H" , this.textBoxHamiltonian.Text } } ,
														this.ParamterTextBoxes.ToDictionary ( a => a.Key , b => Convert.ToDouble ( b.Value.Text ) ) ,
														eques.Keys );
				var temt = compilator.GetFuncs ();
				var uio = Hamiltonian.Calc ( temt , this.graphSystemBehavior1.Solutions , this.ParamterTextBoxes.ToDictionary ( a => a.Key , b => Convert.ToDouble ( b.Value.Text ) ) );
				form.graphSystemOscillogram1.setYdata ( uio["H"] );
				//form.graphSystemOscillogram1.setXdata ( uio["t"] );
				form.graphSystemOscillogram1.setData ( 1 , 0 , 1 , 0 );
				form.graphSystemOscillogram1.Refresh ();
				//form.graphSystemOscillogram1.yD
				form.Show ();
			}
			catch ( Exception ex) {
				if ( ex is DynamicCompilationException ) {
					MessageBox.Show (( ex as DynamicCompilationException ).Message);
				}else {
					MessageBox.Show ( ex.Message );
				}
				

			}
		}

		private void buttonLyapunov_Click ( object sender , EventArgs e ) {
			

			foreach ( var v in this.listBoxY.Items ) {
				if ( v.ToString() == "t" ) continue;

				LyapunovSpectrumPlot form = new LyapunovSpectrumPlot ();
				var parameters = this.ParamterTextBoxes.ToDictionary ( a => a.Key , b => Convert.ToDouble ( b.Value.Text ) );
				form.graphSystemOscillogram1.setYdata ( Lyapunov.Spectrum ( this.graphSystemBehavior1.Solutions , this.graphSystemBehavior1.functionsD , parameters )[v.ToString()] );
				form.graphSystemOscillogram1.axisXlabel = "t";
				form.graphSystemOscillogram1.axisYlabel = "λ(" + v.ToString () + ")";
				form.Show ();
				form.graphSystemOscillogram1.zoom100Percent ();
			}
		}

		private void radioButtonIterativ_CheckedChanged ( object sender , EventArgs e ) {
			this.graphSystemBehavior1.IntegrationType = IntegrationType.Iterative;
		}
	}
}
