using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet
{
    public class GenericMethod
    {

        /// <summary>
        /// 这种会涉及到装箱拆箱，对性能有损耗
        /// object是堆，int这些是栈，栈到堆需要copy损耗，拆箱也是
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), oParameter.GetType().Name, oParameter);
        }

        public void ShowInfo()
        {
            Console.WriteLine("Show Info Method");
        }

        public void ShowInfo2(int id)
        {
            Console.WriteLine($"Show Info Method {id}");
        }

        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericMethod), tParameter.GetType().Name, tParameter);
        }

        public static void ShowInt(int i)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
               typeof(GenericMethod), i.GetType().Name, i);
        }
    }
}
