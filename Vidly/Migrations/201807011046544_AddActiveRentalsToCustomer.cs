namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveRentalsToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ActiveRentals", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ActiveRentals");
        }
    }
}
