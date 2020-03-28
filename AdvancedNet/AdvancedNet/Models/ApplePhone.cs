using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace AdvancedNet.Models
{
    public class ApplePhone : IPhone
    {
        //属性注入
        [Dependency] 
        public IMicrophone iMicrophone { get; set; }

        public IHeadPhone iHeadphone { get; set; }


        //构造函数注入
        [InjectionConstructor]
        public ApplePhone(IHeadPhone headphone)
        {
            this.iHeadphone = headphone;
        }

        //注入方法
        [InjectionMethod]
        public void Init(IPower power)
        { 
            
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
