using System.Net.NetworkInformation;

namespace SystemMonitor.Collectors
{
    public class NetworkCollector : BaseCollector
    {
        private long _prevSent;
        private long _prevReceived;
        private DateTime _prevTime;

        public NetworkCollector()
        {
            _prevSent = 0;
            _prevReceived = 0;
            _prevTime = DateTime.Now;

            var interfaces = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up);

            foreach (var ni in interfaces)
            {
                var stats = ni.GetIPv4Statistics();
                _prevReceived += stats.BytesReceived;
                _prevSent += stats.BytesSent;
            }
        }

        public override string Name => "Network";

        public override string Collect()
        {
            var now = DateTime.Now;
            var interfaces = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up);

            long totalReceived = 0;
            long totalSent = 0;

            foreach (var ni in interfaces)
            {
                var stats = ni.GetIPv4Statistics();
                totalReceived += stats.BytesReceived;
                totalSent += stats.BytesSent;
            }

            double seconds = (now - _prevTime).TotalSeconds;

            long receivedDiff = totalReceived - _prevReceived;
            long sentDiff = totalSent - _prevSent;

            double receivedPerSec = receivedDiff / seconds;
            double sentPerSec = sentDiff / seconds;

            _prevReceived = totalReceived;
            _prevSent = totalSent;
            _prevTime = now;

            return $"Вход: {FormatBytes(receivedPerSec)}/s | Выход: {FormatBytes(sentPerSec)}/s";
        }

        private string FormatBytes(double bytes)
        {
            if (bytes >= 1024 * 1024)
                return $"{bytes / (1024 * 1024):F1} МБ";
            if (bytes >= 1024)
                return $"{bytes / 1024:F1} КБ";
            return $"{bytes:F0} Б";
        }
    }
}