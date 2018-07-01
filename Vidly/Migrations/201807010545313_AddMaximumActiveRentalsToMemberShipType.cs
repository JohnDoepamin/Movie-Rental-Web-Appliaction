namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaximumActiveRentalsToMemberShipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "MaximumActiveRentals", c => c.Byte(nullable: false));

            Sql("UPDATE MemberShipTypes SET MaximumActiveRentals = 5 WHERE Id = 1");
            Sql("UPDATE MemberShipTypes SET MaximumActiveRentals = 10 WHERE Id = 2");
            Sql("UPDATE MemberShipTypes SET MaximumActiveRentals = 20 WHERE Id = 3");
            Sql("UPDATE MemberShipTypes SET MaximumActiveRentals = 100 WHERE Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberShipTypes", "MaximumActiveRentals");
        }
    }
}
