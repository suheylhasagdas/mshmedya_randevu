using Model.Entities;

namespace Core.Helpers.Abstract
{
    public interface IAppUserService
    {
        AppUsers UserDetail { get; }
        bool IsAuthanticated { get; }
        string GetNameFirstLetter { get; }
    }
}
