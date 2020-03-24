using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace Advanced.NetFrame.WebAPI.Utility.Filters
{
    public class CustomBasicAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //自定义个匿名的特性跳过认证
            if (actionContext.ActionDescriptor.GetCustomAttributes<CustomAllowAnonymousAttribute>()
                .FirstOrDefault() != null)
            {
                return;
            }
            else if (actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<CustomAllowAnonymousAttribute>()
                .FirstOrDefault() != null)
            {
                return;
            } 
            else
            {
                var authorization = actionContext.Request.Headers.Authorization;
                if (authorization == null)
                {

                }
                else if (this.ValidateTicket(authorization.Parameter))
                {
                    return;
                }
                else
                {
                    throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
                }
            }
           
        }

        public bool ValidateTicket(string encryptTicket)
        {
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;
            return string.Equals(strTicket, string.Format("{0}&{1}", "Admin", "123456"));
        }
    }
}