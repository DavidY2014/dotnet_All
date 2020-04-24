using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.AnlysisFramework.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace Core.AnlysisFramework.Host
{
    /// <summary>
    /// 这个是承载器,Run方法被放到扩展方法中，涉及到socket相关
    /// </summary>
    public class WebHost : IWebHost,IAsyncDisposable
    {
        //IServiceCollection 在  Microsoft.Extensions.DependencyInjection，是系统的一个ioc容器
        private readonly IServiceCollection _applicationServiceCollection;

        private IServiceProvider _applicationServices;
        private readonly IServiceProvider _hostingServiceProvider;
        private IStartup _startup;
        public IServiceProvider Services
        {
            get {
                return _applicationServices;
            }
        }

        /// <summary>
        /// System.IServiceProvider系统注入进来的
        /// </summary>
        /// <param name="hostingServiceProvider"></param>
        public WebHost(IServiceProvider hostingServiceProvider, IServiceCollection appServices)
        {
            _applicationServiceCollection = appServices;
            _hostingServiceProvider = hostingServiceProvider;

            //开始注入类
    //        _applicationServiceCollection.AddSingleton<ApplicationLifetime>();
    //        _applicationServiceCollection.AddSingleton(services
    //=> services.GetService<ApplicationLifetime>() as IHostApplicationLifetime);
        }

        /// <summary>
        /// 此方法被builder的build()调用
        /// </summary>
        public void Initialize()
        {
            try
            {
                EnsureApplicationServices();
            }
            catch (Exception ex)
            {
                // EnsureApplicationServices may have failed due to a missing or throwing Startup class.
                if (_applicationServices == null)
                {
                    //_applicationServices = _applicationServiceCollection.BuildServiceProvider(); //返回serviceprovider
                }

                //if (!_options.CaptureStartupErrors)
                //{
                //    throw;
                //}

                //_applicationServicesException = ExceptionDispatchInfo.Capture(ex);
            }
        }

        //初始化application服务
        private void EnsureApplicationServices()
        {
            if (_applicationServices == null)
            {
                EnsureStartup();
                //_applicationServices = _startup.ConfigureServices(_applicationServiceCollection);
            }
        }

        private void EnsureStartup()
        {
            if (_startup != null)
            {
                return;
            }

            //调用的ServiceProvider的扩展方法
            //属于using System.Runtime.CompilerServices; 中的方法
            //_startup = _hostingServiceProvider.GetService<IStartup>();

            if (_startup == null)
            {
                throw new InvalidOperationException($"No application configured. Please specify startup via IWebHostBuilder.UseStartup, IWebHostBuilder.Configure, injecting {nameof(IStartup)} or specifying the startup assembly via {nameof(WebHostDefaults.StartupAssemblyKey)} in the web host configuration.");
            }
        }


        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
