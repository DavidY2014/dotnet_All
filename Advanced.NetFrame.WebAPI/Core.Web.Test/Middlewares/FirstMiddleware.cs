using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Web.Test.Middlewares
{
    public class FirstMiddleware 
    {
        private readonly RequestDelegate _next;
        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, RequestDelegate next)
        {
             await _next(context);
        }
    }
}
