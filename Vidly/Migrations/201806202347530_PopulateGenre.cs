namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class PopulateGenre : DbMigration
	{
		public override void Up()
		{
			Sql("Insert into Genres(Description) Values('Comedy')");
			Sql("Insert into Genres(Description) Values('Action')");
			Sql("Insert into Genres(Description) Values('Adventure')");
			Sql("Insert into Genres(Description) Values('Romance')");
			Sql("Insert into Genres(Description) Values('Drama')");
			Sql("Insert into Genres(Description) Values('Thriller')");
			Sql("Insert into Genres(Description) Values('Sport')");
			Sql("Insert into Genres(Description) Values('Horror')");
		}
		
		public override void Down()
		{
		}
	}
}
