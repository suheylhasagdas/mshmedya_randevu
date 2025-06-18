using Model.Dtos.StaffSessions;
using System.Collections.Generic;

namespace Model.Dtos.Appointments
{
    public class AvailableSessionsResponseDto
    {
        public List<StaffSessionsDto> AvailableSessions { get; set; }
    }
}
