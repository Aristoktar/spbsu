using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Analysis {
	public class FunctionInfo {

		/// <summary>
		/// Is function periodic.
		/// </summary>
		public bool Periodic {
			get;
			set;
		}

		/// <summary>
		/// If function is not periodic = 0.
		/// </summary>
		public double PeriodValue {
			get;
			set;
		}

		/// <summary>
		/// Count of point for analysis.
		/// </summary>
		public int PointsCount {
			get;
			set;
		}

		public bool isConverges {
			get;
			set;
		}

		public double ConvergeValue {
			get;
			set;
		}
	}
}
