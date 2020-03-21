using System;
using System.Collections.Generic;
using System.Text;
using AdvancedLibraies.Model;

namespace AdvancedLibraies.DAL
{
    /// <summary>
    /// 缓存固定sql,同类型的sql操作一样
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlBuilder<T> where T:BaseModel
    {
        public static string FindSql = null;
        public static string FindAllql = null;
        
        /// <summary>
        /// 静态构造可实现缓存
        /// </summary>
        static SqlBuilder()
        { 
            
        }

    }
}
