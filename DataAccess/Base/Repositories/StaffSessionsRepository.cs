using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Context;
using Model.Entities;

namespace DataAccess.Base.Repositories
{
    public class StaffSessionsRepository : Repository<StaffSessions, MshContext>, IStaffSessionsRepository
    {
        public StaffSessionsRepository(IAppUserService user) : base(user)
        {

        }
    }
}
