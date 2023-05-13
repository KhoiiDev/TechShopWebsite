using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models.EF;
using TechShopWebsite.Models;

namespace TechShopWebsite.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/product
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                // User chưa đăng nhập hoặc không có role "Admin"
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.products.OrderByDescending(x => x.datebegin).ToList();
                return View(item);
            }
        }

        public ActionResult DetailProduct(string id)
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

                var item = db.products.Find(idEnco);
                return View(item);
            }
        }

        public ActionResult AddProduct()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                ViewBag.ListCategory = new SelectList(db.categories.Select(x => x.CategoryName).ToList());
                return View();
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addproduct(Product model)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var existingProduct = db.products.FirstOrDefault(p => p.productName == model.productName);
                    if (existingProduct != null)
                    {
                        ModelState.AddModelError("productName", "Product name already exists.");
                        return View(model);
                    }

                    model.datebegin = DateTime.Now;
                    model.meta = new NonUnicode(model.productName).NonUnicodeText.Replace(' ', '-').ToLower();
                    model.stars = new Random().Next(1, 6);
                    model.vote = new Random().Next(30, 1000);

                    db.products.Add(model);

                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(model);
            }
        }

        public ActionResult EditProduct(int id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.products.Find(id);
                return View(item);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(Product model)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var existingProduct = db.products.FirstOrDefault(p => p.productName == model.productName);
                    if (existingProduct != null)
                    {
                        ModelState.AddModelError("productName", "Product name already exists.");
                        return View(model);
                    }

                    db.products.Attach(model);

                    db.Entry(model).Property(x => x.productName).IsModified = true;
                    db.Entry(model).Property(x => x.description).IsModified = true;
                    db.Entry(model).Property(x => x.price).IsModified = true;
                    db.Entry(model).Property(x => x.isSale).IsModified = true;
                    db.Entry(model).Property(x => x.sale).IsModified = true;
                    db.Entry(model).Property(x => x.manufacturer).IsModified = true;
                    db.Entry(model).Property(x => x.img).IsModified = true;
                    db.Entry(model).Property(x => x.screen).IsModified = true;
                    db.Entry(model).Property(x => x.CPU).IsModified = true;
                    db.Entry(model).Property(x => x.RAM).IsModified = true;
                    db.Entry(model).Property(x => x.HardDrive).IsModified = true;
                    db.Entry(model).Property(x => x.Camera).IsModified = true;
                    db.Entry(model).Property(x => x.Capacity).IsModified = true;
                    db.Entry(model).Property(x => x.type).IsModified = true;
                    db.Entry(model).Property(x => x.hide).IsModified = true;
                    db.Entry(model).Property(x => x.order).IsModified = true;

                    model.stars = new Random().Next(1, 6);
                    model.vote = new Random().Next(30, 1000);
                    model.datebegin = DateTime.Now;

                    model.meta = new NonUnicode(model.productName).NonUnicodeText;

                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.products.Find(id);
                if (item != null)
                {
                    db.products.Remove(item);
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
                RedirectToAction("Login", "Account", new { area = "" });
            }
            var item = db.products.Find(id);
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