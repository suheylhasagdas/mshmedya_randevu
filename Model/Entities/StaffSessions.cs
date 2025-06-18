using Model.Base.Entities;

namespace Model.Entities
{
    public class StaffSessions : EntityBase
    {
        public int SessionId { get; set; }
        public int StaffId { get; set; }
    }
}
