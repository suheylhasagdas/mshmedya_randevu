using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Context;
using Model.Entities;

namespace DataAccess.Base.Repositories
{
    public class StaffServicesRepository : Repository<StaffServices, MshContext>, IStaffServicesRepository
    {
        public StaffServicesRepository(IAppUserService user) : base(user)
        {

        }
    }
}
