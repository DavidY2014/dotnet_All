using System;
using System.Collections.Generic;
using System.Text;
using AdvancedNet.Models;
using Unity;

namespace AdvancedNet.Unity
{
    public class IocTest
    {
        public void Test()
        {
            {
                //IUnityContainer container = new UnityContainer();
                ////container.RegisterType<IPhone,AndroidPhone>();//接口注册
                ////container.RegisterType<AbstractPad, ApplePad>();//抽象类注册
                ////container.RegisterType<ApplePad, ApplePadChild>();//普通继承类注册
                ////IPhone iphone = container.Resolve<IPhone>();
                ////AbstractPad abstractPad = container.Resolve<AbstractPad>();
                ////ApplePad applePad = container.Resolve<ApplePad>();

                //#region 依赖注入
                //container.RegisterType<IPhone, ApplePhone>();
                //container.RegisterType<IHeadPhone, AppleHeadPhone>();
                //container.RegisterType<IMicrophone, Mircophone>();
                //container.RegisterType<IPower, Power>();
                //IPhone iphone = container.Resolve<IPhone>();
                //IPower power = container.Resolve<IPower>();
                //iphone.Init(power);
                //#endregion
            }
            {
                IDavidCustomContainer container = new DavidCustomContainer();
                container.RegisterType<IPhone, AndroidPhone>();
                container.RegisterType<AbstractPad, ApplePad>();
                container.RegisterType<IHeadPhone, AppleHeadPhone>();
                container.RegisterType<IPower, Power>();
                IPhone phone = container.Resolve<IPhone>();
            }

        }
    }
}
