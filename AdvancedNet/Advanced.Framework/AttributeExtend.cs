using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.Framework
{
    public class AttributeExtend
    {
        public static string GetRemark(Enum value)
        {
            Type type = value.GetType();
            var field = type.GetField(value.ToString());
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttributes(typeof(RemarkAttribute), true)[0];
                return attribute.Info;
            }
            else
            {
                return value.ToString();
            }



        }
    }
}
