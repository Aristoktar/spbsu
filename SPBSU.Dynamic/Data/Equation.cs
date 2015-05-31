using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPBSU.Dynamic.Data {
	[Serializable()]
	public class Equation {
		public string Var {
			get;
			set;
		}
		public string Text {
			get;
			set;
		}
		public double Var0 {
			get;
			set;
		}
		public Equation () {
		}

	}
}
