using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Advanced.NetFrame.WebAPI.Utility.Filters
{
    /// <summary>
    /// 异常发生没有被catch，进入其中
    /// </summary>
    public class CustomExceptionFilterAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext )
        {
            Console.WriteLine(actionExecutedContext.Exception.Message);
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                System.Net.HttpStatusCode.OK, new
                {
                    Result = false,
                    Msg = "异常发生"
                });

        }
    }
}