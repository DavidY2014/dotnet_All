using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Framework.interfaces
{
    public interface IMemoryMetricsCollector
    {
        long GetUsage();
    }
}
