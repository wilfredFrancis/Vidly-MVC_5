namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rent1 : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            AddColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Rentals", "Movie_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
