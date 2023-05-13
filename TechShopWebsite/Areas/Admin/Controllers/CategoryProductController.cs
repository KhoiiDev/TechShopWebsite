using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models.EF;
using TechShopWebsite.Models;

namespace TechShopWebsite.Areas.Admin.Controllers
{
    public class CategoryProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.categories.OrderByDescending(c => c.datebegin);
                return View(item);

            }
        }
        public ActionResult AddCategory()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Account");
                }
                return View();

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category model)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            if (ModelState.IsValid)
            {

                var existingCategory = db.categories.FirstOrDefault(p => p.CategoryName == model.CategoryName);
                if (existingCategory != null)
                {
                    ModelState.AddModelError("CategoryName", "CategoryName already exists.");
                    return View(model);
                }
                model.datebegin = DateTime.Now;
                model.meta = new NonUnicode(model.CategoryName).NonUnicodeText.Replace(@"[^0-9a-zA-Z\._]", "").ToLower();
                db.categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult EditCategory(int id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.categories.Find(id);
                return View(item);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(Category model)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            if (ModelState.IsValid)
            {
                db.categories.Attach(model);
                model.datebegin = DateTime.Now;
                model.meta = new NonUnicode(model.CategoryName).NonUnicodeText.Replace(' ', '-');

                db.Entry(model).Property(x => x.CategoryName).IsModified = true;
                db.Entry(model).Property(x => x.CategoryImage).IsModified = true;
                db.Entry(model).Property(x => x.meta).IsModified = true;
                db.Entry(model).Property(x => x.hide).IsModified = true;
                db.Entry(model).Property(x => x.datebegin).IsModified = true;
                db.Entry(model).Property(x => x.order).IsModified = true;

                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            var item = db.categories.Find(id);
            if (item != null)
            {
                db.categories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsHide(int id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            var item = db.categories.Find(id);
            if (item != null)
            {
                item.hide = !item.hide;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isHide = item.hide });
            }
            return Json(new { success = false });
        }
    }
}