using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet.Unity
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public sealed class DavidInjectionConstructorAttribute:Attribute
    {
        public DavidInjectionConstructorAttribute()
        {

        }
    }
}
