using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advanced.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advanced.WebAPI.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// session template
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        [HttpPost]
        public void Login(string name,string password)
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