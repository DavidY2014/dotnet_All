using System;
using System.Collections.Generic;
using System.Text;
using Advanced.Framework;

namespace AdvancedNet.Models
{
    [MyCustom(Remark ="VIP",Description ="会员")]
    public class VipStudent: Student
    {
        public string VipGroup { get; set; }

        [MyCustom]
        public void Homework()
        { 
            
        }

    }
}
