using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Context;
using Model.Entities;

namespace DataAccess.Base.Repositories
{
    public class AppUsersRepository : Repository<AppUsers, MshContext>, IAppUsersRepository
    {
        public AppUsersRepository(IAppUserService user) : base(user)
        {

        }
    }
}
