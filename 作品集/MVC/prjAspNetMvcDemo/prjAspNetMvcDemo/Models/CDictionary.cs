using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjAspNetMvcDemo.Models
{
    public class CDictionary
    {
        //static  使用時不用new classI
        //readonly 唯讀
        public static readonly string SK_PRODUCTS_IN_SHOPPINGCART = "SK_PRODUCTS_IN_SHOPPINGCART";
        public static readonly string SK_LOGEDIN_CUSTOMER= "SK_LOGEDIN_CUSTOMER";
        public static readonly string SK_AUTHTICATION_CODE = "SK_AUTHTICATION_CODE";
    }
}