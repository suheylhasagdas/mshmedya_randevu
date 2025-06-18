using Core.Helpers.Abstract;
using Core.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Model.Entities;

namespace Core.Helpers.Base
{
    public class AppUserManager : IAppUserService
    {
        private readonly IHttpContextAccessor _context;
        private ISession session => _context.HttpContext.Session;
        public AppUserManager(IHttpContextAccessor context)
        {
            _context = context;
        }

        public AppUsers UserDetail
        {
            get
            {
                string userInfoJson = JsonString("UserDetail");

                if (!string.IsNullOrEmpty(userInfoJson))
                    return userInfoJson.ToConvertFromString<AppUsers>();

                return null;
            }
        }
        public bool IsAuthanticated
        {
            get
            {
                if (UserDetail == null)
                    return false;

                return true;
            }
        }

        public string GetNameFirstLetter
        {
            get
            {
                string nameSurname = $"{UserDetail.Name} {UserDetail.Surname}";

                string[] nameArray = nameSurname.Split(' ');

                string response = string.Empty;

                foreach (var item in nameArray)
                {
                    response += item.Substring(0, 1).ToUpper();
                }

                return response;
            }
        }



        private string JsonString(string key)
        {
            string jsonString = session.GetString(key);

            if (string.IsNullOrEmpty(jsonString))
                return null;

            return jsonString;
        }
    }
}
