using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Web.Test.Filters
{
    /// <summary>
    /// 这是一个action的filter，用作权限认证
    /// </summary>
    public class CustomAuthorizeAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //通过判断session来决定有没有登陆
            var strUser = context.HttpContext.Session.GetString("CurrentUser");
            if (!string.IsNullOrWhiteSpace(strUser))
            {
                //说明session取到
                CurrentUser currentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentUser>(strUser); 
                
            }

            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
