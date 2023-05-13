using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechShopWebsite.Models.EF;
using TechShopWebsite.Models;
using System.Data.Entity;

namespace TechShopWebsite.Controllers
{
    public class DetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Detail
        public ActionResult Index(String meta)
        {
            var item = db.products.FirstOrDefault(p => p.meta == meta && p.hide);
            return View(item);
        }

        /// <summary>
        /// chức năng hiển thi view để thêm một phản hồi
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ActionResult AddReview(int productId)
        {
            ViewBag.productId = productId;
            return PartialView("addReview");

        }
        /// <summary>
        /// Phía setver sẽ xử lý dữ liệu phản hồi của người bình luận
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addReview(Reviews model, int productId)
        {
            var product = db.products.SingleOrDefault(p => p.Id == productId);
            if (ModelState.IsValid && product != null)
            {
                var newReview = new Reviews
                {
                    Reviewer = model.Reviewer,
                    ReviewContent = model.ReviewContent,
                    Email = model.Email,
                    Rating = model.Rating,
                    datebegin = DateTime.Now,
                    meta = new NonUnicode(model.Reviewer+ "-"+model.Email).NonUnicodeText.Replace(' ', '-').ToLower(),
                    hide = true
                };
                product.reviews.Add(newReview);
                db.SaveChanges();
                string url = Url.Action("Index", "Detail", new { meta = product.meta }, protocol: Request.Url.Scheme);
                return Redirect(url);
            }
            else
            {
                // Xử lý lỗi khi ModelState.IsValid là false
                ViewBag.ErrorMsg = "Có lỗi xảy ra khi thêm đánh giá, vui lòng thử lại sau.";
                return View("addReview");
            }
        }

        public ActionResult showReview(int productId)
        {
            // Get the first 5 reviews for the specified product sorted by their "datebegin" property in descending order
            var product = db.products.SingleOrDefault(p => p.Id == productId);
            var reviews = product.reviews.Take(5).ToList();


            // Pass the first 5 reviews to the partial view as the model
            return PartialView("showReview", reviews);
        }
    }
}