namespace Common.Interfaces.Strategies
{
    public interface ILoggingStrategy
    {
        void LogDebug(string message);
        void LogInfo(string message);
        void LogError(string message);
        void LogFatal(string message);
        void LogWarn(string message);
    }
}
