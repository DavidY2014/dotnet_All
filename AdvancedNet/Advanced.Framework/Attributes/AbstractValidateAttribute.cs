using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.Framework
{
    public abstract class AbstractValidateAttribute:Attribute
    {
       public  abstract bool Validate(object oValue);
    }
}
