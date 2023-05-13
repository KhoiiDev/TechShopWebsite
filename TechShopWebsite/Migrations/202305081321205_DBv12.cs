namespace TechShopWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Contact", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.tb_Contact", new[] { "user_Id" });
            AddColumn("dbo.tb_Checkout", "username", c => c.String());
            AddColumn("dbo.tb_Contact", "username", c => c.String());
            DropColumn("dbo.tb_Checkout", "user");
            DropColumn("dbo.tb_Contact", "user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Contact", "user_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.tb_Checkout", "user", c => c.String());
            DropColumn("dbo.tb_Contact", "username");
            DropColumn("dbo.tb_Checkout", "username");
            CreateIndex("dbo.tb_Contact", "user_Id");
            AddForeignKey("dbo.tb_Contact", "user_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
