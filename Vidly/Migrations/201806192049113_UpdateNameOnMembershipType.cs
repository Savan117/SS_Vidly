namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class UpdateNameOnMembershipType : DbMigration
	{
		public override void Up()
		{
			Sql("Update MembershipTypes Set Name='Pay as You Go' Where DiscountRate=0");
			Sql("Update MembershipTypes Set Name='Monthly' Where DiscountRate=10");
			Sql("Update MembershipTypes Set Name='Quaterly' Where DiscountRate=15");
			Sql("Update MembershipTypes Set Name='Annual' Where DiscountRate=20");
		}
		
		public override void Down()
		{
		}
	}
}
