namespace Model.Dtos.Customers
{
    public class CustomersDto : Model.Entities.Customers
    {
        public string FullName { get { return $"{Name} {Surname}"; } }
        public string FullNamePhone { get { return $"{Name} {Surname} {Phone}"; } }
    }
}
