using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models.EF;
using TechShopWebsite.Models;
using System.Text;

namespace TechShopWebsite.Areas.Admin.Controllers
{
    public class NewsAdminController : Controller
    {

        // GET: Admin/News
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.news.OrderByDescending(c => c.datebegin); ;
                return View(item);
            }
        }

        public ActionResult DetailNews(string id)
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

                var item = db.news.Find(idEnco);
                return View(item);
            }
        }

        public ActionResult AddNews()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNews(News model)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var existingNews = db.news.FirstOrDefault(p => p.title == model.title);
                    if (existingNews != null)
                    {
                        ModelState.AddModelError("title", "Title already exists.");
                        return View(model);
                    }

                    model.datebegin = DateTime.Now;
                    model.meta = new NonUnicode(model.title).NonUnicodeText.Replace(' ', '-').ToLower();


                    db.news.Add(model);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }

        public ActionResult EditNews(int id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.news.Find(id);
                return View(item);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNews(News model)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var existingNews = db.news.FirstOrDefault(p => p.title == model.title);
                    if (existingNews != null)
                    {
                        ModelState.AddModelError("title", "Title already exists.");
                        return View(model);
                    }

                    db.news.Attach(model);
                    model.datebegin = DateTime.Now;

                    model.meta = new NonUnicode(model.title).NonUnicodeText;

                    db.Entry(model).Property(x => x.title).IsModified = true;
                    db.Entry(model).Property(x => x.content).IsModified = true;
                    db.Entry(model).Property(x => x.avatar).IsModified = true;
                    db.Entry(model).Property(x => x.meta).IsModified = true;
                    db.Entry(model).Property(x => x.hide).IsModified = true;
                    db.Entry(model).Property(x => x.datebegin).IsModified = true;
                    db.Entry(model).Property(x => x.order).IsModified = true;

                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteNews(int id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.news.Find(id);
                if (item != null)
                {
                    db.news.Remove(item);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult IsHide(int id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.news.Find(id);
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
}