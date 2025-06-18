using Model.Dtos.Sessions;
using Model.Dtos.Staff;
using System.Collections.Generic;

namespace Model.Dtos.StaffSessions
{
    public class StaffSessionsDto : Model.Entities.StaffSessions
    {
        public string StaffName { get; set; }
        public SessionsDto Sessions { get; set; }
        public List<StaffDto> StaffList { get; set; }
        public List<SessionsDto> SessionsList { get; set; }
        public bool IsAvailable { get; set; }
        public int CustomerId { get; set; }
    }
}
