using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Core.AspnetCodeAnalysis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            #region ×Ô¶¨Òåmiddleware

            app.Use(next =>
            {
                return async ctx =>
                {
                    Console.WriteLine($"Middleware 1 start {DateTime.Now}\n");
                    await next.Invoke(ctx);
                    Console.WriteLine($"Middleware 1 end {DateTime.Now}\n");
                };
            });

            app.Use(next =>
            {
                return async ctx =>
                {
                    Console.WriteLine($"Middleware 2 start {DateTime.Now}\n");
                    await next.Invoke(ctx);
                    Console.WriteLine($"Middleware 2 end {DateTime.Now}\n");
                };
            });

            app.Use(next =>
            {
                return async ctx =>
                {
                    Console.WriteLine($"Middleware 3 start {DateTime.Now}\n");
                    await next.Invoke(ctx);
                    Console.WriteLine($"Middleware 3 end {DateTime.Now}\n");
                };
            });

            //app.UseMiddleware<>();


            #endregion



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
