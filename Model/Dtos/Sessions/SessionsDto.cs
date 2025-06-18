namespace Model.Dtos.Sessions
{
    public class SessionsDto : Model.Entities.Sessions
    {
        public string StartEndTime { get { return $"{StartTime} - {EndTime}"; } }
    }
}
