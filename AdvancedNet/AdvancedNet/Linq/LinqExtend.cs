using System;
using System.Collections.Generic;
using System.Text;
using AdvancedNet.Models;


namespace AdvancedNet.Linq
{
    /// <summary>
    /// Linq的扩展实现方式也是通过扩展方法+委托实现的
    /// </summary>
    public static class LinqExtend
    {
        public static List<T> MyWhere<T>(this List<T> source ,Func<T,bool> func )
        {
            //构造原始的linq过滤
            var list = new List<T>();
            foreach (var item in source)
            {
                if (func.Invoke(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public static IEnumerable<T> MyWhereIterator<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            foreach (var item in source)
            {
                if (func.Invoke(item))
                {
                    yield return item; // yield 和 IEnumerable 配对使用
                }
            }
        }

    }
}
