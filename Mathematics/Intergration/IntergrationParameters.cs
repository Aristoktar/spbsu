using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Intergration {
	[Serializable()]
	public class IntegrationParameters {
		public double Step {
			get;
			set;
		}
		public double Error {
			get;
			set;
		}

		public bool LeftDirection {
			get;
			set;
		}

		public bool RightDirection {
			get;
			set;
		}

		public int IterationsCount {
			get;
			set;
		}

		public PoincareSectionParameters PoincareParameters {
			get;
			set;
		}
	}
}
