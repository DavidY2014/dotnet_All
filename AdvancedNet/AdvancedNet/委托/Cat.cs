using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet
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
