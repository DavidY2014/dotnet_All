using System;

namespace Advanced.Framework
{
    /// <summary>
    /// 默认是只能用一次attribute，但是设置后也可以用多个特性
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class CustomAttribute: Attribute
    {
        public CustomAttribute()
        {

        }
        public CustomAttribute(int id)
        {

        }
        public CustomAttribute(string name)
        {

        }

    }
}
