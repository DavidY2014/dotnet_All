using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //引入框架的DI容器
            IServiceCollection container = new ServiceCollection();
            //container.AddTransient<IService>();//扩展方法
            //ServiceProvider provider =  container.BuildServiceProvider();
            //provider.GetService<IService>()


            //IConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.AddInMemoryCollection(new Dictionary<string, string>()
            //{
            //    { "key1","value1"},
            //    { "key2","value2"}
            //});
            //IConfigurationRoot congfigurationRoot = builder.Build();
            //Console.WriteLine(congfigurationRoot["key1"]);

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
