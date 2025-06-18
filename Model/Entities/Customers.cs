using Model.Base.Entities;

namespace Model.Entities
{
    public class Customers : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
