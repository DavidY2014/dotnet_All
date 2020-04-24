using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.AnlysisFramework.Host
{
    public interface IWebHost
    {

        IServiceProvider Services { get; }

        void Start();

        Task StartAsync(CancellationToken cancellationToken = default);

        Task StopAsync(CancellationToken cancellationToken = default);
    }
}
