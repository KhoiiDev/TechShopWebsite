namespace TechShopWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "Cart_Id", "dbo.tb_Cart");
            DropIndex("dbo.tb_Product", new[] { "Cart_Id" });
            AddColumn("dbo.tb_Cart", "product_Id", c => c.Int());
            CreateIndex("dbo.tb_Cart", "product_Id");
            AddForeignKey("dbo.tb_Cart", "product_Id", "dbo.tb_Product", "Id");
            DropColumn("dbo.tb_Product", "Cart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "Cart_Id", c => c.Int());
            DropForeignKey("dbo.tb_Cart", "product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_Cart", new[] { "product_Id" });
            DropColumn("dbo.tb_Cart", "product_Id");
            CreateIndex("dbo.tb_Product", "Cart_Id");
            AddForeignKey("dbo.tb_Product", "Cart_Id", "dbo.tb_Cart", "Id");
        }
    }
}
