using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Advanced.Sql;

namespace AdvancedNet
{
    public class ReflectionHelper
    {
        public static void ReflectDllInfo()
        {
            #region Reflection
            {
                //Assembly assembly = Assembly.Load("Advanced.Sql");
                //Assembly assembly = Assembly.LoadFile("E:\\NetAll\\AdvancedNet\\Advanced.Sql\\bin\\Debug\\netcoreapp3.1\\Advanced.Sql.dll");
                //Assembly assembly2 = Assembly.LoadFrom("Advanced.Sql.dll");

                //foreach (var type in assembly.GetTypes())
                //{
                //    foreach (var method in type.GetMethods())
                //    { 

                //    }
                //}

                //创建对象
                //Type type =  assembly.GetType("Advanced.Sql.SqlHelper");
                //foreach (ConstructorInfo ctor in type.GetConstructors())
                //{
                //    Console.WriteLine(ctor.Name);
                //    foreach (var parameter in ctor.GetParameters())
                //    {
                //        Console.WriteLine(parameter.ParameterType);
                //    }
                //}
                //object sqlHelper = Activator.CreateInstance(type);
                ////sqlHelper.Query()//无法找到query方法
                //dynamic sqlHelper2 = Activator.CreateInstance(type);
                //sqlHelper2.Query(); // dynamice 运行时才检查
                //SqlHelper osqlHelpe = sqlHelper as SqlHelper;//不报错 ,如果类型不对就返回null

                ////构造函数不同参数设置
                //object sqlHelper3 = Activator.CreateInstance(type, new object[] { 1 });
                //object sqlHelper4 = Activator.CreateInstance(type, new object[] { "a" });

                {

                    //Console.WriteLine("********Singleton**************");
                    //Singleton singleton1 = Singleton.GetInstance();
                    //Singleton singleton2 = Singleton.GetInstance();
                    //Singleton singleton3 = Singleton.GetInstance();
                    //Console.WriteLine($"{object.ReferenceEquals(singleton1, singleton2)}");

                    ////反射破坏单例,通过反射可以调用私有构造函数
                    //Assembly assembly = Assembly.Load("AdvancedNet");
                    //Type type = assembly.GetType("AdvancedNet.Singleton");
                    //Singleton singletonA = (Singleton)Activator.CreateInstance(type,true);
                    //Singleton singletonB = (Singleton)Activator.CreateInstance(type, true);
                    //Console.WriteLine($"{object.ReferenceEquals(singletonA, singletonB)}");

                }

                {
                    //Console.WriteLine("*************GenericClass****************");
                    //Assembly assembly = Assembly.Load("AdvancedNet");
                    //Type type = assembly.GetType("AdvancedNet.GenericConstriant`3");
                    //Type typeMake = type.MakeGenericType(new Type[] { typeof(int), typeof(int), typeof(string) });
                    //object oGeneric = Activator.CreateInstance(typeMake);
                }

                {
                    //Console.WriteLine("*************GenericMethod****************");
                    //Assembly assembly = Assembly.Load("AdvancedNet");
                    //Type type = assembly.GetType("AdvancedNet.GenericConstriant`3");
                    //Type typeMake = type.MakeGenericType(new Type[] { typeof(int), typeof(int), typeof(string) });
                    //object oGeneric = Activator.CreateInstance(typeMake);
                }
                {
                    Console.WriteLine("*************GenericMethod****************");
                    Assembly assembly = Assembly.Load("AdvancedNet");
                    Type type = assembly.GetType("AdvancedNet.GenericMethod");
                    object oInstance = Activator.CreateInstance(type);
                    MethodInfo method = type.GetMethod("ShowInfo");
                    method.Invoke(oInstance, null);
                    MethodInfo method2 = type.GetMethod("ShowInfo2");
                    method2.Invoke(oInstance,new object[] { 2020});

                }

            }



            #endregion



        }




    }
}
