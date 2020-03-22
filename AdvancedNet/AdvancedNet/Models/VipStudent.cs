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


        /// <summary>
        /// qq长度验证比如10000 - 999999999999  
        /// </summary>
        [DataValiate(10000,999999999)]
        public long QQ { get; set; }

        [MyCustom]
        public void Homework()
        { 
            
        }

    }
}
