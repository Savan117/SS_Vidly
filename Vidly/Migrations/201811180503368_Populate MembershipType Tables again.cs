namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class PopulateMembershipTypeTablesagain : DbMigration
	{
		public override void Up()
		{
			Sql("Insert into membershipTypes (Id, SignUpFee, DurationInMonths,DiscountRate,MembershipPackage) Values (1, 0, 0,0,'Pay as You Go')");
			Sql("Insert into membershipTypes (Id, SignUpFee, DurationInMonths,DiscountRate,MembershipPackage) Values (2, 30, 1,10,'Monthly')");
			Sql("Insert into membershipTypes (Id, SignUpFee, DurationInMonths,DiscountRate,MembershipPackage) Values (3, 90, 3,15,'Quaterly')");
			Sql("Insert into membershipTypes (Id, SignUpFee, DurationInMonths,DiscountRate,MembershipPackage) Values (4, 300, 12,20,'Annual')");
		}
		
		public override void Down()
		{
		}
	}
}
