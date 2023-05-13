namespace TechShopWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Checkout", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.tb_Checkout", new[] { "user_Id" });
            AddColumn("dbo.tb_Checkout", "user", c => c.String());
            DropColumn("dbo.tb_Checkout", "user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Checkout", "user_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.tb_Checkout", "user");
            CreateIndex("dbo.tb_Checkout", "user_Id");
            AddForeignKey("dbo.tb_Checkout", "user_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
