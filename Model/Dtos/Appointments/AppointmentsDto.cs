using Model.Dtos.Customers;
using Model.Dtos.Services;
using Model.Dtos.Sessions;
using Model.Dtos.Staff;
using System.Collections.Generic;

namespace Model.Dtos.Appointments
{
    public class AppointmentsDto : Model.Entities.Appointments
    {
        public StaffDto Staff { get; set; }
        public string ServiceName { get; set; }
        public string CustomerName { get; set; }
        public List<CustomersDto> CustomersList { get; set; }
        public List<StaffDto> StaffList { get; set; }
        public List<ServicesDto> ServicesList { get; set; }
        public List<SessionsDto> SessionsList { get; set; }
        public int SessionId { get; set; }
        public string AppointmentDate { get; set; }
        public string SessinonStartHour { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
