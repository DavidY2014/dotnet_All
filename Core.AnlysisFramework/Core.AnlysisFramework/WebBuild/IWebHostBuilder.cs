using System;
using System.Collections.Generic;
using System.Text;
using Core.AnlysisFramework.Host;
using Microsoft.Extensions.DependencyInjection;

namespace Core.AnlysisFramework
{
    public interface IWebHostBuilder
    {
        IWebHost Build();
        public IWebHostBuilder ConfigureServices(Action<IServiceCollection> configureServices);

    }
}
