using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AnlysisFramework.Extension
{
    public static class ServiceProviderServiceExtensions
    {
        public static T GetService<T>(this IServiceProvider provider)
        {
            //IL_0008: Unknown result type (might be due to invalid IL or missing references)
            //IL_0019: Unknown result type (might be due to invalid IL or missing references)
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            return (T)provider.GetService(typeof(T));//调用原生的方法
        }
    }
}
