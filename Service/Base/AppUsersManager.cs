using Core.Helpers.Abstract;
using Core.Utilities.Extensions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Base;
using DataAccess.Abstract.Repositories;
using Model.Request.Login;
using Model.Response.Login;
using Service.Abstract;

namespace Service.Base
{
    public class AppUsersManager : IAppUsersService
    {
        private readonly ISessionService _sessionService;
        private readonly IAppUsersRepository _service;
        private readonly ILogsService _logsService;
        public AppUsersManager(ISessionService sessionService, IAppUsersRepository service, ILogsService logsService)
        {
            _sessionService = sessionService;
            _service = service;
            _logsService = logsService;
        }
        public IDataResult<LoginResponse> Login(LoginRequest model)
        {
            _logsService.DebugLog("Login Request -> " + model.LoginName);
            LoginResponse result = new LoginResponse();

            result.UserDetail = _service.Find(x => x.IsActive == true && x.Username == model.LoginName && x.Password == model.Password);

            if (result.UserDetail == null)
                return new ErrorDataResult<LoginResponse>("Kullanıcı adı veya şifre yanlış", result);

            _logsService.DebugLog("Finded User -> " + result.UserDetail.Username);

            _sessionService.CreateSession(result);

            _logsService.DebugLog("CreateSession Request-> " + result.UserDetail.Serialize());

            return new SuccessDataResult<LoginResponse>(result);
        }
    }
}
