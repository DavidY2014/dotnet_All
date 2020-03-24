using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Advanced.NetFrame.WebAPI.Utility
{
    public class ContainerFactory
    {
        public static IUnityContainer BuildContainer()
        {
            return _Container;
        }

        private static IUnityContainer _Container = null;

        /// <summary>
        /// ioc容器工厂
        /// </summary>
        static ContainerFactory()
        {
            //增加配置过程
            _Container = new UnityContainer();

        }
    }

}