namespace Model.Dtos.Staff
{
    public class StaffDto : Model.Entities.Staff
    {
        public string FullName { get { return $"{Name} {Surname}"; }}
    }
}
