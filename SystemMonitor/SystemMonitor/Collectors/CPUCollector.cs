using System.Diagnostics;

namespace SystemMonitor.Collectors
{
    public class CpuCollector : BaseCollector
    {
        private readonly PerformanceCounter _counter;

        public CpuCollector()
        {
            _counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _counter.NextValue(); // первый вызов — 0, греем счётчик
        }

        public override string Name => "CPU";

        public override string Collect()
        {
            float value = _counter.NextValue();
            return $"Загрузка: {value:F1}%";
        }
    }
}