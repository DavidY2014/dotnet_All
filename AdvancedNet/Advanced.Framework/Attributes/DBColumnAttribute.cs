using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DBColumnAttribute:Attribute
    {
        private string _columnName = null;

        public DBColumnAttribute(string columnName)
        {
            this._columnName = columnName;
        }

        /// <summary>
        /// 可以在扩展方法中获取
        /// </summary>
        /// <returns></returns>
        public string GetColumnName()
        {
            return this._columnName;
        }

    }
}
