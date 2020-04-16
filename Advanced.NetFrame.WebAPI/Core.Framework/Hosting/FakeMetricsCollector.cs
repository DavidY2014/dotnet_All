using System;
using System.Collections.Generic;
using System.Text;
using Core.Framework.interfaces;

namespace Core.Framework.Hosting
{
    public class FakeMetricsCollector : IProcessorMetricsCollector, INetworkMetricsCollector, IMemoryMetricsCollector
    {
        public long GetThroughput()
        {
            return PerformanceMetrics.Create().Network;
        }

        public int GetUsage()
        {
            return PerformanceMetrics.Create().Processor;
        }

        long IMemoryMetricsCollector.GetUsage()
        {
            return PerformanceMetrics.Create().Memory;
        }
    }
}
