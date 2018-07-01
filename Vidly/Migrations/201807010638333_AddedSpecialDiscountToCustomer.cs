namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpecialDiscountToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SpecialDiscount", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SpecialDiscount");
        }
    }
}
