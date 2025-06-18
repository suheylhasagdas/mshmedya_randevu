using Core.Helpers.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Context;
using Model.Entities;

namespace DataAccess.Base.Repositories
{
    public class LogsRepository : Repository<Logs, MshContext>, ILogsRepository
    {
        public LogsRepository(IAppUserService user) : base(user)
        {

        }
    }
}
