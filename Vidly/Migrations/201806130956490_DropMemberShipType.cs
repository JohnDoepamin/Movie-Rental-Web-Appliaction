namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropMemberShipType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypes_Id", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypes_Id" });
            DropColumn("dbo.Customers", "MemberShipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MemberShipTypes_Id", newName: "MemberShipTypeId");
            AlterColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipTypeId");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            AlterColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MemberShipTypeId", newName: "MemberShipTypes_Id");
            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipTypes_Id");
            AddForeignKey("dbo.Customers", "MemberShipTypes_Id", "dbo.MemberShipTypes", "Id");
        }
    }
}
