using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Core.Web.Test.Aop;
using Core.Web.Test.Filters;
using Core.Web.Test.Interfaces;
using Core.Web.Test.Middlewares;
using Core.Web.Test.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Web.Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// autofac 接管
        /// </summary>
        /// <param name="services"></param>
        //public IServiceProvider ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllersWithViews();

        //    //实例一个容器
        //    ContainerBuilder containerbuilder = new ContainerBuilder();

        //    containerbuilder.Populate(services);//接管IServicecollection容器的工作
        //    //注册服务
        //    containerbuilder.Register(a => new MyRecordInterceptor());
        //    containerbuilder.RegisterType<MyService>().As<IService>().EnableInterfaceInterceptors().SingleInstance();
        //    IContainer container = containerbuilder.Build();
        //    return new AutofacServiceProvider(container);
        //}

        public void ConfigureContainer(ContainerBuilder builder)
        {
            ////业务逻辑层所在程序集命名空间
            ////Assembly service = Assembly.Load("NetCoreDemo.Service");
            ////接口层所在程序集命名空间
            ////Assembly repository = Assembly.Load("NetCoreDemo.Repository");
            ////自动注入
            //builder.RegisterAssemblyTypes(service, repository)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces();
            ////注册仓储，所有IRepository接口到Repository的映射
            //builder.RegisterGeneric(typeof(Repository<>))
            //    //InstancePerDependency：默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象；
            //    .As(typeof(IRepository<>)).InstancePerDependency();

            builder.RegisterType<MyService>().As<IService>();
            builder.RegisterType<MyRecordInterceptor>();
            builder.RegisterType<MyService>().As<IService>().EnableInterfaceInterceptors().SingleInstance();

        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddMvc(o => {
            //    o.Filters.Add(typeof(CustomExceptionFilterAttribute)); //全局注册filter
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            ,ILoggerFactory factory)
        {

            ILogger<Startup> _ilogger =  factory.CreateLogger<Startup>();
            _ilogger.LogError($"this is start up error");


            #region aspnetcore 读取配置文件
            //Console.WriteLine($"option1 = {this.Configuration["options1"]}");
            //Console.WriteLine($"option2 = {this.Configuration["subsection:suboption1"]}");
            //Console.WriteLine($"option2 = {this.Configuration["subsection:0:suboption1"]}");

            #endregion

            #region 认证授权
            //app.Map("/login", builder => builder.Use(next =>
            //{
            //    return async (context) =>
            //    {
            //        var claimIdentity = new ClaimsIdentity();
            //        claimIdentity.AddClaim(new Claim(ClaimTypes.Name, "TestUser"));
            //        await context.SignInAsync("",new ClaimsPrincipal(claimIdentity));
            //        await context.Response.WriteAsync("login successed");
            //    };
            //})
            //);



            #endregion



            app.UseMiddleware<FirstMiddleware>();


            //middleware1
            app.Use(next =>
            {
                return new RequestDelegate(async context => {
                    await context.Response.WriteAsync("middleware 1 start <br>");
                    await next.Invoke(context);
                    await context.Response.WriteAsync("middleware 1 end <br>");
                });
            });

            //middleware2
            app.Use(next =>
            {
                return new RequestDelegate(async context => {
                    await context.Response.WriteAsync("middleware 2 start <br>");
                    await next.Invoke(context);//next是个func
                    await context.Response.WriteAsync("middleware 2 end <br>");
                });
            });

            //middleware3
            app.Use(next =>
            {
                return new RequestDelegate(async context => {
                    await context.Response.WriteAsync("middleware 3 start <br>");
                    await next.Invoke(context);
                    await context.Response.WriteAsync("middleware 3 end <br>");
                });
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
           

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
