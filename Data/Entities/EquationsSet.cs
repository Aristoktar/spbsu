using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities {
	public class EquationsSet {
		public int Id {
			get;
			set;
		}
		public string Name {
			get;
			set;
		}
		public int ParameterCount {
			get;
			set;
		}
		public virtual ICollection<ParametersSet> ParametersSet {
			get;
			set;
		}
	}
}
