using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Framework.Cat
{
    public class CatContainer : IServiceProvider, IDisposable
    {
        internal readonly CatContainer _root;
        internal readonly ConcurrentDictionary<Type, ServiceRegistry> _registries;//这个服务类型和注册链表
        private readonly ConcurrentBag<IDisposable> _disposables;
        private volatile bool _disposed;

        public CatContainer()
        {
            _registries = new ConcurrentDictionary<Type, ServiceRegistry>();
            _root = this;
            //_services = new ConcurrentDictionary<Key, object>();
            _disposables = new ConcurrentBag<IDisposable>();
        }

        internal CatContainer(CatContainer parent) {
            _root = parent._root;
            _registries = _root._registries;
            //_services = new ConcurrentDictionary<Key, object>();
            _disposables = new ConcurrentBag<IDisposable>();
        }

        private void EnsureNotDisposed() {
            if (_disposed) {
                throw new ObjectDisposedException("CatContainer");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据type返回实例对象
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
