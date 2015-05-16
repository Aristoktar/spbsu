﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics {
	public class MathematicsCalculationException:Exception {
		public string ErrorMessage {
			get;
			set;
		}
		public Dictionary<string , List<double>> CalcedValues {
			get;
			set;
		}
	}
}
