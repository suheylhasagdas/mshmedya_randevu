using Model.Base.Entities;
using System;

namespace Model.Entities
{
    public class Appointments : EntityBase
    {
        public int StaffId { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}