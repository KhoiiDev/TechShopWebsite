namespace TechShopWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "type_Id", "dbo.tb_Category");
            DropIndex("dbo.tb_Product", new[] { "type_Id" });
            AddColumn("dbo.tb_Product", "type", c => c.String());
            DropColumn("dbo.tb_Product", "type_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "type_Id", c => c.Int());
            DropColumn("dbo.tb_Product", "type");
            CreateIndex("dbo.tb_Product", "type_Id");
            AddForeignKey("dbo.tb_Product", "type_Id", "dbo.tb_Category", "Id");
        }
    }
}
