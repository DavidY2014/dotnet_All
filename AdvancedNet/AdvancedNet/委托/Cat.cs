using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet.委托
{
    public class Cat
    {
        public Cat()
        {

        }

        public Action miaoHandler;
        public void Miao()
        {
            miaoHandler?.Invoke();
        }
    }
}
