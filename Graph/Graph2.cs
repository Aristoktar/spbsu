using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph {
	public partial class Graph2 : UserControl {

		/// <summary>
		/// Gets or sets a value indicating whether the Axes are displayed.
		/// </summary>\
		public bool IsAxisVisible {
			get;
			set;
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Zoom buttons are displayed.
		/// </summary>
		public bool ZoomButtonsExist {
			get;
			set;
		}
		/// <summary>
		/// Gets or sets a value indicating whether the Zoom buttons are displayed.
		/// </summary>
		public bool MoveButtonsExist {
			get;
			set;
		}
		private string _axisXlabel;
		/// <summary>
		/// axis x label
		/// </summary>
		public string axisXlabel {
			get {
				return string.IsNullOrEmpty ( _axisXlabel ) ? "x" : _axisXlabel;
			}
			set {
				_axisXlabel = value;
			}
		}
		private string _axisYlabel;
		/// <summary>
		/// axis Y label
		/// </summary>
		public string axisYlabel {
			get {
				return string.IsNullOrEmpty ( _axisYlabel ) ? "y" : _axisYlabel;
			}
			set {
				_axisYlabel = value;
			}
		}

		public bool scatterGraph {
			get;
			set;
		}


		public Graph2 () {
			InitializeComponent ();
		}
	}
}
