using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Context;
using Model.Entities;

namespace DataAccess.Base.Repositories
{
    public class AppointmentsRepository : Repository<Appointments, MshContext>, IAppointmentsRepository
    {
        public AppointmentsRepository(IAppUserService user) : base(user)
        {

        }
    }
}
