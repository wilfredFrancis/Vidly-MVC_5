namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayToCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = 01/01/1990 WHERE Id = 1");
            Sql("UPDATE Customers SET Birthday = null WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
