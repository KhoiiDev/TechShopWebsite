using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models.EF;
using TechShopWebsite.Models;
using System.Data.Entity;
using System.Net.NetworkInformation;

namespace TechShopWebsite.Controllers
{
    public class CheckoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checkout
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                string userName = User.Identity.GetUserName().ToString();
                var checkoutList = db.checkouts
                      .Where(c => c.username == userName && c.hide)
                      .OrderByDescending(c => c.datebegin)
                      .ToList();
                return View(checkoutList);
            }
        }

        public ActionResult AddCheckout()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                String userName = User.Identity.GetUserName().ToString();

                var cart = from c in db.carts
                           where c.username == userName && !c.hide && !c.isPay
                           select c;
                ViewBag.ListData = cart.ToList();
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCheckout(Checkout model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    String userName = User.Identity.GetUserName().ToString();

                    var cart = from c in db.carts
                               where c.username == userName && !c.hide && !c.isPay
                               select c;

                    model.datebegin = DateTime.Now;
                    model.meta = new NonUnicode(model.Address + " " + model.datebegin).NonUnicodeText.Replace(' ', '-').ToLower();
                    model.hide = true;
                    model.isPay = true;
                    if(cart != null)
                    {
                        model.carts = cart.ToList();
                    }
                    else
                    {
                        Redirect("gio-hang");
                    }
                    model.username = User.Identity.Name;

                    foreach (var item in model.carts)
                    {
                        if (cart != null)
                        {
                            item.isPay = true;
                            item.hide = true;
                        }

                    }

                    db.checkouts.Add(model);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }
        public ActionResult showCarts(List<Cart> carts)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                return PartialView("showCarts", carts);
            }
        }
    }
}