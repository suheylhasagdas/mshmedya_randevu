using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Context;
using Model.Entities;

namespace DataAccess.Base.Repositories
{
    public class StaffRepository : Repository<Staff, MshContext>, IStaffRepository
    {
        public StaffRepository(IAppUserService user) : base(user)
        {

        }
    }
}
