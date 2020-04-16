using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Core.Test.Aop
{
    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Intercepter before,Method:{invocation.Method.Name}");
            invocation.Proceed();
            Console.WriteLine($"Intercepter after,Method:{invocation.Method.Name}");

        }


    }
}
