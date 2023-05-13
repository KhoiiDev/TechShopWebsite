using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models;

namespace TechShopWebsite.Areas.Admin.Controllers
{
    public class ContactAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ContactAdmin
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.contacts.OrderByDescending(c => c.datebegin).ToList();
                return View(item);
            }
        }
    }
}