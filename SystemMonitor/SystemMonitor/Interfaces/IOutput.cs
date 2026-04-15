using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Стратегия вывода
namespace SystemMonitor.Interfaces
{
    public interface IOutput
    {
        void Write(string message);
    }
}
