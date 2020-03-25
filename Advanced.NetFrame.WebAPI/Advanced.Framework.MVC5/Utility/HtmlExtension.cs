using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advanced.Framework.MVC5.Utility
{
    public  static class HtmlExtension
    {
        /// <summary>
        /// 自定义的换行
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString Br(this HtmlHelper helper)
        {
            var builder = new TagBuilder("br");
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
                    
        }

    }
}