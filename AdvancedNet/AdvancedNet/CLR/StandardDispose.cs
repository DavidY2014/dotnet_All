using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet
{
    /// <summary>
    /// 标准dispose模式
    /// 析构函数：被动清理
    /// Dispose：主动清理
    /// </summary>
    public class StandardDispose:IDisposable
    {
        private string _UnmanageResource = "未托管的资源";
        private string _ManageResource = "托管资源";

        private bool _disposed = false;
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);//通知垃圾回收机制不再调用终结器
        }

        public void Close()
        {
            this.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }
            if (disposing)
            {
                //清理托管资源
                if (this._ManageResource !=null)
                {
                    this._ManageResource = null;
                }
            }
            //清理非托管资源
            if (this._UnmanageResource!=null)
            {
                this._UnmanageResource = null;
            }
            this._disposed = true;
        }


    }
}
