﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics {
	[Serializable()]
	public class PoincareSectionParameters {
		public string VariableForSection {
			get;
			set;
		}
		public double ThicknessOfLayer {
			get;
			set;
		}
		public int HitPointsCount {
			get;
			set;
		}
		public double PointOfSection {
			get;
			set;
		}
		public string H {
			get;
			set;
		}
		public string HForDet {
			get;
			set;
		}
		public string HForDetEquation {
			get;
			set;
		}
		public bool CheckDetH {
			get;
			set;
		}

	}
}
