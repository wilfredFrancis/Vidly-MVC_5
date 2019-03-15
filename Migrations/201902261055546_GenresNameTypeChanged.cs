namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenresNameTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.Int(nullable: false));
        }
    }
}
