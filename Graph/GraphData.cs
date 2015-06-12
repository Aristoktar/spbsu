using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph {
	[Serializable()]
	public class GraphData {
		public List<double> dataY {
			get;
			set;
		}
		public List<double> dataX {
			get;
			set;
		}
		public Color DataColor {
			get;
			set;
		}
		public Dictionary<string , List<double>> Solution {
			get;
			set;
		}
	}
}
