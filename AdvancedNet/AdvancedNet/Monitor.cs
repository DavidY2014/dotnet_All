using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdvancedNet
{

    /// <summary>
    /// 测试泛型，常规，object参数的性能
    /// </summary>
    public class Monitor
    {
 

        public static void Test()
        {
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i=0;i<100_1000_000;i++)
                {
                    GenericMethod.ShowInt(i);
                }
                watch.Stop();

            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 100_1000_000; i++)
                {
                    GenericMethod.ShowObject(i);
                }
                watch.Stop();

            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 100_1000_000; i++)
                {
                    GenericMethod.Show<int>(i);
                }
                watch.Stop();

            }

        }



    }
}
