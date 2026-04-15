using System;
//класс настроек
namespace SystemMonitor.Models
{
    public class Config
    {
        public int IntervalSec { get; set; }
        public string? OutputTo { get; set; }
        public string? LogFile { get; set; }
    }
}
