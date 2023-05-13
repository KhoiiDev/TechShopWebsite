namespace TechShopWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isPay = c.Boolean(nullable: false),
                        username = c.String(nullable: false),
                        meta = c.String(),
                        hide = c.Boolean(nullable: false),
                        datebegin = c.DateTime(nullable: false),
                        order = c.String(),
                        Checkout_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Checkout", t => t.Checkout_Id)
                .Index(t => t.Checkout_Id);
            
            CreateTable(
                "dbo.tb_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        productName = c.String(nullable: false, maxLength: 500),
                        description = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isSale = c.Boolean(nullable: false),
                        sale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        manufacturer = c.String(maxLength: 500),
                        img = c.String(maxLength: 500),
                        screen = c.String(),
                        CPU = c.String(maxLength: 500),
                        OS = c.String(maxLength: 500),
                        RAM = c.String(maxLength: 500),
                        HardDrive = c.String(maxLength: 500),
                        Camera = c.String(maxLength: 500),
                        Capacity = c.String(maxLength: 500),
                        stars = c.Int(nullable: false),
                        vote = c.Int(nullable: false),
                        meta = c.String(),
                        hide = c.Boolean(nullable: false),
                        datebegin = c.DateTime(nullable: false),
                        order = c.String(),
                        type_Id = c.Int(),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Category", t => t.type_Id)
                .ForeignKey("dbo.tb_Cart", t => t.Cart_Id)
                .Index(t => t.type_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.tb_Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reviewer = c.String(nullable: false, maxLength: 100),
                        ReviewContent = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 500),
                        Rating = c.Int(nullable: false),
                        meta = c.String(),
                        hide = c.Boolean(nullable: false),
                        datebegin = c.DateTime(nullable: false),
                        order = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Product", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.tb_Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        CategoryImage = c.String(nullable: false, maxLength: 100),
                        meta = c.String(),
                        hide = c.Boolean(nullable: false),
                        datebegin = c.DateTime(nullable: false),
                        order = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Checkout",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        receiver = c.String(),
                        phone = c.String(),
                        Address = c.String(),
                        province = c.String(),
                        district = c.String(),
                        ZipCode = c.String(),
                        isPay = c.Boolean(nullable: false),
                        meta = c.String(),
                        hide = c.Boolean(nullable: false),
                        datebegin = c.DateTime(nullable: false),
                        order = c.String(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tb_Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        contactName = c.String(nullable: false, maxLength: 100),
                        contactEmail = c.String(maxLength: 100),
                        contactMessage = c.String(maxLength: 500),
                        contactSubject = c.String(maxLength: 500),
                        meta = c.String(),
                        hide = c.Boolean(nullable: false),
                        datebegin = c.DateTime(nullable: false),
                        order = c.String(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.tb_News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 100),
                        description = c.String(nullable: false),
                        content = c.String(nullable: false),
                        avatar = c.String(nullable: false, maxLength: 500),
                        meta = c.String(),
                        hide = c.Boolean(nullable: false),
                        datebegin = c.DateTime(nullable: false),
                        order = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tb_Contact", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.tb_Checkout", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.tb_Cart", "Checkout_Id", "dbo.tb_Checkout");
            DropForeignKey("dbo.tb_Product", "Cart_Id", "dbo.tb_Cart");
            DropForeignKey("dbo.tb_Product", "type_Id", "dbo.tb_Category");
            DropForeignKey("dbo.tb_Reviews", "Product_Id", "dbo.tb_Product");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tb_Contact", new[] { "user_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.tb_Checkout", new[] { "user_Id" });
            DropIndex("dbo.tb_Reviews", new[] { "Product_Id" });
            DropIndex("dbo.tb_Product", new[] { "Cart_Id" });
            DropIndex("dbo.tb_Product", new[] { "type_Id" });
            DropIndex("dbo.tb_Cart", new[] { "Checkout_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tb_News");
            DropTable("dbo.tb_Contact");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.tb_Checkout");
            DropTable("dbo.tb_Category");
            DropTable("dbo.tb_Reviews");
            DropTable("dbo.tb_Product");
            DropTable("dbo.tb_Cart");
        }
    }
}
