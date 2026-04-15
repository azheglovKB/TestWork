using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// стратегия сборщиков
namespace SystemMonitor.Interfaces
{
    public interface IMetricCollection
    {
        string Name { get; } 
        string Collect();
    }
}
