using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data {
	public class DataProvider:DbContext {

		/// <summary>
		/// Model creating handler.
		/// </summary>
		/// <param name="modelBuilder">Model builder.</param>
		protected override void OnModelCreating ( DbModelBuilder modelBuilder ) {
			base.OnModelCreating ( modelBuilder );
		}

		public DbSet<EquationsSet> EquationsSets {
			get;
			set;
		}
		public DbSet<ParametersSet> ParametersSets {
			get;
			set;
		}

		public DbSet<Parameter> Parameters {
			get;
			set;
		}

		public IQueryable<EquationsSet> EquationsSetsQuery {
			get {
				return EquationsSets;
			}
		}
		public IQueryable<ParametersSet> ParametersSetsQuery {
			get {
				return ParametersSets;
			}
		}
		public IQueryable<Parameter> ParametersQuery {
			get {
				return Parameters;
			}
		}

		public void AddSystem ( EquationsSet set ) {
			EquationsSets.Add (set);
			SaveChanges ();
		}
	}
}
