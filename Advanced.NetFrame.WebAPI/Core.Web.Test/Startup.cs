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
        /// autofac �ӹ�
        /// </summary>
        /// <param name="services"></param>
        //public IServiceProvider ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllersWithViews();

        //    //ʵ��һ������
        //    ContainerBuilder containerbuilder = new ContainerBuilder();

        //    containerbuilder.Populate(services);//�ӹ�IServicecollection�����Ĺ���
        //    //ע�����
        //    containerbuilder.Register(a => new MyRecordInterceptor());
        //    containerbuilder.RegisterType<MyService>().As<IService>().EnableInterfaceInterceptors().SingleInstance();
        //    IContainer container = containerbuilder.Build();
        //    return new AutofacServiceProvider(container);
        //}

        public void ConfigureContainer(ContainerBuilder builder)
        {
            ////ҵ���߼������ڳ��������ռ�
            ////Assembly service = Assembly.Load("NetCoreDemo.Service");
            ////�ӿڲ����ڳ��������ռ�
            ////Assembly repository = Assembly.Load("NetCoreDemo.Repository");
            ////�Զ�ע��
            //builder.RegisterAssemblyTypes(service, repository)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces();
            ////ע��ִ�������IRepository�ӿڵ�Repository��ӳ��
            //builder.RegisterGeneric(typeof(Repository<>))
            //    //InstancePerDependency��Ĭ��ģʽ��ÿ�ε��ã���������ʵ��������ÿ�����󶼴���һ���µĶ���
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
            //    o.Filters.Add(typeof(CustomExceptionFilterAttribute)); //ȫ��ע��filter
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            ,ILoggerFactory factory)
        {

            ILogger<Startup> _ilogger =  factory.CreateLogger<Startup>();
            _ilogger.LogError($"this is start up error");


            #region aspnetcore ��ȡ�����ļ�
            //Console.WriteLine($"option1 = {this.Configuration["options1"]}");
            //Console.WriteLine($"option2 = {this.Configuration["subsection:suboption1"]}");
            //Console.WriteLine($"option2 = {this.Configuration["subsection:0:suboption1"]}");

            #endregion

            #region ��֤��Ȩ
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
                    await next.Invoke(context);//next�Ǹ�func
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
