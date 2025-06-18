using Model.Dtos.Services;
using Model.Dtos.Staff;
using System.Collections.Generic;

namespace Model.Dtos.StaffServices
{
    public class StaffServicesDto : Model.Entities.StaffServices
    {
        public string StaffName { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDuration { get; set; }
        public List<StaffDto> StaffList { get; set; }
        public List<ServicesDto> ServicesList { get; set; }
    }
}
