using SystemMonitor.Collectors;
using SystemMonitor.Models;
using SystemMonitor.Outputs;
using SystemMonitor.Interfaces;

var config = ConfigLoader.Load();

IOutput output;
if (config.OutputTo == "File")
{
    output = new FileOutput(config.LogFile!);
}
else
{
    output = new ConsoleOutput();
}

var collectors = new BaseCollector[]
{
    new CpuCollector(),
    new MemoryCollector(),
    new NetworkCollector()
};


Console.WriteLine("Мониторинг запущен. Нажмите Ctrl+c, чтобы остановить.");
Console.WriteLine($"Интервал: {config.IntervalSec} сек | Записывать в : {config.OutputTo}");
Console.WriteLine(new string('-', 50));

while (true)
{
    foreach (var collector in collectors)
    {
        string data = collector.Collect();
        output.Write($"[{collector.Name}] {data}");
    }

    output.Write(new string('-', 50));
    Thread.Sleep(config.IntervalSec * 1000);
}