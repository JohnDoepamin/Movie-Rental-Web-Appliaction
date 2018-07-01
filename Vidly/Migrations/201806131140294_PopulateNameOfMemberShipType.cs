namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameOfMemberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM MemberShipTypes");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (1,0,0,0, 'None')");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (2,30,1,10, 'Bronze')");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (3,90,3,15, 'Silber')");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (4,300,12,20, 'Gold')");
        }
        
        public override void Down()
        {

        }
    }
}
