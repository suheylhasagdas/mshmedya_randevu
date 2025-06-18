using DataAccess.Abstract.Repositories;
using Model.Entities;
using Service.Abstract;

namespace Service.Base
{
    public class LogsManager : ILogsService
    {
        private readonly ILogsRepository _service;
        public LogsManager(ILogsRepository service)
        {
            _service = service;
        }

        public void DebugLog(string logMessage)
        {
            Logs log = new Logs();
            log.LogMessage = logMessage;
            log.LogLevel = "Debug";
            _service.Insert(log);
        }

        public void ErrorLog(string logMessage)
        {
            Logs log = new Logs();
            log.LogMessage = logMessage;
            log.LogLevel = "Error";
            _service.Insert(log);
        }
    }
}
