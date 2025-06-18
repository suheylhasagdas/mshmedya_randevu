using Model.Base.Entities;

namespace Model.Entities
{
    public class Services : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
    }
}
