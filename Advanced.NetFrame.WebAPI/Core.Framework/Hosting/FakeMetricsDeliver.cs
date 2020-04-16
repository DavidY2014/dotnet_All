using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Framework.Configure;
using Core.Framework.interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Core.Framework.Hosting
{
    public class FakeMetricsDeliver : IMetricsDeliver
    {
        private readonly TransportType _transport;
        private readonly Endpoint _deliverTo;

        private readonly ILogger _logger;
        private readonly Action<ILogger, DateTimeOffset,
            PerformanceMetrics, Endpoint, TransportType, Exception> _logForDelivery;

        public FakeMetricsDeliver(IOptions<MetricsCollectionOptions> optionsAccessor,
            ILogger<FakeMetricsDeliver> logger)
        {
            var options = optionsAccessor.Value;
            _transport = options.Transport;
            _deliverTo = options.DeliveryTo;
            _logger = logger;
            _logForDelivery = LoggerMessage.Define<DateTimeOffset, PerformanceMetrics, Endpoint,
                TransportType>(LogLevel.Information, 0, "[{0}]Deliver performance counter {1} to {2} via {3}");
        }

        //通过options来传递配置
        public Task DeliverAsync(PerformanceMetrics counter)
        {
            //Console.WriteLine($"[{DateTimeOffset.UtcNow}]{counter}");

            _logForDelivery(_logger, DateTimeOffset.Now, counter, _deliverTo, _transport, null);

            Console.WriteLine($"[{DateTimeOffset.Now}]Deliver performance counmter {counter}" +
                $"to {_deliverTo} via {_transport}");

            return Task.CompletedTask;
        }
    }
}
