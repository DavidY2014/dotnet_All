using System;
using System.Collections.Generic;
using System.Text;
using AdvancedNet.Models;
using Unity;
using Unity.Lifetime;

namespace AdvancedNet.Unity
{
    public class IocTest
    {
        public void Test()
        {
            {
                IUnityContainer container = new UnityContainer();
                ////container.RegisterType<IPhone,AndroidPhone>();//接口注册
                ////container.RegisterType<AbstractPad, ApplePad>();//抽象类注册
                ////container.RegisterType<ApplePad, ApplePadChild>();//普通继承类注册
                ////IPhone iphone = container.Resolve<IPhone>();
                ////AbstractPad abstractPad = container.Resolve<AbstractPad>();
                ////ApplePad applePad = container.Resolve<ApplePad>();

                #region 依赖注入
                //全局单例生命周期
                //container.RegisterType<AbstractPad, ApplePad>(new SingletonLifetimeManager());
                #region 线程单例
                /*其中pad1是一个子线程
                 * pad3是pad2的回调，所以处于一个线程中
                */
                container.RegisterType<AbstractPad, ApplePad>(new PerThreadLifetimeManager());
                AbstractPad pad1 = null;
                AbstractPad pad2 = null;
                AbstractPad pad3 = null;
                Action act1 = new Action(() =>
                {
                    pad1 = container.Resolve<AbstractPad>();
                });
                act1.BeginInvoke(null,null);

                Action act2 = new Action(() =>
                {
                    pad2 = container.Resolve<AbstractPad>();
                });
                act2.BeginInvoke(t =>
                {
                    pad3 = container.Resolve<AbstractPad>();
                },null);

                object.ReferenceEquals(pad1, pad2);//false，不同的线程对象
                object.ReferenceEquals(pad2, pad3);//true，线程对象
                
                #endregion

                container.RegisterType<IPhone, ApplePhone>();
                container.RegisterType<IPhone, ApplePhone>();
                container.RegisterType<IHeadPhone, AppleHeadPhone>();
                container.RegisterType<IMicrophone, Mircophone>();
                container.RegisterType<IPower, Power>();
                //默认是瞬时生命周期
                IPhone iphone = container.Resolve<IPhone>();
                IPhone iphone2 = container.Resolve<IPhone>();
                bool compareResult = object.ReferenceEquals(iphone, iphone2);//false，不同的对象
                IPower power = container.Resolve<IPower>();
                iphone.Init(power);
                #endregion
            }
            {
                //IDavidCustomContainer container = new DavidCustomContainer();
                //container.RegisterType<IPhone, AndroidPhone>();
                //container.RegisterType<AbstractPad, ApplePad>();
                //container.RegisterType<IHeadPhone, AppleHeadPhone>();
                //container.RegisterType<IPower, Power>();
                //IPhone phone = container.Resolve<IPhone>();
            }

        }
    }
}
