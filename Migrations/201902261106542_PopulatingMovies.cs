namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (1, 'Hangover', 01-02-1980, 19-02-1990, 20, 1)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (2, 'Die Hard', 20-01-1988, 10-01-1999, 2, 2)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (3, 'The Terminator', 24-09-1985, 05-06-2000, 5, 2)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (4, 'Toy Story', 30-12-2005, 09-02-2015, 8, 3)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES (5, 'Titanic', 01-02-2000, 19-02-2019, 7, 4)");
            Sql("SET IDENTITY_INSERT Movies OFF");
        }
        
        public override void Down()
        {
        }
    }
}
