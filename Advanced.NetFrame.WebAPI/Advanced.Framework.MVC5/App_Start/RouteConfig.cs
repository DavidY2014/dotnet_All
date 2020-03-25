using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Advanced.Framework.MVC5
{
    /// <summary>
    /// 路由是按照顺序来匹配的,成功匹配后就不继续往下了
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// 路由匹配
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes是个字典，name相当于 key，后面的路由规则的name不能重复命名
            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Test",
                url: "Test/{action}/{id}", //先匹配这个路由，如果没有跑到下面默认的路由
                defaults: new { controller = "Second", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Regex",
                url: "{controller}/{action}_{year}_{month}_{day}",
                defaults: new { controller = "Second", action = "Index", id = UrlParameter.Optional },
                constraints:new { year=@"\d{4}",month=@"\d{2}",day=@"\d{2}"}
            );

       
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );




        }
    }
}
