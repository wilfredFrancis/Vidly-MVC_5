namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedByteToIntInCustModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Customers", "Id");
        }
    }
}
