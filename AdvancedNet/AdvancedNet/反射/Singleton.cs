using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet
{
    public sealed class Singleton
    {
        private static Singleton _Singleton = null;

        //构造函数私有化，那么就无法被new出来
        private Singleton()
        { 
        
        }

        /// <summary>
        /// 静态构造函数由clr管理，在程序执行的时候会创建一次
        /// </summary>
        static Singleton()
        {
            _Singleton = new Singleton();
        }

        public static Singleton GetInstance()
        {
            return _Singleton;
        }
    }
}
