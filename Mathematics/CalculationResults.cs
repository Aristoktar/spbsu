using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics {
	public class CalculationResults {
		public TimeSpan TimeElapsed {
			get;
			set;
		}
		public int IterationsCount {
			get;
			set;
		}

		public int? FuncInvoked {
			get;
			set;
		}
	}
}
