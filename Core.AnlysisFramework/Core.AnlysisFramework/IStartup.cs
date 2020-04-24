using System;
using System.Collections.Generic;
using System.Text;
using Core.AnlysisFramework.ApplicationBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.AnlysisFramework
{

    /// <summary>
    /// 包含了Startup中基本的两个方法
    /// </summary>
    public interface IStartup
    {
        IServiceProvider ConfigureServices(IServiceCollection services);

        void Configure(IApplicationBuilder app);
    }
}
