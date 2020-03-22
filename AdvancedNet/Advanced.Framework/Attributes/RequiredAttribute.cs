using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.Framework
{
    public class RequiredAttribute:AbstractValidateAttribute
    {
        public override bool Validate(object oValue)
        {
            return oValue != null
                && !string.IsNullOrWhiteSpace(oValue.ToString());
        }

    }
}
