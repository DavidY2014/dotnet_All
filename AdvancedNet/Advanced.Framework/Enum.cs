using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.Framework
{
    public enum StudentState
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Remark("正常")]
        Normal,

        /// <summary>
        /// 冻结
        /// </summary>
        [Remark("冻结")]
        Frozen,

        /// <summary>
        /// 删除
        /// </summary>
        [Remark("删除")]
        Delete

    }
}
