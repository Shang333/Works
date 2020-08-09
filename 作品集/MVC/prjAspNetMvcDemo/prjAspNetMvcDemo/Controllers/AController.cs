using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjAspNetMvcDemo.Controllers
{
    public class AController : Controller
    {
        // GET: A
        public ActionResult bindingCustomerById(int? fId)
        {
            tdCustomer x = (new dbLinqDemoEntities()).tdCustomer.FirstOrDefault(m => m.fId == fId);
            return View(x);
        }
        public ActionResult ShowCustomerById(int? fId)
        {
            tdCustomer x = (new dbLinqDemoEntities()).tdCustomer.FirstOrDefault(m => m.fId == fId);
            return View(x);
            //另一種寫法
            //ViewBag.kk = "查無客戶資料";
            //ViewBag.ss = "查無客戶資料";
            //ViewBag.ii = 1;
            //ViewBag.Img = "0.jpg";
            //另一種寫法
            //ViewBag.customer = x;
            //ViewBag.Img = "0.jpg";

        }
        public ActionResult sumDemo()
        {
            string s1 = Request.Form["txtA"];
            string s2 = Request.Form["txtB"];
            ViewBag.result = "?";
            if (!string.IsNullOrEmpty(s1))
            {
                int a = Convert.ToInt32(s1);
                int b = Convert.ToInt32(s2);
                ViewBag.result = (a + b).ToString();
            }
            return View();
        }
        public ActionResult mathDemo()
        {
            string s1 = Request.Form["txtA"];
            string s2 = Request.Form["txtB"];
            string s3 = Request.Form["txtC"];
            double x1 = 0;
            double x2 = 0;
            double r = 0;
            ViewBag.result = "?";
            //if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || string.IsNullOrEmpty(s3))
            //    return "請重新輸入";
            if (!string.IsNullOrEmpty(s1)&& !string.IsNullOrEmpty(s2)&& !string.IsNullOrEmpty(s3))
            {
                double a = Convert.ToDouble(s1);
                double b = Convert.ToDouble(s2);
                double c = Convert.ToDouble(s3);
                r = Math.Pow(b, 2) - 4 * a * c;
                if (r >= 0)
                {
                    x1 = ((-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a));
                    x2 = ((-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a));
                    if (x1 == x2)
                        ViewBag.result = x1.ToString("0.00");
                    else
                        ViewBag.result = x1.ToString("0.00") + "," + x2.ToString("0.00");
                }
                else
                    ViewBag.result = "無解"; 
            }
            return View();
        }

        public string sayHello()
        {
            return "HI";
        }
        //--老師的做法--
        public string getNumbers()
        {
            return (new CLotto()).getNumbers();
        }
        
        public string getCustomerById(int sefId)
        {
            tdCustomer x = (new dbLinqDemoEntities()).tdCustomer.FirstOrDefault(m => m.fId == sefId);
            if (x == null)
                return "查無客戶資料";
            return x.fName + "<br/>" + x.fPhone;
        }

        public string download(object sender, EventArgs e)
        {
            Response.Clear();

            Response.ContentType = "application/octet-stream";
            Response.Filter.Close();
            Response.WriteFile(@"D:\chrome download\01");
            Response.End();

            return "您的下載已經開始...";
        }

        //加上[NonAction]在方法前面，方法就無法被網址驅動執行
        //[NonAction]
        public string getQueryString(string id)
        {
            string data = Request.QueryString["id"];
            return "您指定的資料是" + data;
        }

        public string Page_Load(object sender, EventArgs e)
        {
            return "目前在伺服器上的實體位置：" + Server.MapPath(".");
        }

        public ActionResult countByCookie()
        {
            int intCount = 0;
            HttpCookie cookie = Request.Cookies["kk"];
            if (cookie != null)
            {
                intCount = Convert.ToInt32(cookie.Value);
                cookie.Expires = DateTime.Now.AddSeconds(-1);
                //讓cookie過期才能remove
                Response.Cookies.Remove("kk");
            };
            intCount++;
            cookie = new HttpCookie("kk");
            //以kk為name建cookies物件放進cookie
            cookie.Value = intCount.ToString();
            cookie.Expires = DateTime.Now.AddSeconds(20);
            Response.Cookies.Add(cookie);
            ViewBag.count = intCount;
            return View();
        }
        public ActionResult countBySession()
        {
            int intCount = 0;
            if (Session["kk"] != null)
            {
                intCount = (int)Session["kk"];
            };
            intCount++;
            Session["kk"] = intCount;
            ViewBag.count = intCount;
            return View();
        }
        public ActionResult count()
        {
            //int s = Convert.ToInt32(Request.Form["spValue"]);
            int intCount = 0;
            if (!string.IsNullOrEmpty((Request.Form["kk"])))
            {
                intCount = Convert.ToInt32((Request.Form["kk"]));
            }
            intCount++;
            ViewBag.count = intCount;
            return View();
        }



    }
}