using System.Web.Mvc;

namespace TechShopWebsite.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext routes)
        {
            ////////////// Route Category  //////////////
            routes.MapRoute(
                name: "AdminCategorys",
                url: "quan-ly-danh-muc",
                defaults: new { controller = "CategoryProduct", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
                name: "AdminAddCategorys",
                url: "them-danh-muc",
                defaults: new { controller = "CategoryProduct", action = "addCategory", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
                name: "AdminEditCategorys",
                url: "chinh-sua-danh-muc/{id}",
                defaults: new { controller = "CategoryProduct", action = "EditCategory", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );

            ////////////// Route Checkout  //////////////
            routes.MapRoute(
                name: "AdminCheckouts",
                url: "quan-ly-ban-hang",
                defaults: new { controller = "Checkouts", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );
            routes.MapRoute(
                name: "AdminDetailCheckouts",
                url: "chi-tiet-don-hang/{id}",
                defaults: new { controller = "Checkouts", action = "DetailCheckout", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );

            ////////////// Route News  //////////////
            routes.MapRoute(
                name: "AdminNews",
                url: "quan-ly-tin-tuc",
                defaults: new { controller = "NewsAdmin", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
                name: "AdminAddNews",
                url: "them-tin-tuc",
                defaults: new { controller = "NewsAdmin", action = "AddNews", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );
            routes.MapRoute(
                name: "AdminEditNews",
                url: "chinh-sua-tin-tuc/{id}",
                defaults: new { controller = "NewsAdmin", action = "EditNews", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );


            routes.MapRoute(
               name: "AdminDetailNews",
               url: "chi-tiet-tin-tuc/{id}",
               defaults: new { controller = "NewsAdmin", action = "DetailNews", id = UrlParameter.Optional },
               namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
           );

            ////////////// Route Account  //////////////
            routes.MapRoute(
                name: "AdminAccounts",
                url: "quan-ly-thong-tin-tai-khoan",
                defaults: new { controller = "AccountAdmin", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
                name: "AdminAccountsLogOff",
                url: "dang-xuat-tai-khoan",
                defaults: new { controller = "AccountAdmin", action = "LogOff", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );



            ////////////// Route Role  //////////////

            routes.MapRoute(
                name: "AdminRole",
                url: "quan-ly-quyen",
                defaults: new { controller = "Roles", action = "Index" },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
                name: "AdminAddRole",
                url: "them-quyen",
                defaults: new { controller = "Roles", action = "AddRole" },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
                name: "AdminEditRole",
                url: "sua-quyen/{id}",
                defaults: new { controller = "Roles", action = "EditRole", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );


            ////////////// Route Products  //////////////
            routes.MapRoute(
                name: "AdminProducts",
                url: "quan-ly-san-pham",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
               name: "AdminAddProducts",
               url: "them-san-pham",
               defaults: new { controller = "Product", action = "AddProduct", id = UrlParameter.Optional },
               namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
           );

            routes.MapRoute(
               name: "AdminEditProducts",
               url: "chinh-sua-san-pham/{id}",
               defaults: new { controller = "Product", action = "EditProduct", id = UrlParameter.Optional },
               namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
           );
            routes.MapRoute(
               name: "AdminDetailProducts",
               url: "chi-tiet-quan-ly-san-pham/{id}",
               defaults: new { controller = "Product", action = "DetailProduct", id = UrlParameter.Optional },
               namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
           );

            ////////////// Route COntact  //////////////
            ///
            routes.MapRoute(
               name: "AdminContact",
               url: "quan-li-lien-he",
               defaults: new { controller = "ContactAdmin", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
           );

            ////////////// Route Default  //////////////



            routes.MapRoute(
                name: "AdminDefault",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Areas.Admin.Controllers" }
            );
        }
    }
}