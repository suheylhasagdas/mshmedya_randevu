namespace Service.Abstract
{
    public interface ILogsService
    {
        void DebugLog(string logMessage);
        void ErrorLog(string logMessage);
    }
}
