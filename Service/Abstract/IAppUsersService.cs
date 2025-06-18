using Core.Utilities.Results.Abstract;
using Model.Request.Login;
using Model.Response.Login;

namespace Service.Abstract
{
    public interface IAppUsersService
    {
        IDataResult<LoginResponse> Login(LoginRequest model);
    }
}
