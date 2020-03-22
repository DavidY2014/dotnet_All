using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet.委托
{
    public class EventStandard
    {

    }

    public class XEventArgs : EventArgs
    {
        public int OldPrice { get; set; }
        public int NewPrice { get; set; }

    }

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
