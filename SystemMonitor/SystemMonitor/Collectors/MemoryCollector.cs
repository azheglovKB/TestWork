using System.Diagnostics;
//память
namespace SystemMonitor.Collectors
{
    public class MemoryCollector : BaseCollector
    {
        private readonly PerformanceCounter _total;
        private readonly PerformanceCounter _avail;

        public MemoryCollector()
        {
            _total = new PerformanceCounter("Memory", "Committed Bytes");
            _avail = new PerformanceCounter("Memory", "Available MBytes");
        }

        public override string Name => "Memory";

        public override string Collect()
        {
            float totalBytes = _total.NextValue();
            float totalMb = totalBytes / (1024 * 1024);

            float availMb = _avail.NextValue();
            float usedMb = totalMb - availMb;
            float percent = (usedMb / totalMb) * 100f;

            return $"Всего: {totalMb:F0} МБ | Доступно: {availMb:F0} МБ | Занято: {percent:F1}%";
        }
    }
}