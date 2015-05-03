using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPBSU.Dynamic {
	public class IncorrectInputException :Exception {
		public string ErrorMessage {
			get;
			set;
		}
	}
}
