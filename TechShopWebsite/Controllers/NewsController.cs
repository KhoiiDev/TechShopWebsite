using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models;

namespace TechShopWebsite.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: News
        public ActionResult Index(String meta)
        {
            var item = db.news
                 .Where(p => p.meta == meta && p.hide)
                 .OrderByDescending(p => p.datebegin)
                 .FirstOrDefault();
            return View(item);
        }
    }
}