using System;

namespace Model.Dtos.Appointments
{
    public class AvailableSessionsRequestDto
    {
        public int StaffId { get; set; }
        public string AppointmentDate { get; set; }
    }
}
