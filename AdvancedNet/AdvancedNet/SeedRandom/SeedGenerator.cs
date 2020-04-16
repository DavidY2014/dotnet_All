using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet.SeedRandom
{
    public class SeedGenerator
    {
        /// <summary>
        /// 使用一个种子，结果一样
        /// </summary>
        public void UseSameSeed()
        {
            Random r1 = new Random(1);
            Random r2 = new Random(0);
            Console.WriteLine(r1.Next(100) + ", " + r1.Next(100));      // 24, 11
            Console.WriteLine(r2.Next(100) + ", " + r2.Next(100));      // 24, 11
        }

        /// <summary>
        /// 默认用本地时间做种子，但是时间间隔太短的话，结果也一样
        /// </summary>
        public void UseShortClockTimeSeed()
        { 

        }

    }
}
