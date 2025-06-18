using Model.Dtos.Sessions;
using Model.Dtos.Staff;
using Model.Dtos.StaffSessions;
using System.Collections.Generic;

namespace Model.Dtos.Appointments
{
    public class CalendarDto
    {
        public List<SessionsDto> Sessions { get; set; }
        public List<StaffDto> Staffs { get; set; }
        public List<StaffSessionsDto> StaffSessions { get; set; }
        public List<AppointmentsDto> Appointments { get; set; }
    }
}
