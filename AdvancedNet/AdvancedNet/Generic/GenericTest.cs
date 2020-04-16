using System;
using System.Collections.Generic;
using System.Text;
using AdvancedNet.Models;

namespace AdvancedNet
{

    /// <summary>
    /// 泛型约束
    /// </summary>
    public class GenericConstriant<T1,T2,T3>
    {
        public static void Show<T>(T tParameter)  where T:People
        { 
        
        }

    }


    public class GenericTest
    {

        public T Get<T, S, T1>()
        {
            throw new Exception();
        }

        /// <summary>
        /// 引用类型可以返回null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>()
            //where T :class//引用类型
            //where T : struct//值类型
            where T:new() //无参数构造函数
        {
            //return default(T);//default 这个关键字会根据T的类型去获取
            return new T();
        }

    }

    public class ChildClass : GenericClass<int>, GenericInterface<string>
    { 
    
    }


    /// <summary>
    /// 把泛型参数传进来
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="R"></typeparam>
    public class GenericChildClass<T, R> : GenericClass<T>, GenericInterface<R>
    { 
    
    }

    public class GenericClass<T>
    { 
    
    }

    public interface GenericInterface<T>
    {

    }

    public delegate void Do<T>();
}
