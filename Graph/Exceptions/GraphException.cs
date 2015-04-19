using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Exceptions {
	public class GraphException :Exception{
		public GraphExceptionType Type {
			get;
			set;
		}

		public string Message {
			get;
			set;
		}

	}
}
