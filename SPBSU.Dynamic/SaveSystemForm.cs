using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPBSU.Dynamic.Data;

namespace SPBSU.Dynamic {
	public partial class SaveSystemForm : Form {
		EquationsSet Set {
			get;
			set;
		}
		FormDynamicEquations Paren;
		public SaveSystemForm ( EquationsSet set,FormDynamicEquations p) {
			InitializeComponent ();
			this.Set = set;
			Paren = p;
		}

		private void button2_Click ( object sender , EventArgs e ) {
			this.Close ();
		}

		private void button1_Click ( object sender , EventArgs e ) {
			Serializer ser = new Serializer ();
			DirectoryInfo info = new DirectoryInfo ( Application.StartupPath + @"\EquationsSets\" );
			if ( !info.Exists )	Directory.CreateDirectory ( Application.StartupPath + @"\EquationsSets\" );
			if ( info.GetFiles ().Select ( a => a.Name ).ToList ().Contains ( this.textBox1.Text + ".equation" ) ) {
				MessageBox.Show ( "name already exsist!" );
				return;
			}
			if(this.textBox1.Text != "")	ser.SerializeObjectEquationsSet ( "EquationsSets/" + this.textBox1.Text + ".equation" , this.Set );
			else
			{
				MessageBox.Show("empty input!");
				return;
			}
			Paren.listBoxSystemName.Items.Add ( this.textBox1.Text );
			this.Close ();
		}
	}
}
