using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TechShopWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            ////////////////// Route Home //////////////////

            routes.MapRoute(
                name: "Home",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
               name: "Category",
               url: "danh-muc-san-pham/{page}",
               defaults: new { controller = "Category", action = "Index", page = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "CategoryType",
               url: "san-pham/{type}-{page}",
               defaults: new { controller = "Category", action = "getProductCategory", type = UrlParameter.Optional, page = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "Cart",
              url: "gio-hang",
              defaults: new { controller = "Cart", action = "Index" }
           );

            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Index" }
            );

            routes.MapRoute(
              name: "Login",
              url: "dang-nhap",
              defaults: new { controller = "Account", action = "Login" }
           );

            routes.MapRoute(
             name: "Register",
             url: "dang-ky",
             defaults: new { controller = "Account", action = "Register" }
          );


            routes.MapRoute(
               name: "DetailProduct",
               url: "chi-tiet-san-pham/{meta}",
               defaults: new { controller = "Detail", action = "Index", meta = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "News",
                 url: "news/{meta}",
                 defaults: new { controller = "News", action = "Index", meta = UrlParameter.Optional },
                 namespaces: new[] { "TechShopWebsite.Controllers" }
             );

            routes.MapRoute(
                name: "Checkout",
                url: "don-mua",
                defaults: new { controller = "Checkout", action = "Index" }
             );

            routes.MapRoute(
                name: "AddCheckout",
                url: "thanh-toan",
                defaults: new { controller = "Checkout", action = "AddCheckout" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TechShopWebsite.Controllers" }
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
