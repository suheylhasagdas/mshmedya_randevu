using Model.Base.Entities;

namespace Model.Entities
{
    public class Sessions : EntityBase
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }

    }
}
