using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet
{
    public class EventStandard
    {
        /// <summary>
        /// 关联
        /// </summary>
        public static void Init()
        {
            var buyer = new Buyer();
            IphoneX phone = new IphoneX()
            {
                Price = 10000
            };
            phone.DiscountHandler += buyer.Buy;

            //改了属性的价格，降价了，此时会触发事件的执行
            phone.Price = 2000;
        }
    }


    /// <summary>
    /// 关注者，订阅者
    /// </summary>
    public class Buyer
    {
        //参数需要和eventhandler参数一致
        public void Buy(object? sender, EventArgs e)
        {
            IphoneX phone = (IphoneX)sender;
        }
    }

    public class XEventArgs : EventArgs
    {
        public int OldPrice { get; set; }
        public int NewPrice { get; set; }

    }


    /// <summary>
    /// 发布者,在条件达到的情况下触发事件行为
    /// </summary>
    public class IphoneX
    { 
        public int Id { get; set; }

        public string Name { get; set; }
        public int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                //事件的触发是控制在类内部的，但是具体做什么事情是由类的外部实现
                if (value < this._price)
                {
                    this.DiscountHandler?.Invoke(this, new XEventArgs()
                    {
                        OldPrice = this._price,
                        NewPrice = value
                    }) ;
                }

            }
        }

        public event EventHandler DiscountHandler;

    }
}
