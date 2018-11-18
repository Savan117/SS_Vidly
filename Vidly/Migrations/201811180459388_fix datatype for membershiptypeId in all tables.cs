namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdatatypeformembershiptypeIdinalltables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            DropColumn("dbo.Customers", "MembershipTypeID");
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MembershipTypeID");
            AlterColumn("dbo.Customers", "MembershipTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "MembershipTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeID");
            AddForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeID" });
            AlterColumn("dbo.Customers", "MembershipTypeID", c => c.Int());
            AlterColumn("dbo.Customers", "MembershipTypeID", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeID", newName: "MembershipType_Id");
            AddColumn("dbo.Customers", "MembershipTypeID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
