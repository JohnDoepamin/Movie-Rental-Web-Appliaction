namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresAndMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Documentary')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5,'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6,'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7,'Science Fiction')");
        }
        
        public override void Down()
        {
        }
    }
}
