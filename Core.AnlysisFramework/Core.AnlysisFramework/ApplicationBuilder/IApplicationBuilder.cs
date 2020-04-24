using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.AnlysisFramework.ApplicationBuilder
{
    /// <summary>
    /// 定义了请求管道行为
    /// </summary>
    public interface IApplicationBuilder
    {
        IServiceProvider ApplicationServices { get; set; }

        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
    }
}
