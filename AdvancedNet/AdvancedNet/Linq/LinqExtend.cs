using System;
using System.Collections.Generic;
using System.Text;
using AdvancedNet.Models;


namespace AdvancedNet.Linq
{
    /// <summary>
    /// Linq的扩展实现方式也是通过扩展方法+委托实现的
    /// linq to object 针对内存数据
    /// linq to sql 针对数据库数据
    /// 两者操作的对象不同，传入的委托有区别
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
