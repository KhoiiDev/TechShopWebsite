using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models;

namespace TechShopWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getCarousel()
        {
            var items = from p in db.products
                        where p.order == "carousel" && p.hide
                        orderby p.datebegin
                        select p;

            var item = items.ToList();
            if (item == null)
            {
                PartialView("CarouselView");
            }
            return PartialView("CarouselView", item);
        }

        public ActionResult getSpecialOfferView()
        {
            var items = from p in db.products
                        where p.order == "specialOfferTOP" && p.hide
                        orderby p.datebegin
                        select p;

            var item = items.ToList();
            if (item == null)
            {
                PartialView("SpecialOfferView");
            }
            return PartialView("SpecialOfferView", item);
        }

        public ActionResult getFeaturedProduct()
        {
            var items = from p in db.products
                        where p.order == "featureproduct" && p.hide
                        orderby p.datebegin
                        select p;

            var item = items.ToList();
            if (item == null)
            {
                PartialView("FeaturedProductView");
            }

            return PartialView("FeaturedProductView", item);
        }

        public ActionResult getCategory()
        {
            var items = from c in db.categories
                        where c.hide
                        orderby c.datebegin descending
                        select c;

            var item = items.ToList();
            if (item == null)
            {
                PartialView("CategoryView");
            }
            return PartialView("CategoryView", item);
        }

        public ActionResult getOffer()
        {
            var items = from p in db.products
                        where p.order == "offerView" && p.hide
                        orderby p.datebegin
                        select p;

            var item = items.ToList();
            if (item == null)
            {
                PartialView("OfferView");
            }
            return PartialView("OfferView", item);
        }

        public ActionResult getRecentProduct()
        {
            var items = from p in db.products
                        where p.order == "recentproduct" && p.hide
                        orderby p.datebegin
                        select p;

            var item = items.ToList();
            if (item == null)
            {
                PartialView("RecentProductView");
            }
            return PartialView("RecentProductView", item);
        }

        public ActionResult getNews()
        {
            var items = from n in db.news
                        where n.hide
                        orderby n.datebegin descending
                        select n;

            var item = items.Take(4).ToList();

            if (item == null)
            {
                PartialView("NewsView");
            }
            return PartialView("NewsView", item);
        }
    }
}