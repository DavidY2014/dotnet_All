using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdvancedNet.Unity
{
    public interface IDavidCustomContainer
    {
        void RegisterType<TFrom, TTo>();
        T Resolve<T>();
    }


    /// <summary>
    /// 就是一个工厂容器
    /// </summary>
    public class DavidCustomContainer: IDavidCustomContainer
    {
        private Dictionary<string, Type> davidContainerDic = 
            new Dictionary<string, Type>();
        public void RegisterType<TFrom,TTo>()
        {
            davidContainerDic.Add(typeof(TFrom).FullName, typeof(TTo));

        }

        public T Resolve<T>()
        {
            Type type = davidContainerDic[typeof(T).FullName];
            return (T)this.CreateObject(type);
        }

        /// <summary>
        /// 递归实现构造函数的参数查找
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private object CreateObject(Type type)
        {
            //找有参数构造函数,先进行特性判断
            ConstructorInfo[] ctorArray = type.GetConstructors();
            ConstructorInfo ctor = null;
            if (ctorArray.Count(c => c.IsDefined(typeof(DavidInjectionConstructorAttribute), true)) > 0)
            {
                ctor = ctorArray.FirstOrDefault(c => c.IsDefined(typeof
                    (DavidInjectionConstructorAttribute), true));
            }
            else
            {
                //如果没有特性的话，就找参数最多的那个构造函数
                ctor = ctorArray.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
            }
            //获取到构造函数参数
            List<object> paraList = new List<object>();
            foreach (var parameter in ctor.GetParameters())
            {
                //需要构造注入的对象，依赖对象
                //这个是抽象类型，不能直接构造实例，所以需要从字典中获取真实的实例类型进行构造
                Type paraType = parameter.ParameterType;
                Type targetType = this.davidContainerDic[paraType.FullName];
                //继续检查targetType的构造函数，需要通过递归实现
                object para = this.CreateObject(targetType);
                paraList.Add(para);
            }

            return Activator.CreateInstance(type, paraList.ToArray());
        }

    }

}
