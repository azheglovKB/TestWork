using SystemMonitor.Interfaces;

namespace SystemMonitor.Outputs
{
    public class FileOutput : IOutput
    {
        private readonly string _path;
        private bool _isNewSession;

        public FileOutput(string path)
        {
            _path = path;
            _isNewSession = true;

            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        public void Write(string message)
        {
            if (_isNewSession)
            {
                File.WriteAllText(_path, message + Environment.NewLine);
                _isNewSession = false;
            }
            else
            {
                File.AppendAllText(_path, message + Environment.NewLine);
            }
        }
    }
}