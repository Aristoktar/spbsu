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
using Mathematics.Intergration;

namespace SPBSU.Dynamic {
	public partial class FormDynamicEquations : Form {
		private List<TextBox> Equations;
		private List<TextBox> Initials;
		private List<Label> Dts;
		private List<TextBox> Variables;
		private int SplitBetweenEquations = 30;

		private List<string> VarsNames;

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

			TextBox initVar = new TextBox ();
			initVar.Text = VarsNames[Equations.Count()];
			initVar.Location = new Point (520,12);
			initVar.Size = new System.Drawing.Size (20,10);

			Initials.Add ( initialInitial );
			Equations.Add (InitialTextBox);
			Dts.Add ( initDt );
			Variables.Add ( initVar );
			this.Controls.Add ( InitialTextBox );
			this.Controls.Add ( initialInitial );
			this.Controls.Add ( initDt );
			this.Controls.Add ( initVar );
			VariablesChanged (null,new EventArgs());
		}

		private void Form1_Load ( object sender , EventArgs e ) {

		}

		private void button1_Click ( object sender , EventArgs e ) {

			if ( this.Equations.Count < MaxEquationsCount ) {

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

				TextBox newVar = new TextBox ();
				if(Equations.Count>=VarsNames.Count){
				newVar.Text = "v"+(Equations.Count-VarsNames.Count).ToString();
				}else
				{
					newVar.Text = VarsNames[Equations.Count ()];
				}
				newVar.Location = new Point ( 520 , this.Equations.Last ().Location.Y + this.SplitBetweenEquations );
				newVar.Size = new System.Drawing.Size ( 20 , 10 );
				newVar.TextChanged += VariablesChanged;


				this.buttonAddEquation.Location = new Point ( this.buttonAddEquation.Location.X , this.buttonAddEquation.Location.Y + this.SplitBetweenEquations );

				this.Equations.Add ( newTextBox );
				this.Initials.Add ( newInitial );
				Dts.Add ( newDt );
				Variables.Add ( newVar );
				this.Controls.Add ( newTextBox );
				this.Controls.Add ( newInitial );
				this.Controls.Add ( newDt );
				this.Controls.Add ( newVar );
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
			
			foreach ( var str in this.Variables ) {
				this.listBoxX.Items.Add (str.Text);
				this.listBoxY.Items.Add ( str.Text );
			}
			if (selectedIndexX != -1) this.listBoxX.SetSelected(selectedIndexX,true);
			if ( selectedIndexY != -1 ) this.listBoxY.SetSelected ( selectedIndexY , true );
			
		}
		private void buttonCalc_Click ( object sender , EventArgs e ) {
			try {
				Dictionary<string , string> Eques = new Dictionary<string , string> ();
				Dictionary<string , double> initials = new Dictionary<string , double> ();
				for ( int i = 0 ; i < this.Equations.Count ; i++ ) {
					Eques.Add ( Variables[i].Text , Equations[i].Text );
					initials.Add ( Variables[i].Text , Convert.ToDouble ( Initials[i].Text ) );
				}
				

				//Compilator compilator = new Compilator ( Eques );
				//var funcs= compilator.GetFuncs ();
				//for ( int i = 0 ; i < this.Initials.Count ; i++ ) {

				//	this.Initials[i].Text = funcs.Skip(i).First().Value.Invoke ( 0 , new Dictionary<string,double>(){{"x",0}}).ToString ();
					
				//}

				//Dictionary<string , double> f0 = new Dictionary<string , double> ();
				//foreach ( var f in funcs ) {
					
				//}
				//var w =RungeKutta.Integrate4 ( funcs , 0 , new Dictionary<string , double> () { { "x" , 0 } } );
				this.graphSystemBehavior1.InitFunctionsD (Eques);
				this.graphSystemBehavior1.f0 = initials;
				this.graphSystemBehavior1.t0 = Convert.ToDouble ( this.textBoxt0.Text );
				this.graphSystemBehavior1.setData ( 1 , 0 , 1 , 0);
			}
			catch(Exception ex)
			{
				MessageBox.Show (ex.Message);
			}

			
		}
	}
}
