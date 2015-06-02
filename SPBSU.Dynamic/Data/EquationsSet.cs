using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Mathematics.Intergration;

namespace SPBSU.Dynamic.Data {
	[Serializable()]
	public class EquationsSet : ISerializable {
		public Dictionary<string , Equation> Equations {
			get;
			set;
		}
		public Dictionary<string , double> Parameters {
			get;
			set;
		}
		public double t0 {
			get;
			set;
		}
		public IntegrationParameters IntegrationParameters {
			get;
			set;
		}

		public string Hamiltonian {
			get;
			set;
		}
		public List<Dictionary<string , double>> SetOfInitials {
			get;
			set;
		}

		public EquationsSet () {
		}
		public EquationsSet ( SerializationInfo info , StreamingContext ctxt ) {
			this.Equations = (Dictionary<string , Equation>) info.GetValue ( "Equations" , typeof ( Dictionary<string , Equation> ) );
			this.Parameters = (Dictionary<string , double>) info.GetValue ( "Parameters" , typeof ( Dictionary<string , double> ) );
			this.IntegrationParameters = (IntegrationParameters) info.GetValue ( "IntegrationParameters" , typeof ( IntegrationParameters ) );
			this.SetOfInitials = (List<Dictionary<string , double>>) info.GetValue ( "SetOfInitials" , typeof ( List<Dictionary<string , double>> ) );
			this.t0 = (double) info.GetValue ( "t0" , typeof ( double ) );
			this.Hamiltonian = (string) info.GetString ( "Hamiltonian");
		}
		public void GetObjectData ( SerializationInfo info , StreamingContext context ) {
			info.AddValue ( "Equations" , this.Equations );
			info.AddValue ( "Parameters" , this.Parameters );
			info.AddValue ( "t0" , t0 );
			info.AddValue ( "IntegrationParameters" , this.IntegrationParameters );
			info.AddValue ( "Hamiltonian" , this.Hamiltonian );
			info.AddValue ( "SetOfInitials" , this.SetOfInitials );

		}
	}
}
