namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
		public override void Up () {
			CreateTable (
				"dbo.EquationsSets" ,
				c => new {
					Id = c.Int ( nullable: false , identity: true ) ,
					Name = c.String () ,
					ParameterCount = c.Int ( nullable: false ) ,
				} )
				.PrimaryKey ( t => t.Id );

			CreateTable (
				"dbo.ParametersSets" ,
				c => new {
					Id = c.Int ( nullable: false , identity: true ) ,
					EquationsSetId = c.Int ( nullable: false ) ,
					Result = c.Int ( nullable: false ) ,
				} )
				.PrimaryKey ( t => t.Id )
				.ForeignKey ( "dbo.EquationsSets" , t => t.EquationsSetId , cascadeDelete: true )
				.Index ( t => t.EquationsSetId );

			CreateTable (
				"dbo.Parameters" ,
				c => new {
					Id = c.Int ( nullable: false , identity: true ) ,
					value = c.Double ( nullable: false ) ,
					EquationsSetId = c.Int ( nullable: false ) ,
					ParametersSet_Id = c.Int () ,
				} )
				.PrimaryKey ( t => t.Id )
				.ForeignKey ( "dbo.EquationsSets" , t => t.EquationsSetId , cascadeDelete: true )
				.ForeignKey ( "dbo.ParametersSets" , t => t.ParametersSet_Id )
				.Index ( t => t.EquationsSetId )
				.Index ( t => t.ParametersSet_Id );

		}

		public override void Down () {
			DropForeignKey ( "dbo.Parameters" , "ParametersSet_Id" , "dbo.ParametersSets" );
			DropForeignKey ( "dbo.Parameters" , "EquationsSetId" , "dbo.EquationsSets" );
			DropForeignKey ( "dbo.ParametersSets" , "EquationsSetId" , "dbo.EquationsSets" );
			DropIndex ( "dbo.Parameters" , new[] { "ParametersSet_Id" } );
			DropIndex ( "dbo.Parameters" , new[] { "EquationsSetId" } );
			DropIndex ( "dbo.ParametersSets" , new[] { "EquationsSetId" } );
			DropTable ( "dbo.Parameters" );
			DropTable ( "dbo.ParametersSets" );
			DropTable ( "dbo.EquationsSets" );
		}
    }
}
