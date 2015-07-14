[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Common.Logging.ApacheLog4Net
{
    using System.Reflection;
    using Common.Interfaces.Strategies;
    using log4net;

    public class LoggingStrategy : ILoggingStrategy
    {
        private readonly ILog logger;

        public LoggingStrategy()
        {
            this.logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void LogDebug(string message)
        {
            this.logger.Debug(message);
        }

        public void LogInfo(string message)
        {
            this.logger.Info(message);
        }

        public void LogError(string message)
        {
            this.logger.Error(message);
        }

        public void LogFatal(string message)
        {
            this.logger.Error(message);
        }

        public void LogWarn(string message)
        {
            this.logger.Warn(message);
        }
    }
}
