using System;
using Core.Framework.Configure;
using Core.Framework.Hosting;
using Core.Framework.interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Core.Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            //var collector = new FakeMetricsCollector();
            //Console.WriteLine("Hello World!");
            //new HostBuilder()
            ////这个允许接收命令行args参数
            //.ConfigureHostConfiguration(builder => builder.AddCommandLine(args))

            ////都是hostbuilder的扩展方法
            //.ConfigureAppConfiguration((context, builder) => builder
            //.AddJsonFile("appSettings.json")
            //.AddJsonFile(path: $"appSettings.{context.HostingEnvironment.EnvironmentName}.json",
            //         optional: true))

            ////这是注册服务
            //.ConfigureServices((context, svcs) => svcs
            //.AddSingleton<IProcessorMetricsCollector>(collector)
            //.AddSingleton<IMemoryMetricsCollector>(collector)
            //.AddSingleton<INetworkMetricsCollector>(collector)
            //.AddSingleton<IMetricsDeliver, FakeMetricsDeliver>()
            //.AddSingleton<IHostedService, PerformanceMetricsCollector>()
            ////这是IServiceCollection扩展方法
            //.AddOptions()
            //.Configure<MetricsCollectionOptions>(context.Configuration.GetSection("MetricsCollection")))


            //    .Build()
            //    .Run();


            #region 管道,针对http请求

            //创建一个服务器来接受HTTP请求，并通过config注册中间件来处理请求
      






            #endregion

        }
    }
}
