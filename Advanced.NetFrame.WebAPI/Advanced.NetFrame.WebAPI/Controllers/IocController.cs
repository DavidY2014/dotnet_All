using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Advanced.Framework.IInterfaces;
using Advanced.NetFrame.WebAPI.Utility;
using Unity;

namespace Advanced.NetFrame.WebAPI.Controllers
{

    /// <summary>
    /// 通过IOC 容器 Unity实现依赖反转，因为framework的api工程
    /// 没有自带ioc容器，需要自己手动安装
    /// </summary>
    public class IocController : ApiController
    {
        public object Get(int id)
        {
            //使用unity框架
            IUserService service = ContainerFactory.BuildContainer().Resolve<IUserService>();
            return service.Query(id);
        }


    }
}
