using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models;

namespace TechShopWebsite.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();


        public AccountAdminController()
        {
        }

        public AccountAdminController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var users = db.Users.ToList();
                return View(users);
            }
        }

        public ActionResult showRoleName(string roleID)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var role = db.Roles.Where(r => r.Id == roleID).FirstOrDefault();
                return PartialView("showRoleName", role);
            }
        }

        public ActionResult showRoles(string userID)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var role = db.Roles.ToList();
                ViewBag.userID = userID;
                return PartialView("showRoles", role);
            }
        }

        [HttpPost]
        public ActionResult SetUserRole(string userId, string role)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    // Xóa role cũ của user
                    var userRoles = userManager.GetRoles(user.Id);
                    userManager.RemoveFromRoles(user.Id, userRoles.ToArray());
                    // Thêm role mới cho user
                    userManager.AddToRole(user.Id, role);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult DeleteAccount(String id)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.Users.FirstOrDefault(r => r.Id == id);
                if (item != null)
                {
                    db.Users.Remove(item);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect("trang-chu");
        }
    }
}