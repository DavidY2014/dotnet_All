using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Framework.Middlewares
{
    //显示创建中间件
    public class StringContentMiddleware : IMiddleware
    {
        private readonly string _contents;

        public StringContentMiddleware(string contents)
        {
            _contents = contents;
        }
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            return context.Response.WriteAsync(_contents);
        }
    }
}
