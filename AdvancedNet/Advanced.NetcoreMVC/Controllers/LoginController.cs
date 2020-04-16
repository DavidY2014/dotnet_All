using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advanced.NetcoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Advanced.NetcoreMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Login(string name, string password)
        {
            CurrentUser user = new CurrentUser
            {
                Name = name,
                Password = password
            };
            //存入session
            base.HttpContext.Session.Remove("CurrentUser");
            base.HttpContext.Session.Set("CurrentUser", System.Text.Encoding.Default.
                GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(user)));

            //用户信息存储到cookie,这个是在response中设置




        }
    }
}