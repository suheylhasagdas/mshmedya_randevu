using Core.Helpers.Abstract;
using Core.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Model.Response.Login;

namespace Core.Helpers.Base
{
    public class SessionManager : ISessionService
    {
        private readonly IHttpContextAccessor context;
        private ISession session => context.HttpContext.Session;


        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            this.context = httpContextAccessor;
        }

        public void CreateSession(LoginResponse model)
        {
            string userJson = model.UserDetail.Serialize();
            session.SetString("UserDetail", userJson);
        }

        public void RemoveSession()
        {
            session.Remove("UserDetail");
        }


    }
}
