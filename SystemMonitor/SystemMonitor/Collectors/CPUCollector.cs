using System.Diagnostics;

namespace SystemMonitor.Collectors
{
    public class CpuCollector : BaseCollector
    {
        private readonly PerformanceCounter _total;
        private readonly List<PerformanceCounter> _cores;

        public CpuCollector()
        {
            _cores = new List<PerformanceCounter>();

            _total = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            int cpuCount = Environment.ProcessorCount;
            for (int i = 0; i < cpuCount; i++)
            {
                var core = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
                core.NextValue();
                _cores.Add(core);
            }

            _total.NextValue();
        }

        public override string Name => "CPU";

        public override string Collect()
        {
            float totalValue = _total.NextValue();

            string coresValue = "";
            for (int i = 0; i < _cores.Count; i++)
            {
                float val = _cores[i].NextValue();
                coresValue += $"{val:F1}%";
                if (i < _cores.Count - 1)
                    coresValue += " | ";
            }

            return $"Общая: {totalValue:F1}% | Ядра: {coresValue}";
        }
    }
}