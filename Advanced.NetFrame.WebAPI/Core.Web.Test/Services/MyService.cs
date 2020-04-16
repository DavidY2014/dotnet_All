using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Core.Web.Test.Interfaces;
using Core.Web.Test.Aop;

namespace Core.Web.Test.Services
{
    [Intercept(typeof(MyRecordInterceptor))]
    public class MyService:IService
    {

        public void Show()
        {
            Console.WriteLine("MyService:Show");
        }
    }
}
