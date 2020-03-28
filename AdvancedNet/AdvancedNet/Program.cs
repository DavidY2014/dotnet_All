using System;
using Advanced.Framework;
using AdvancedNet.Models;
using AdvancedNet.Unity;

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

            //var info =AttributeExtend.GetRemark(StudentState.Frozen);
            //StudentState state = StudentState.Frozen;
            //var info = state.GetRemark();
            //Console.WriteLine(info);
            #endregion

            {
                #region 数据验证
                //var student = new VipStudent()
                //{
                //    Name = "TOM",
                //    QQ = 3123123123131
                //};
                //if (student.Validata<VipStudent>())
                //{ 
                    
                //}


                #endregion
            }

            {
                #region 委托调用
                //DelegteTest.Run();
                //DelegteTest.MulitiRun();

                #endregion
            }
            {
                #region unity

                IocTest ioc = new IocTest();
                ioc.Test();

                #endregion
            }
        }
    }
}
