using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet
{
    /// <summary>
    /// 泛型缓存,直接存放在编译器内部的，按照类型进行存储
    /// 局限性：只能为一个类型存储数据，同个类型的不同值不适用
    /// </summary>
    public class GenericCache<T>
    {
        private static string _TypeTime = "";
        static GenericCache()
        {
            _TypeTime = string.Format("{0}_{1}", typeof(T).FullName, 
                DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
        }

        public static string GetCache()
        {
            return _TypeTime;
        }

    }

    /// <summary>
    /// 字段缓存，静态属性常驻内存
    /// </summary>
    public class DictionaryCache
    {
        private static Dictionary<Type, string> _TypeTimeDictionary = null;

        static DictionaryCache()
        {
            _TypeTimeDictionary = new Dictionary<Type, string>();
        }

        public static string GetCache<T>()
        {
            Type type = typeof(Type);
            if (!_TypeTimeDictionary.ContainsKey(type))
            {
                _TypeTimeDictionary[type] = string.Format("{0}_{1}", typeof(T).FullName,
                    DateTime.Now.ToString("yyyyMMddHHmmss.fff"));            
            }
            return _TypeTimeDictionary[type];

        }
    }


}
