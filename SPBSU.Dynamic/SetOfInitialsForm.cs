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
	public partial class SetOfInitialsForm : Form {
		public List<Dictionary<string , double>> SetOfInitials {
			get;
			set;
		}

		public List<Dictionary<string , TextBox>> SetOfInitialsTextBoxes {
			get;
			set;
		}
		List<string> Keys {
			get;
			set;
		}
		private int InitPosY = 50;
		private int DeltaPsY = 30;

		private int PosX = 20;
		private int DeltaPosX = 60;
		public SetOfInitialsForm ( List<string> keys,List<Dictionary<string , double>> setOfInitials) {
			InitializeComponent ();
			this.Keys = keys;
			this.SetOfInitialsTextBoxes = new List<Dictionary<string , TextBox>> ();
			if ( setOfInitials != null ) {
				this.SetOfInitials = setOfInitials;
				foreach ( var ini in setOfInitials ) {
					AddInitial ();
				}

				for ( int i=0;i< this.SetOfInitials.Count;i++ ) {
					foreach ( var key in keys ) {
						this.SetOfInitialsTextBoxes.ElementAt ( i )[key].Text = this.SetOfInitials.ElementAt ( i )[key].ToString ();
					}
				}

			}
			else {
				AddInitial ();
			}
			this.buttonClose.Location =new Point(this.buttonClose.Location.X, ( keys.Count ) * this.DeltaPsY + this.InitPosY);
			this.buttonSaveClose.Location = new Point ( this.buttonSaveClose.Location.X , ( keys.Count  ) * this.DeltaPsY + this.InitPosY );
			this.buttonCalculate.Location = new Point ( this.buttonCalculate.Location.X , ( keys.Count  ) * this.DeltaPsY + this.InitPosY );
		}

		

		private void AddInitial () {
			int posY = this.InitPosY;
			Dictionary<string , TextBox> initials = new Dictionary<string , TextBox> ();
			foreach ( var key in this.Keys ) {
				TextBox box = new TextBox ();
				box.Size = new Size(50,30);
				box.Location = new Point (this.PosX,posY);
				posY+=this.DeltaPsY;
				this.Controls.Add ( box );
				initials.Add ( key,box );
			}
			this.SetOfInitialsTextBoxes.Add ( initials );
			this.PosX+=this.DeltaPosX;
		}

		private void RemoveLast () {
			if ( this.SetOfInitialsTextBoxes.Count == 1 ) {
				MessageBox.Show ("Left only one!");
				return;
			}
			foreach ( var key in this.Keys ) {
				this.Controls.Remove(this.SetOfInitialsTextBoxes.Last ()[key]);
			}
			this.SetOfInitialsTextBoxes.Remove ( this.SetOfInitialsTextBoxes.Last () );
			this.PosX -= this.DeltaPosX;
		}

		private void SetOfInitialsForm_Load ( object sender , EventArgs e ) {

		}

		private void buttonAdd_Click ( object sender , EventArgs e ) {
			this.AddInitial ();
		}

		private void buttonRamove_Click ( object sender , EventArgs e ) {
			this.RemoveLast ();
		}

		private void buttonChangeCount_Click ( object sender , EventArgs e ) {

		}

		private void buttonClose_Click ( object sender , EventArgs e ) {
			this.Close ();
		}

		private void buttonSaveClose_Click ( object sender , EventArgs e ) {
			try {

				this.SetOfInitials = this.SetOfInitialsTextBoxes.Select ( a => a.ToDictionary ( b => b.Key , b => Convert.ToDouble ( b.Value.Text ) ) ).ToList ();

				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
			catch {
				MessageBox.Show ("error");
			}
		}
	}
}
