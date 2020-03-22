using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet
{
    /// <summary>
    /// 委托可以做到代码优化，去掉重复的代码，把重复的代码包装成一个委托进行调用
    /// </summary>
    /// <param name="param"></param>
    public delegate void MethodDelegate(string param);
    public class DelegteTest
    {
        public static void Method1(string name)
        {
            Console.WriteLine("Method1" + name);
        }

        public static void Method2(string name)
        {
            Console.WriteLine("Method1" + name);
        }
        public static void Method3(string name)
        {
            Console.WriteLine("Method1" + name);
        }
        public static void Method4(string name)
        {
            Console.WriteLine("Method1" + name);
        }

        public static void MethodWithoutParam1()
        {
            Console.WriteLine("MethodWithoutParam1");
        }

        public static void MethodWithoutParam2()
        {
            Console.WriteLine("MethodWithoutParam");
        }

        public static void MethodWithoutParam3()
        {
            Console.WriteLine("MethodWithoutParam3");
        }

        public static void MethodWithoutParam4()
        {
            Console.WriteLine("MethodWithoutParam4");
        }

        public static void LoadMethod(string param, MethodDelegate methodLoader)
        {
            methodLoader.Invoke(param);
        }




        public static void Run()
        {
            LoadMethod("1",Method1);
            LoadMethod("2", Method2);
            LoadMethod("3", Method3);
            LoadMethod("4", Method4);
        }


        public static void MulitiRun()
        {
            Action action = MethodWithoutParam1;
            action += MethodWithoutParam2;
            action += MethodWithoutParam3;
            action += MethodWithoutParam4;
            foreach (Action item in action.GetInvocationList())
            {
                item.Invoke();
                item.BeginInvoke(null,null);
            }


        }

   

    }
}
