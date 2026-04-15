using System.Text.Json;

namespace SystemMonitor.Models
{
    public static class ConfigLoader
    {
        // настройки
        private static readonly string ConfigPath = "config.json";

        // настройки по умолчанию
        private static readonly Config DefaultConfig = new()
        {
            IntervalSec = 2,        
            OutputTo = "Console",   
            LogFile = "monitor.log" 
        };

        public static Config Load()
        {
            // проверка наличия файла с настройками
            if (!File.Exists(ConfigPath))
            {
                var json = JsonSerializer.Serialize(DefaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigPath, json);
                Console.WriteLine($"Создан файл {ConfigPath} с настройками по умолчанию");
                return DefaultConfig;
            }

            // файл есть, попытка прочитать данные
            try
            {
                var json = File.ReadAllText(ConfigPath);

                var config = JsonSerializer.Deserialize<Config>(json);

                return new Config
                {
                    
                    IntervalSec = config?.IntervalSec > 0 ? config.IntervalSec : DefaultConfig.IntervalSec,

                    OutputTo = string.IsNullOrWhiteSpace(config?.OutputTo) ? DefaultConfig.OutputTo : config.OutputTo,

                    LogFile = string.IsNullOrWhiteSpace(config?.LogFile) ? DefaultConfig.LogFile : config.LogFile
                };
            }
            catch
            {
                // при любой ошибке программа может взять дефОЛТНЫЙ файл
                Console.WriteLine($"Ошибка чтения {ConfigPath}. Используются настройки по умолчанию.");
                return DefaultConfig;
            }
        }
    }
}