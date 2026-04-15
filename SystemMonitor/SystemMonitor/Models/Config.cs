using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.Models
{
    public class Config
    {
        public int IntervalSec { get; set; }
        public string? OutputTo { get; set; }
        public string? LogFile { get; set; }
    }
}
