namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
        }
    }
}
