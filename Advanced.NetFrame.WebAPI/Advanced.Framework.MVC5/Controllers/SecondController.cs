using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advanced.Framework.MVC5.Controllers
{
    public class SecondController : Controller
    {
        // GET: Second
        public ActionResult Index()
        {
            return View();
        }

        public string String()
        {
            return DateTime.Now.ToString("yy-MM-dd HH:mm:ss ffff");
        }

        public ViewResult RazorExtend()
        {
            return View();
        }
    }
}