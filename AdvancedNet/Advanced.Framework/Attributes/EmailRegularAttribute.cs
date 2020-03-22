using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.Framework.Attributes
{
    public class EmailRegularAttribute: AbstractValidateAttribute
    {
        private static string EmailRegular = @"^\w+([-+.]\w+)*@\w
                        +([-.]\w+)*\.\w+([-.]\w+)*$";



        public  override bool Validate(object oValue)
        {
            throw new NotImplementedException();
        }
    }
}
