using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public class ServerLogger : ILogger
    {
        private readonly string serverUrl;

        public ServerLogger(string Url) => this.serverUrl = Url;

        public void Log(string message)
        {
            // Эмуляция отправки лога на удалённый сервер.
            // В реальном проекте здесь был бы HttpClient.
            Console.WriteLine($"[SERVER] [{serverUrl}] - {message}");
        }
    }
}
