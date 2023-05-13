namespace TechShopWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Cart", "product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_Cart", new[] { "product_Id" });
            AlterColumn("dbo.tb_Cart", "product_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Cart", "product_Id");
            AddForeignKey("dbo.tb_Cart", "product_Id", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Cart", "product_Id", "dbo.tb_Product");
            DropIndex("dbo.tb_Cart", new[] { "product_Id" });
            AlterColumn("dbo.tb_Cart", "product_Id", c => c.Int());
            CreateIndex("dbo.tb_Cart", "product_Id");
            AddForeignKey("dbo.tb_Cart", "product_Id", "dbo.tb_Product", "Id");
        }
    }
}
