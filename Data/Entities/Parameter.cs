using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities {
	public class Parameter {
		public int Id {
			get;
			set;
		}
		
		public double value {
			get;
			set;
		}
		public int EquationsSetId {
			get;
			set;
		}

		public virtual EquationsSet EquationsSet {
			get;
			set;
		}

	}
}
