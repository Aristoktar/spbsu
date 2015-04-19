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
		protected override void calculate () {
			//base.calculate ();
			
		}
		public void InitFunctionsD ( Dictionary<string , string> functions ) {
			this.UseDynamicFunctions = true;
			Compilator compilator = new Compilator ( functions );
			this.functionsD = compilator.GetFuncs ();
		}

		public GraphDynamicType () {
			InitializeComponent ();
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
	}
}
