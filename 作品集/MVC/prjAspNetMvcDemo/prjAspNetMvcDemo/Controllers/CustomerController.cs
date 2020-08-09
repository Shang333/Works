using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjAspNetMvcDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult List()
        {
            var customers = from t in (new dbLinqDemoEntities()).tdCustomer
                            select t;
            return View(customers);
        }
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Save()
        {
            //存入資料的傳統寫法(費時)
            tdCustomer x = new tdCustomer();
            x.fName = Request.Form["txtName"];
            x.fPhone = Request.Form["txtPhone"];
            x.fBirthday = Request.Form["txtBirthday"];
            x.fAddress = Request.Form["txtAddress"];
            x.fPassword = Request.Form["txtPassword"];

            dbLinqDemoEntities db = new dbLinqDemoEntities();
            db.tdCustomer.Add(x);
            db.SaveChanges();
            return View();
            //return View();//會創新的view
            //return RedirectToAction("List");
            //傳回List
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            dbLinqDemoEntities db = new dbLinqDemoEntities();
            tdCustomer x = db.tdCustomer.FirstOrDefault(m => m.fId == id);
            if (x != null)
            {
                db.tdCustomer.Remove(x);
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
            tdCustomer x = db.tdCustomer.FirstOrDefault(m => m.fId == id);
            return View(x);
        }

        //Edit寫法2:較快速的存入資料方法(save進化版)
        //使用多載要搭配動作選取器，告訴瀏覽器什麼時候用什麼方法
        [HttpPost]
        public ActionResult Edit(tdCustomer p)
        {
            dbLinqDemoEntities db = new dbLinqDemoEntities();
            tdCustomer cust = db.tdCustomer.FirstOrDefault(m => m.fId == p.fId);
            if(cust != null)
            {
                cust.fName = p.fName;
                cust.fPhone = p.fPhone;
                cust.fBirthday = p.fBirthday;
                cust.fPassword = p.fPassword;
                cust.fAddress = p.fAddress;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}