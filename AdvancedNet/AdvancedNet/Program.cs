using System;
using Advanced.Framework;
using AdvancedNet.Models;

namespace AdvancedNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //ReflectionHelper.ReflectDllInfo();

            #region attribute

            //var people1 = new Student()
            //{
            //    Name = "jack",
            //    Age = 20
            //};
            //people1.Study("语文");
            //people1.Answer();

            //var student = new VipStudent()
            //{
            //    Name = "vip jack",
            //};
            //InvokeTest.ManageStudent<VipStudent>(student);

            var info =AttributeExtend.GetRemark(StudentState.Frozen);
            Console.WriteLine(info);
            #endregion

        }
    }
}
