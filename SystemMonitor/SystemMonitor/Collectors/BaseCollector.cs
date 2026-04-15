using SystemMonitor.Interfaces;
//базовый коллектор
namespace SystemMonitor.Collectors
{
    public abstract class BaseCollector : IMetricCollection
    {
        public abstract string Name { get; }
        public abstract string Collect();
    }
}
