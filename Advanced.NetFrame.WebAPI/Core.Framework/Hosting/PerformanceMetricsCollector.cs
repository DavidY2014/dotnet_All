using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Framework.Configure;
using Core.Framework.interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Core.Framework.Hosting
{
    /// <summary>
    /// 基于hosting的性能服务,需要实现相关的接口IHostedService
    /// </summary>
    public sealed class PerformanceMetricsCollector : IHostedService
    {
        private readonly IProcessorMetricsCollector _processorMetricsCollector;
        private readonly INetworkMetricsCollector _networkMetricsCollector;
        private readonly IMemoryMetricsCollector _memoryMetricsCollector;
        private readonly IMetricsDeliver _metricsDeliver;
        private readonly TimeSpan _captureInterval;

        public PerformanceMetricsCollector(IProcessorMetricsCollector processorMetricsCollector,
            INetworkMetricsCollector networkMetricsCollector,
            IMemoryMetricsCollector memoryMetricsCollector,
            IMetricsDeliver metricsDeliver,
            IOptions<MetricsCollectionOptions> options)
        {
            _processorMetricsCollector = processorMetricsCollector;
            _networkMetricsCollector = networkMetricsCollector;
            _memoryMetricsCollector = memoryMetricsCollector;
            _metricsDeliver = metricsDeliver;
            _captureInterval = options.Value.CaptureInterval;
        }

        private IDisposable _scheduler;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = new Timer(Callback, null,
                TimeSpan.FromSeconds(1), _captureInterval);
            return Task.CompletedTask;

            #region old
            //不用下面create这种方式来调用信息
            //static void Callback(object state)
            //{
            //    Console.WriteLine($"[{DateTimeOffset.Now}]{PerformanceMetrics.Create()}");
            //}
            #endregion

            async void Callback(object state)
            {
                var counter = new PerformanceMetrics
                {
                    Processor = _processorMetricsCollector.GetUsage(),
                    Memory = _memoryMetricsCollector.GetUsage(),
                    Network = _networkMetricsCollector.GetThroughput()
                };
                await _metricsDeliver.DeliverAsync(counter);
            }


        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _scheduler?.Dispose();
            return Task.CompletedTask;
        }
    }
}
