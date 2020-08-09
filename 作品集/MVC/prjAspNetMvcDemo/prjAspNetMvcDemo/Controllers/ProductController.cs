using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjAspNetMvcDemo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            //有考量"搜尋功能"的版本，若搜尋的keyword為null(表示不搜尋)，把產品全顯示；若搜尋的keyword非null，則加上where條件選擇products
            //var products = null;//var不可為null
            IQueryable<tdProduct> products = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
            {
                products = from p in (new dbLinqDemoEntities()).tdProduct
                           select p;               
            }
            else
            {
                products = from p in (new dbLinqDemoEntities()).tdProduct
                           where p.fName.Contains(keyword)
                           select p;
            }

            return View(products);

        }

        // GET: Product基本版
        //public ActionResult List()
        //{
        //    var products = from p in (new dbLinqDemoEntities()).tdProduct
        //                   select p;
        //    return View(products);
        //}



        //[HttpPost]
        //public ActionResult Create(tdProduct p)
        //{
        //    dbLinqDemoEntities db = new dbLinqDemoEntities();
        //    db.tdProduct.Add(p);
        //    db.SaveChanges();
        //    return RedirectToAction("List");
        //}
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            dbLinqDemoEntities db = new dbLinqDemoEntities();
            tdProduct x = db.tdProduct.FirstOrDefault(m => m.fId == id);
            if (x != null)
            {
                db.tdProduct.Remove(x);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //Edit寫法1
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            dbLinqDemoEntities db = new dbLinqDemoEntities();
            tdProduct x = db.tdProduct.FirstOrDefault(m => m.fId == id);
            return View(x);
        }

        //Edit寫法2:較快速的存入資料方法
        //使用多載要搭配動作選取器，告訴瀏覽器什麼時候用什麼方法
        [HttpPost]
        public ActionResult Edit(tdProduct p)
        {
            if (string.IsNullOrEmpty(p.fName))
                return RedirectToAction("List");
            dbLinqDemoEntities db = new dbLinqDemoEntities();
            tdProduct cust = db.tdProduct.FirstOrDefault(m => m.fId == p.fId);
            if (cust != null)
            {
                cust.fName = p.fName;
                cust.fPrice = p.fPrice;
                cust.fCost = p.fCost;
                cust.fQty = p.fQty;
                cust.flmagPath = p.flmagPath;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //把照片變成一種class名稱(新增fImage屬性)
        public ActionResult Create(tdProduct p)
        {
            if (p.flmagPath != null)
            {
                string photoName = Guid.NewGuid().ToString() + Path.GetExtension(p.fImage.FileName);
                var path = Path.Combine(Server.MapPath("../Content/"), photoName);
                p.fImage.SaveAs(path);
                p.flmagPath = "../Content/" + photoName;
            }
            dbLinqDemoEntities db = new dbLinqDemoEntities();
            db.tdProduct.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult fileUploadDemo(HttpPostedFileBase txtPhoto)
        {
            if (txtPhoto != null)
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