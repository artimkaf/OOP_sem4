using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork1.Features.Task2;

namespace Study.LabWork1.UnitTests.Features.Task2
{
    [TestFixture]
    public class LoggerFactoryTests
    {
        [Test]
        public void CreateLogger_ConsoleType_ReturnsConsoleLoggerInstance()
        {
            // Act
            ILogger logger = LoggerFactory.CreateLogger(LoggerType.Console);

            // Assert
            Assert.That(logger, Is.Not.Null);
            Assert.That(logger, Is.InstanceOf<ConsoleLogger>());
        }

        [Test]
        public void CreateLogger_FileType_ReturnsFileLoggerInstance()
        {
            // Act
            ILogger logger = LoggerFactory.CreateLogger(LoggerType.File,"test.log");

            // Assert
            Assert.That(logger, Is.InstanceOf<FileLogger>());
        }

        [Test]
        public void CreateLogger_RemoteServerType_ReturnsRemoteServerLoggerInstance()
        {
            // Act
            ILogger logger = LoggerFactory.CreateLogger(LoggerType.Server,"https://test.com/logs");

            // Assert
            Assert.That(logger, Is.InstanceOf<ServerLogger>());
        }

        [Test]
        public void ConsoleLogger_Log_WritesFormattedMessageToConsole()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            ILogger logger = LoggerFactory.CreateLogger(LoggerType.Console);
            string testMessage = "Тестовое сообщение";

            logger.Log(testMessage);

            string output = consoleOutput.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Contain(testMessage));
                Assert.That(output, Does.Contain(DateTime.Now.ToString("yyyy-MM-dd HH:mm"))); // приблизительная проверка даты
            });
        }

        [Test]
        public void FileLogger_Log_WritesMessageToSpecifiedFile()
        {
            string testFile = $"test_log.log"; // временный файл
            try
            {
                ILogger logger = LoggerFactory.CreateLogger(LoggerType.File,testFile);
                string testMessage = "Сообщение в файл";

                logger.Log(testMessage);

                Assert.That(File.Exists(testFile), Is.True);
                string content = File.ReadAllText(testFile);
                Assert.Multiple(() =>
                {
                    Assert.That(content, Does.Contain(testMessage));
                });
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [Test]
        public void RemoteServerLogger_Log_WritesToConsoleWithServerPrefix()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            ILogger logger = LoggerFactory.CreateLogger(LoggerType.Server, url: "https://localhost:8000");
            string testMessage = "Тестовое сообщение";

            logger.Log(testMessage);

            string output = consoleOutput.ToString();
            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Contain("[SERVER]"));
                Assert.That(output, Does.Contain(testMessage));
                Assert.That(output, Does.Contain("https://localhost:8000"));
            });
        }

        [Test]
        public void LoggerFactory_WithInvalidLogType_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                LoggerFactory.CreateLogger((LoggerType)999));
        }

        [Test]
        public void FileLogger_WhenDirectoryNotExists_CreatesFileInCurrentDirectory()
        {
            // Arrange
            string fileName = "temp_log.txt";
            if (File.Exists(fileName)) File.Delete(fileName);

            try
            {
                ILogger logger = LoggerFactory.CreateLogger(LoggerType.File,fileName);

                // Act
                logger.Log("Проверка создания файла");

                // Assert
                Assert.That(File.Exists(fileName), Is.True);
            }
            finally
            {
                if (File.Exists(fileName)) File.Delete(fileName);
            }
        }
    }
}
