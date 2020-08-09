using prjAspNetMvcDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjAspNetMvcDemo.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult List()
        {
            var products = from p in (new dbLinqDemoEntities()).tdProduct
                           select p;
            return View(products);
        }

        public ActionResult CartView()
        {
            List<tShoppingCart> list = Session[CDictionary.SK_PRODUCTS_IN_SHOPPINGCART] as List<tShoppingCart>;
            return View(list);
        }
        public ActionResult AddToSession(int id)
        {
            return View(id);
        }
        [HttpPost]
        public ActionResult AddToSession()
        {
            string id = Request.Form["txtFid"];
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("List");

            int fId = Convert.ToInt32(id);
            dbLinqDemoEntities db = new dbLinqDemoEntities();
            tdProduct product = db.tdProduct.FirstOrDefault(p => p.fId == fId);
            if (product == null)
                return RedirectToAction("List");

            List<tShoppingCart> list = Session[CDictionary.SK_PRODUCTS_IN_SHOPPINGCART] as List<tShoppingCart>;
            if (list == null)
            {
                list = new List<tShoppingCart>();
                Session[CDictionary.SK_PRODUCTS_IN_SHOPPINGCART] = list;
            }

            tShoppingCart item = new tShoppingCart();
            item.fDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            item.fCustomerId = 1;
            item.fProductId = product.fId;
            item.fPrice = product.fPrice;
            item.fCount = Convert.ToInt32(Request.Form["txtCount"]);

            list.Add(item);
           
            return RedirectToAction("List");
        }
        public ActionResult AddToCart(int id)
        {
            return View(id);
        }
        [HttpPost]
        public ActionResult AddToCart()
        {
            string id = Request.Form["txtFid"];
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("List");

            int fId = Convert.ToInt32(id);
            dbLinqDemoEntities db = new dbLinqDemoEntities();
            tdProduct product = db.tdProduct.FirstOrDefault(p => p.fId == fId);
            if(product == null)
                return RedirectToAction("List");

            tShoppingCart item = new tShoppingCart();
            item.fDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            item.fCustomerId = 1;
            item.fProductId = product.fId;
            item.fPrice = product.fPrice;
            item.fCount = Convert.ToInt32(Request.Form["txtCount"]);

            db.tShoppingCart.Add(item);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult fileUploadDemo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult fileUploadDemo(HttpPostedFileBase txtPhoto)
        {
            if(txtPhoto != null)
            {
                //bug:會檔名重複，覆蓋原本的檔案
                string name = Path.GetFileName(txtPhoto.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/"), name);
                txtPhoto.SaveAs(path);
            }
            return View();
        }
    }
}