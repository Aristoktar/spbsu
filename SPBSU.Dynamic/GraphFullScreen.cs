using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPBSU.Dynamic {
	public partial class GraphFullScreen : Form {
		public GraphFullScreen () {
			InitializeComponent ();
			//this.WindowState = FormWindowState.Maximized;
			this.Height = 1000;
			this.Width = 1300;
		}

		private void GraphFullScreen_SizeChanged ( object sender , EventArgs e ) {
			this.graphDynamicType.Size = new Size (this.Size.Width-17,this.Size.Height -45);
		}
	}
}
