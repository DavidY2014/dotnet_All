using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Framework.Cat
{
    public class ServiceRegistry
    {
        public Type ServiceType { get;}
        public LifeTime Lifetime { get; }
        public Func<CatContainer, Type[], object> Factory { get; } 

        internal ServiceRegistry Next { get; set; }
        public ServiceRegistry(Type serviceType,LifeTime lifetime,
            Func<CatContainer, Type[],object> factory)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
            Factory = factory;
        }

        internal IEnumerable<ServiceRegistry> AsEnumerable()
        {
            var list = new List<ServiceRegistry>();
            for (var self = this; self != null; self = self.Next)
            {
                list.Add(self);
            }
            return list;
        }
    }


}
