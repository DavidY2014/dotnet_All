using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Advanced.Framework;
using AdvancedNet.Models;

namespace AdvancedNet
{
    public class InvokeTest
    {
        public static void ManageStudent<T>(T student) where T : Student
        {
            student.Study("course1");
            //反射调用特性
            Type type = student.GetType();
            if (type.IsDefined(typeof(MyCustomAttribute),true))
            {
                //获取类修饰的特性
                object[] oAttributeArray =  type.GetCustomAttributes(typeof(MyCustomAttribute), true);
                foreach (MyCustomAttribute attribute1 in oAttributeArray)
                {
                    attribute1.Show();
                }

                foreach (var prop in type.GetProperties())
                {
                    if (prop.IsDefined(typeof(MyCustomAttribute), true))
                    {
                        //获取属性修饰的特性
                        object[] oAttributePropArray = prop.GetCustomAttributes(typeof(MyCustomAttribute), true);
                        foreach (MyCustomAttribute attribute2 in oAttributePropArray)
                        {
                            attribute2.Show();
                        }
                    }
                }


                foreach (var method in type.GetMethods())
                {
                    //判断是否用特性修饰了
                    if (method.IsDefined(typeof(MyCustomAttribute), true))
                    {
                        //获取方法修饰的特性
                        object[] oAttributeMethodArray = method.GetCustomAttributes(typeof(MyCustomAttribute), true);
                        foreach (MyCustomAttribute attribute3 in oAttributeMethodArray)
                        {
                            attribute3.Show();
                        }
                    }
                }


            }

        }

    }
}
