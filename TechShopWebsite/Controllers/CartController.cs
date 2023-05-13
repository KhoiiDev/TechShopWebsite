using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models.EF;
using TechShopWebsite.Models;

namespace TechShopWebsite.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
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
                           orderby c.datebegin
                           select c;
                return View(cart);
            }
        }

        [HttpPost]
        public ActionResult addCart(int productID, String userN, int quantity)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                if (productID != 0)
                {
                    var product = db.products.Find(productID);

                    var cart = (from c in db.carts
                                where c.username == userN && c.product.Id == productID && !c.isPay
                                select c).FirstOrDefault();

                    if (cart == null)
                    {
                        var model = new Cart
                        {
                            datebegin = DateTime.Now,
                            quantity = quantity,
                            isPay = false,
                            hide = false,
                            username = userN,
                            cost = product.price - (product.price * product.sale),
                            product = product,
                        };

                        db.carts.Add(model);
                        db.SaveChanges();
                        return Json(new { success = true, message = "Product added to cart!" });
                    }
                    else
                    {
                        cart.quantity = cart.quantity + quantity;
                        db.SaveChanges();
                    }
                }
                return Json(new { success = false, message = "Error adding product to cart!" });
            }
        }

        [HttpPost]
        public ActionResult DeleteCart(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var item = db.carts.Find(id);
                if (item != null)
                {
                    db.carts.Remove(item);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
        }

        //[HttpPost]
        //public ActionResult updateQuantity(int CartID, int quantity)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Login", "Account", new { area = "" });
        //    }
        //    else
        //    {
        //        var item = db.carts.Find(CartID);
        //        if (item != null)
        //        {
        //            item.datebegin = DateTime.Now;

        //            item.quantity = quantity;

        //            db.SaveChanges();


        //            return Json(new { success = true });
        //        }
        //        return Json(new { success = false });
        //    }
        //}
    }
}