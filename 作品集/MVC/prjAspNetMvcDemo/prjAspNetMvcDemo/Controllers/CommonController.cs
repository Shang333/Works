using prjAspNetMvcDemo.Models;
using prjAspNetMvcDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjAspNetMvcDemo.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Home()
        {
            if (Session[CDictionary.SK_LOGEDIN_CUSTOMER] == null)
                return RedirectToAction("Login");
            return View();
        }
        public ActionResult Login()
        {
            string code = Session[CDictionary.SK_AUTHTICATION_CODE] as string;
            if (string.IsNullOrEmpty(code))
            {
                Random r = new Random();
                code = r.Next(0, 10).ToString() + r.Next(0, 10) + r.Next(0, 10) + r.Next(0, 10);
                Session[CDictionary.SK_AUTHTICATION_CODE] = code;
            }
            ViewBag.CODE = code;
            return View();
        }
        //[HttpPost]
        //public ActionResult Login(int? a)
        //{
        //    return RedirectToAction("Home");
        //}
        [HttpPost]
        //public ActionResult Login(CLogin p)
        //{
        //    //因為資料沒有mail，這邊以id為帳號
        //    int fId = Convert.ToInt32(p.txtAccount);
        //    tdCustomer cust = (new dbLinqDemoEntities()).tdCustomer.FirstOrDefault(m => m.fId == fId && m.fPassword == p.txtPassword);
        //    //cust為null表示帳密比對錯誤
        //    if (cust == null)
        //        return View();
        //    return RedirectToAction("Home");

        //    //若只有這邊有驗證，還是可以從其他網址(EX首頁)直接進來
        //}
        public ActionResult Login(CLogin p)
        {
            string code = Session[CDictionary.SK_AUTHTICATION_CODE] as string;
            if (!p.txtCode.Equals(code))
            {
                ViewBag.CODE = code;
                return View();
            } 
            //因為資料沒有mail，這邊以id為帳號
            int fId = Convert.ToInt32(p.txtAccount);
            tdCustomer cust = (new dbLinqDemoEntities()).tdCustomer.FirstOrDefault(m => m.fId == fId && m.fPassword == p.txtPassword);
            //cust為null表示帳密比對錯誤
            if (cust == null)
                return View();

            Session[CDictionary.SK_LOGEDIN_CUSTOMER] = cust;
            return RedirectToAction("Home");

            //若只有這邊有驗證，還是可以從其他網址(EX首頁)直接進來
        }
       
    }
}