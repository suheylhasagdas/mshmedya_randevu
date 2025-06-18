namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        bool success { get; }
        string responseText { get; }
    }
}
