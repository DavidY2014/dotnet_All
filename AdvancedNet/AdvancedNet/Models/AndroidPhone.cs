using System;
using System.Collections.Generic;
using System.Text;
using AdvancedNet.Unity;

namespace AdvancedNet.Models
{
    public class AndroidPhone : IPhone
    {
        /// <summary>
        /// 自定义特性标识
        /// </summary>
        /// <param name="pad"></param>
        //[DavidInjectionConstructor]
        public AndroidPhone(AbstractPad pad)
        {

        }


        public AndroidPhone(AbstractPad pad,IHeadPhone phone)
        {

        }


        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Init(IPower power)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
