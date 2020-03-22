using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.Framework
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataValiateAttribute:AbstractValidateAttribute
    {
        private long _min = 0;
        private long _max = 0;
        public DataValiateAttribute(long min,long max)
        {
            _min = min;
            _max = max;
        }

        public override bool Validate(object oValue)
        {
            return oValue != null
                && long.TryParse(oValue.ToString(), out long lvalue)
                && lvalue >= this._min
                && lvalue <= this._max;
        }

    }
}
