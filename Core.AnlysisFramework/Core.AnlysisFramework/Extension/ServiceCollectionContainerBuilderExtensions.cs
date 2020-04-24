using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.AnlysisFramework.Extension
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        //public static ServiceProvider BuildServiceProvider(this IServiceCollection services)
        //{
        //    return services.BuildServiceProvider(ServiceProviderOptions.Default);
        //}

        //public static ServiceProvider BuildServiceProvider(this IServiceCollection services, bool validateScopes)
        //{
        //    return services.BuildServiceProvider(new ServiceProviderOptions
        //    {
        //        ValidateScopes = validateScopes
        //    });
        //}
        //public static ServiceProvider BuildServiceProvider(this IServiceCollection services, ServiceProviderOptions options)
        //{
        //    if (services == null)
        //    {
        //        throw new ArgumentNullException("services");
        //    }
        //    if (options == null)
        //    {
        //        throw new ArgumentNullException("options");
        //    }
        //    return new ServiceProvider(services, options);
        //}
    }
}
