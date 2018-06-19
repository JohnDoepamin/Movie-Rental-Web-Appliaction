namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameOfMemberShipType1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET Name = 'No Subscription' WHERE Id = 1");
            Sql("UPDATE MemberShipTypes SET Name = 'Bismuth' WHERE Id = 2");
            Sql("UPDATE MemberShipTypes SET Name = 'Saphire' WHERE Id = 3");
            Sql("UPDATE MemberShipTypes SET Name = 'Diamond' WHERE Id = 4");
        }

        public override void Down()
        {
        }
    }
}
