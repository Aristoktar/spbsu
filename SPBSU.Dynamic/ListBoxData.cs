using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPBSU.Dynamic {
	public class ListBoxData {
		public int va {
			get;
			set;
		}

		public string Data {
			get;
			set;
		}

		public override string ToString () {
			return Data.ToString ();
		}
	}
}
