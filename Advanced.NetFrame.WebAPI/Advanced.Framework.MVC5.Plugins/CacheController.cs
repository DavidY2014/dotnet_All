using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advanced.Framework.MVC5.Plugins
{
    /// <summary>
    /// controller可以跨工程建立，只要继承controller,引用system.web.mvc.dll ，然后在启动工程引用类库就行
    /// </summary>
    public class CacheController: Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
