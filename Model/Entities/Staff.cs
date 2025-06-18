using Model.Base.Entities;

namespace Model.Entities
{
    public class Staff : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ColorCode { get; set; }
    }
}
