using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedNet.Cache
{
    /// <summary>
    /// 通过一个静态字典实现缓存功能
    /// </summary>
    public class MyCache
    {
        /// <summary>
        /// static，不会被GC
        /// </summary>
        private static Dictionary<string, object> CustomDic = new Dictionary<string, object>();


        public static void Add(string key,object oValue)
        {
            CustomDic.Add(key, oValue);
        }

        /// <summary>
        /// 加过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="oValue"></param>
        /// <param name="timeOut"></param>
        public static void Add(string key, object oValue,int timeOut)
        {
            CustomDic.Add(key, new DataModel()
            {
                Value = oValue,
                DeadLine = DateTime.Now.AddSeconds(timeOut)
            });
        }


        public static T Get<T>(string key)
        {
            return (T)CustomDic[key];
        }

        public static bool Exists(string key)
        {
            return CustomDic.ContainsKey(key);
        }

        public static T GetT<T>(string key,Func<T> func)
        {
            T t = default(T);
            if (!MyCache.Exists(key))
            {
                t = func.Invoke();
                MyCache.Add(key, t);
            }
            else
            {
                t = MyCache.Get<T>(key);
            }
            return t;
        }


    }

    /// <summary>
    /// 创造多个容器，多个锁，且锁和容器对应起来，这样可以实现性能的提升
    /// </summary>
    public class NewMyCache
    {
        private static int CPUNumber = 0;
        private static List<Dictionary<string, object>> DictionaryList =
            new List<Dictionary<string, object>>();

        private static List<object> LockList = new List<object>();

        static NewMyCache()
        {
            CPUNumber = 3;
            for (int i=0;i<CPUNumber;i++)
            {
                DictionaryList.Add(new Dictionary<string, object>());
                LockList.Add(new object());
            }
        }

        public static void Run()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        for (int i =0;i<CPUNumber;i++)
                        {
                            lock (LockList[i])
                            {
                                foreach (var key in DictionaryList[i].Keys)
                                {   
                                    
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    { 
                    
                    }
                }
            });

        }


    }
}
