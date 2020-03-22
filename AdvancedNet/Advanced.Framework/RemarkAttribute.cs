using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.Framework
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RemarkAttribute:Attribute
    {
        public string Info { get; private set; }
        public RemarkAttribute(string info)
        {
            this.Info = info;
        }

    }
}
