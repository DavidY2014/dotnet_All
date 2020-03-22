using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.Framework
{
    /// <summary>
    /// 可以通过扩展方法更简便写法
    /// </summary>
    public static class AttributeExtend
    {
        public static string GetRemark(this StudentState value)
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

        public static bool Validata<T>(this T t)
        {
            Type type = t.GetType();
            foreach (var prop in type.GetProperties())
            {
                //抽象方法验证
                if (prop.IsDefined(typeof(AbstractValidateAttribute), true))
                {
                    object oValue = prop.GetValue(t);
                    foreach (AbstractValidateAttribute attribute in prop.GetCustomAttributes(typeof(AbstractValidateAttribute),true))
                    {
                        if (!attribute.Validate(oValue))
                            return false;
                    }
                }

                //object oValue = prop.GetValue(t);
                ////数据范围校验
                //if (prop.IsDefined(typeof(DataValiateAttribute),true))
                //{
                //    DataValiateAttribute attribute = (DataValiateAttribute)prop.GetCustomAttributes(typeof(DataValiateAttribute), true)[0];
                //    if (!attribute.Validate(oValue))
                //        return false;
                //}
                ////required校验
                //if (prop.IsDefined(typeof(RequiredAttribute), true))
                //{
                //    RequiredAttribute attribute = (RequiredAttribute)prop.GetCustomAttributes(typeof(RequiredAttribute), true)[0];
                //    if (!attribute.Validate(oValue))
                //        return false;
                //}
            }
            return true;
        }


    }
}
