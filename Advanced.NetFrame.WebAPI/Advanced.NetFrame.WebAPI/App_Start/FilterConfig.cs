using System.Web;
using System.Web.Mvc;
using Advanced.NetFrame.WebAPI.Utility.Filters;

namespace Advanced.NetFrame.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //全局生效，但是登陆接口可以去除掉，加个特性
            filters.Add(new CustomBasicAuthorizeAttribute());
        }
    }
}
