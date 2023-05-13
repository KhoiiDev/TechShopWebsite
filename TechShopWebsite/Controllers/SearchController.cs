using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models;

namespace TechShopWebsite.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchProduct(string query)
        {
            query = new NonUnicode(query).NonUnicodeText.Replace(' ', '-').ToLower();
            var productsByMeta = db.products.Where(p => p.meta.Contains(query) && p.hide).ToList();
            if (productsByMeta.Count() < 5)
            {
                var productsByName = db.products.Where(p => p.productName.Contains(query) && p.hide).ToList();
                var productsByNameMeta = productsByMeta.Concat(productsByName).ToList();
                if (productsByNameMeta.Count() < 5)
                {
                    var productsByType = db.products.Where(p => p.type.Contains(query) && p.hide).ToList();
                    var productsByNameMetaType = productsByNameMeta.Concat(productsByType).ToList().Take(5);
                    return PartialView("_SearchResults", productsByNameMetaType);

                }
                return PartialView("_SearchResults", productsByNameMeta);
            }
            return PartialView("_SearchResults", productsByMeta);
        }

    }
}