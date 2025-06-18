using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Context;
using Model.Entities;

namespace DataAccess.Base.Repositories
{
    public class SessionsRepository : Repository<Sessions, MshContext>, ISessionsRepository
    {
        public SessionsRepository(IAppUserService user) : base(user)
        {

        }
    }
}
