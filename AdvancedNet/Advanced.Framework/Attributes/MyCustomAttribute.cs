using System;

namespace Advanced.Framework
{
    /// <summary>
    /// 默认是只能用一次attribute，但是设置后也可以用多个特性
    /// </summary>
    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Class)]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MyCustomAttribute: Attribute
    {

        public string Remark;
        private string Name;
        public string Description { get; set; }
        public MyCustomAttribute()
        {

        }
        public MyCustomAttribute(int id)
        {

        }
        public MyCustomAttribute(string name)
        {
            this.Name = name;
        }

        public void Show()
        {
            Console.WriteLine($"This is {this.Remark}_{this.Description}");
        }


    }
}
