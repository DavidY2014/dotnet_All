using System;
using System.Collections.Generic;
using System.Text;
using Core.AnlysisFramework.Host;
using Microsoft.Extensions.DependencyInjection;

namespace Core.AnlysisFramework
{
    public class MyHostBuilder : IWebHostBuilder
    {
        private Action<IServiceCollection> _configureServices;
        private bool _webHostBuilt;

        public IWebHost Build()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 返回一个承载
        /// </summary>
        /// <returns></returns>

        public IWebHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
        {
            _configureServices += configureServices;
            return this;
        }

    }
}
