using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Context;
using Model.Entities;

namespace DataAccess.Base.Repositories
{
    public class ServicesRepository : Repository<Services, MshContext>, IServicesRepository
    {
        public ServicesRepository(IAppUserService user) : base(user)
        {

        }
    }
}
