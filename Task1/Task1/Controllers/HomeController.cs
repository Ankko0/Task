using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public int function(int param)
        {
            String value = param.ToString();
            bool isSecond = false;
            int result = 0;

            foreach (var symbol in value)
            {
                int number;
                if (Int32.TryParse(symbol.ToString(), out number))
                    if (number % 2 != 0)
                        if (isSecond)
                        {
                            result += number;
                            isSecond = false;
                        }
                        else
                            isSecond = true;

            }

            return result;
        }
    }

    
}
