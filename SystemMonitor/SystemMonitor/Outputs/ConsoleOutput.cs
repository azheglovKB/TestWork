using SystemMonitor.Interfaces;

namespace SystemMonitor.Outputs
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}