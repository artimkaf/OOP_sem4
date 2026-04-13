using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public class FileLogger : ILogger
    {
        private readonly string filePath;

        public FileLogger(string Path = "log.txt") => this.filePath = Path;

        public void Log(string message)
        {
            File.AppendAllText(filePath, $"[FILE]   [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] - {message}\n");
        }
    }
}
