using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Context;
using Model.Entities;

namespace DataAccess.Base.Repositories
{
    public class CustomersRepository : Repository<Customers, MshContext>, ICustomersRepository
    {
        public CustomersRepository(IAppUserService user) : base(user)
        {

        }
    }
}
