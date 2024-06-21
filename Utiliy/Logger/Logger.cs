using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Extensions.Logging;

namespace Utiliy.Logger
{
    public class Logger<T> : ILog<T>
    {
        private readonly ILogger _logger;
        private readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
        public Logger()
        {
            LogManager.Configuration = new NLogLoggingConfiguration(Configuration.GetSection("NLog"));
            _logger = LogManager.GetCurrentClassLogger();
        }
        public void Error(string message)
        {
            _logger.Error(message);
        }
        public void Info(string message)
        {
            _logger.Info(message);
        }
    }
}
