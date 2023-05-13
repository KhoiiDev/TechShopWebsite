using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models;

namespace TechShopWebsite.Areas.Admin.Controllers
{
   
        // GET: Admin/Roles
        public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Roles
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var items = db.Roles.ToList();
                return View(items);
            }

        }

        public ActionResult AddRole()
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
        public ActionResult AddRole(IdentityRole model)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var roleManage = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

                    if (!roleManage.RoleExists(model.Name))
                    {
                        roleManage.Create(model);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Name", "Role name already exists.");
                    }
                }
                return View(model);
            }
        }

        public ActionResult EditRole(string id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.Roles.FirstOrDefault(r => r.Id == id);
                return View(item);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole(IdentityRole model)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var roleManage = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

                    if (!roleManage.RoleExists(model.Name))
                    {
                        roleManage.Update(model);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("Name", "Role name already exists.");
                    }
                }
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteRole(String id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.Roles.FirstOrDefault(r => r.Id == id);
                if (item != null)
                {
                    db.Roles.Remove(item);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
        }
    }
}