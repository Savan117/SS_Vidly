namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameToMembershipPackage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipPackage", c => c.String());
            DropColumn("dbo.MembershipTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            DropColumn("dbo.MembershipTypes", "MembershipPackage");
        }
    }
}
