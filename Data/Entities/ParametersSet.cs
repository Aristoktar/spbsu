using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace Data.Entities {
	public class ParametersSet {
		public int Id {
			get;
			set;
		}

		public int EquationsSetId {
			get;
			set;
		}
		public EquationsSetResult Result {
			get;
			set;
		}

		public virtual ICollection<Parameter> Parameters {
			get;
			set;
		}

		public virtual EquationsSet EquationsSet {
			get;
			set;
		}
	}
}
