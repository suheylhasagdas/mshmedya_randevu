using Model.Response.Login;

namespace Core.Helpers.Abstract
{
    public interface ISessionService
    {
        void CreateSession(LoginResponse model);
        void RemoveSession();
    }
}
