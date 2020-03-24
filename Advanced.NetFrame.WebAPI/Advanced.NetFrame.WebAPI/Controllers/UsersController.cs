using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Advanced.NetFrame.WebAPI.Models;
using Advanced.NetFrame.WebAPI.Utility.Filters;
using Newtonsoft.Json;

namespace Advanced.NetFrame.WebAPI.Controllers
{
    //[CustomBasicAuthorizeAttribute]
    public class UsersController : ApiController
    {
        #region 用户登陆

        //[AllowAnonymous]
        [CustomAllowAnonymousAttribute]
        [HttpGet]
        public string Login(string account, string password)
        {
            //这种写法避免入参为空导致异常
            if ("Admin".Equals(account) && "123456".Equals(password))
            {
                FormsAuthenticationTicket ticketObject = new FormsAuthenticationTicket(
                    0, account, DateTime.Now, DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", account,
                    password),
                    FormsAuthentication.FormsCookiePath);
                var result = new { Result = true, Ticket = FormsAuthentication.Encrypt(ticketObject) };
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                var result = new { Result = false };
                return JsonConvert.SerializeObject(result);
            }
        }

        /// <summary>
        /// 获取前端传来的认证token
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        //[CustomBasicAuthorizeAttribute]
        public IEnumerable<User> GetUserByName(string userName)
        {
            string userNameParam = HttpContext.Current.Request.QueryString["UserName"];
            string tokenTicket = HttpContext.Current.Request.Headers["Authorization"];

            return null;
        }


        #endregion



    }
}
