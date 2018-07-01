namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToMemberShipTypesClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipType");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            AddColumn("dbo.Customers", "MemberShipTypes_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MemberShipTypes_Id");
            AddForeignKey("dbo.Customers", "MemberShipTypes_Id", "dbo.MemberShipType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypes_Id", "dbo.MemberShipType");
            DropIndex("dbo.Customers", new[] { "MemberShipTypes_Id" });
            DropColumn("dbo.Customers", "MemberShipTypes_Id");
            CreateIndex("dbo.Customers", "MemberShipTypeId");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipType", "Id", cascadeDelete: true);
        }
    }
}
