using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Framework.Hosting;

namespace Core.Framework.interfaces
{
    public interface IMetricsDeliver
    {
        Task DeliverAsync(PerformanceMetrics counter);
    }
}
