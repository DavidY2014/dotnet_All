using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet.Models
{
    public interface IPhone
    {
        void Get();
        void Update();

        void Init(IPower power);
    }
}
