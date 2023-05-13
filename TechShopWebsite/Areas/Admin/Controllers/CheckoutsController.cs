using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models;

namespace TechShopWebsite.Areas.Admin.Controllers
{
    public class CheckoutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Checkouts
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.checkouts.OrderByDescending(c => c.datebegin).ToList();
                return View(item);
            }
        }

        public ActionResult DetailCheckout(string id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                byte[] idBytes = Convert.FromBase64String(id);
                string idEncoding = Encoding.UTF8.GetString(idBytes);
                int idEnco = int.Parse(idEncoding);

                var item = db.checkouts.Find(idEnco);
                return View(item);
            }
        }
    }
}