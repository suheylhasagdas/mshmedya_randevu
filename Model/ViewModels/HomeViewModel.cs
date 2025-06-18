using Model.Dtos.Appointments;
using System.Collections.Generic;

namespace Model.ViewModels
{
    public class HomeViewModel
    {
        public List<AppointmentsDto> Appointments { get; set; }
        public int CustomersCount { get; set; }
        public int AppointmentsCount { get; set; }
        public int ServicesCount { get; set; }
        public int StaffCount { get; set; }
    }
}
