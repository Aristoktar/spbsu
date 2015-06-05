using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Graph;
using Mathematics.Intergration;

namespace SPBSU.Dynamic.Data {
	[Serializable()]
	public class EquationSetWithData {
		public EquationsSet EqSet {
			get;
			set;
		}

		public List<GraphData> Data {
			get;
			set;
		}

		public IntegrationType IntegrType {
			get;
			set;
		}
		public EquationSetWithData () {
		}
		public EquationSetWithData ( SerializationInfo info , StreamingContext ctxt ) {
			this.EqSet = (EquationsSet) info.GetValue ( "EqSet" , typeof ( EquationsSet ) );
			this.Data = (List<GraphData>) info.GetValue ( "Data" , typeof ( List<GraphData> ) );
			this.IntegrType = (IntegrationType) info.GetValue ( "Data" , typeof ( IntegrationType ) );
			
		}
		public void GetObjectData ( SerializationInfo info , StreamingContext context ) {
			info.AddValue ( "EqSet" , this.EqSet );
			info.AddValue ( "Data" , this.Data );
			info.AddValue ( "IntegrType" , this.IntegrType );
			
		}
	}
}
