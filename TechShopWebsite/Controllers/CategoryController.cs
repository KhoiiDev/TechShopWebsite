using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models.EF;
using TechShopWebsite.Models;

namespace TechShopWebsite.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Category
        public ActionResult Index(int? page)
        {
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var items = from p in db.products
                        where p.hide
                        orderby p.stars descending
                        select p;

            if (items.Any())
            {
                return View(items.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(new List<Product>().ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult getProductCategory(string type, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            var items = from p in db.products
                        where p.hide && p.type == type && p.datebegin != null
                        orderby p.datebegin descending
                        select p;

            if (items.Any())
            {
                return View(items.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(new List<Product>().ToPagedList(pageNumber, pageSize));
            }
        }
    }
}