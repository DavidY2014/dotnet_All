using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdvancedNet.Unity
{
    public interface IDavidCustomContainer
    {
        void RegisterType<TFrom, TTo>(LifeTimeType lifeTimeType = LifeTimeType.Transient);
        T Resolve<T>();
    }


    /// <summary>
    /// 就是一个工厂容器
    /// </summary>
    public class DavidCustomContainer: IDavidCustomContainer
    {
        private Dictionary<string, RegisterInfo> davidContainerDic = 
            new Dictionary<string, RegisterInfo>();

        /// <summary>
        /// 保存内存对象的实例
        /// </summary>
        private Dictionary<Type, object> TypeObjectDic = new Dictionary<Type, object>();

        public void RegisterType<TFrom,TTo>(LifeTimeType lifeTimeType = LifeTimeType.Transient)
        {
            davidContainerDic.Add(typeof(TFrom).FullName, new RegisterInfo()
            {
                TargetType = typeof(TTo),
                LiftTime = lifeTimeType
            });
        }

        public T Resolve<T>()
        {
            RegisterInfo info = davidContainerDic[typeof(T).FullName];
            Type type = davidContainerDic[typeof(T).FullName].TargetType;
            T result = default(T);
            //对生命周期进行处理
            switch (info.LiftTime)
            {
                case LifeTimeType.Transient:
                    result = (T)this.CreateObject(type);
                    break;
                case LifeTimeType.Singleton:
                    if (this.TypeObjectDic.ContainsKey(type))
                    {
                        result = (T)this.TypeObjectDic[type];
                    }
                    else
                    {
                        result = (T)this.CreateObject(type);
                        this.TypeObjectDic.Add(type, result);
                    }
                    break;
                case LifeTimeType.PerThread:
                    //线程槽,netcore已经不支持CallContext,自己封装一个
                    {
                        string key = type.FullName;
                        object oValue = CallContext.GetData(key);
                        if (oValue == null)
                        {
                            result = (T)this.CreateObject(type);
                            CallContext.SetData(key, result);
                        } 
                        else
                        {
                            result = (T)oValue;
                        }
                    }
                    break;
                default:
                    throw new Exception("Wrong");
            }
            return result;
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
                RegisterInfo info = this.davidContainerDic[paraType.FullName];
                Type targetType = info.TargetType;
                //继续检查targetType的构造函数，需要通过递归实现
                //object para = this.CreateObject(targetType);
                object para = null;
                #region 
                switch (info.LiftTime)
                {
                    case LifeTimeType.Transient:
                        para = this.CreateObject(targetType);
                        break;
                    case LifeTimeType.Singleton:
                        //线程不安全，需要通过双if+lock
                        if (this.TypeObjectDic.ContainsKey(targetType))
                        {
                            para =this.TypeObjectDic[targetType];
                        }
                        else
                        {
                            para = this.CreateObject(targetType);
                            this.TypeObjectDic.Add(targetType, para);
                        }
                        break;
                    case LifeTimeType.PerThread:
                        //线程槽,netcore已经不支持CallContext,自己封装一个
                        {
                            string key = type.FullName;
                            object oValue = CallContext.GetData(key);
                            if (oValue == null)
                            {
                                para = this.CreateObject(targetType);
                                CallContext.SetData(key, para);
                            }
                            else
                            {
                                para = oValue;
                            }
                        }
                        break;
                    default:
                        throw new Exception("Wrong");
                }
                #endregion
                paraList.Add(para);
            }

            return Activator.CreateInstance(type, paraList.ToArray());
        }

    }

    /// <summary>
    /// 考虑容器中对象的生命周期
    /// </summary>
    public class RegisterInfo
    { 
        public Type TargetType { get; set; }

        public LifeTimeType LiftTime { get; set; }
    }


    /// <summary>
    /// 生命周期类型
    /// </summary>
    public enum LifeTimeType
    { 
        Transient,
        Singleton,
        PerThread
    }

}
