namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class UpdateMembershipPackageOnMembershipType : DbMigration
	{
		public override void Up()
		{
			Sql("Update MembershipTypes Set MembershipPackage='Pay as You Go' Where DiscountRate=0");
			Sql("Update MembershipTypes Set MembershipPackage='Monthly' Where DiscountRate=10");
			Sql("Update MembershipTypes Set MembershipPackage='Quaterly' Where DiscountRate=15");
			Sql("Update MembershipTypes Set MembershipPackage='Annual' Where DiscountRate=20");
		}
		
		public override void Down()
		{
		}
	}
}
