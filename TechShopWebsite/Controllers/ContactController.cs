using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models.EF;
using TechShopWebsite.Models;

namespace TechShopWebsite.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contact
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContact(Contact model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    model.datebegin = DateTime.Now;
                    model.meta = new NonUnicode(model.contactEmail).NonUnicodeText.Replace(' ', '-').ToLower();
                    model.username = User.Identity.Name;

                    db.contacts.Add(model);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }
    }
}