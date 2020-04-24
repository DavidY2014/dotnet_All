using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Core.Test.Aop;
using Core.Test.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Core.Test
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        //autofac×¢Èë
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<MyService>().As<IService>();
            //ÃüÃû×¢²á
            builder.RegisterType<MyService>().Named<IService>("Service2");

            #region ÆôÓÃaop

            builder.RegisterType<MyInterceptor>();
            builder.RegisterType<MyService>().As<IService>()
                .PropertiesAutowired().
                InterceptedBy(typeof(MyInterceptor)).EnableInterfaceInterceptors();

            #endregion

        }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            var service = this.AutofacContainer.ResolveNamed<IService>("Service2");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           




            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
