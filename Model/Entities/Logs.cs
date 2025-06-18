using Model.Base.Entities;

namespace Model.Entities
{
    public class Logs : EntityBase
    {
        public string LogLevel { get; set; }
        public string LogMessage { get; set; }
    }
}
