namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {

            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6c0ebe7c-614a-476b-80cd-b8820b53719d', N'admin.wilfred@vidly.com', 0, N'AHWdxPX8xha+ZzbwpTY/UXQC5gvbbQ8MEvCP2ReXwBw3WznnfYxvVvOnDVEA5KvnJg==', N'9699f3a3-dc04-4efe-81ab-e1afe04c674c', NULL, 0, 0, NULL, 1, 0, N'admin.wilfred@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'708c8f68-cc80-46ba-b2a5-6bbb498f26e4', N'guest@vidly.com', 0, N'ACiaUBlo9MLs4JuQ8nMvVjkEJnTX1Pf1w1HpcMdfBZFnC72JfCQtrd9q2GYqkS9F+g==', N'dd7d8c26-f5a1-40ce-8246-597f75a0cb9c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                  
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cd9931ca-9db1-460e-a62f-7a1dd63f1ca3', N'CanManageMovie')
                  
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6c0ebe7c-614a-476b-80cd-b8820b53719d', N'cd9931ca-9db1-460e-a62f-7a1dd63f1ca3')");
        
        }

    public override void Down()
        {
        }
    }
}
