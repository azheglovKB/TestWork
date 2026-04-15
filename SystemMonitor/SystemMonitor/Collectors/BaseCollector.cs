using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.Interfaces;

namespace SystemMonitor.Collectors
{
    public abstract class BaseCollector : IMetricCollection
    {
        public abstract string Name { get; }
        public abstract string Collect();
    }
}
