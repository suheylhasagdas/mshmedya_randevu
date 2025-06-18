using Core.Helpers.Abstract;
using Core.Utilities.Extensions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Base;
using DataAccess.Abstract.Repositories;
using Model.Dtos.Sessions;
using Model.Entities;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Service.Base
{
    public class SessionsManager : ISessionsService
    {

        private readonly ISessionsRepository _service;
        private readonly IFileService _fileService;
        private readonly IAppUserService _appUserService;
        public SessionsManager(ISessionsRepository service, IFileService fileService, IAppUserService appUserService)
        {
            _service = service;
            _fileService = fileService;
            _appUserService = appUserService;
        }
        public List<SessionsDto> GetActiveSessions()
        {
            var result = SetSessions(_service.Where(x => x.IsActive == true).OrderBy(x=>x.StartTime));

            return result;
        }

        public SessionsDto GetActiveSessionsById(int id)
        {
            var result = SetSessions(_service.Find(x => x.Id == id));

            return result;
        }
        IDataResult<List<SessionsDto>> ISessionsService.GetAllSessions()
        {
            var result = SetSessions(_service.GetList().OrderBy(x => x.StartTime).ToList());

            return new SuccessDataResult<List<SessionsDto>>(result);
        }

        public IDataResult<List<SessionsDto>> InsertSessions(SessionsDto model)
        {

            SessionsDto Sessions = new SessionsDto();
            Sessions.StartTime = model.StartTime;
            Sessions.EndTime = model.EndTime;
            Sessions.Description = model.Description;

            _service.Insert(Sessions);

            var result = SetSessions(_service.GetList().OrderBy(x => x.StartTime).ToList());

            return new SuccessDataResult<List<SessionsDto>>(result);
        }
        public IDataResult<List<SessionsDto>> DeleteSessions(IdRequest model)
        {
            Sessions Sessions = _service.Find(x => x.Id == model.Id);

            _service.SoftDelete(Sessions);

            var result = SetSessions(_service.GetList().OrderBy(x => x.StartTime));

            return new SuccessDataResult<List<SessionsDto>>(result);
        }
        public IDataResult<List<SessionsDto>> UpdateSessions(SessionsDto model)
        {
            SessionsDto Sessions = SetSessions(_service.Find(x => x.Id == model.Id));
            Sessions.StartTime = model.StartTime;
            Sessions.EndTime = model.EndTime;
            Sessions.Description = model.Description;

            _service.Update(Sessions);

            var result = SetSessions(_service.GetList().OrderBy(x => x.StartTime));

            return new SuccessDataResult<List<SessionsDto>>(result);
        }

        public IDataResult<List<SessionsDto>> UndoDeleteSessions(IdRequest model)
        {
            Sessions Sessions = _service.Find(x => x.Id == model.Id);

            _service.UndoSoftDelete(Sessions);

            var result = SetSessions(_service.GetList().OrderBy(x => x.StartTime));

            return new SuccessDataResult<List<SessionsDto>>(result);
        }

        public IDataResult<SessionsDto> GetSessionsById(IdRequest model)
        {
            SessionsDto result = SetSessions(_service.Find(x => x.Id == model.Id));

            return new SuccessDataResult<SessionsDto>(result);
        }
        public IDataResult<SessionsDto> GetSessionsByStartEndTime(SessionsStartEndTimeRequestDto model)
        {
            SessionsDto result = SetSessions(_service.Find(x => x.StartTime == model.StartTime && x.EndTime == model.EndTime));

            return new SuccessDataResult<SessionsDto>(result);
        }

        private SessionsDto SetSessions(Sessions model)
        {
            SessionsDto item = new SessionsDto();
            item.Id = model.Id;
            item.StartTime = model.StartTime;
            item.EndTime = model.EndTime;
            item.Description = model.Description;
            item.IsActive = model.IsActive;
            item.CreateDate = model.CreateDate;
            item.CreateUser = model.CreateUser;
            item.UpdateDate = model.UpdateDate;
            item.UpdateUser = model.UpdateUser;
            return item;

        }
        private List<SessionsDto> SetSessions(IEnumerable<Sessions> model) => model.Select(x => new SessionsDto { Id = x.Id, StartTime = x.StartTime, Description = x.Description, EndTime = x.EndTime, IsActive = x.IsActive, CreateDate = x.CreateDate, CreateUser = x.CreateUser, UpdateDate = x.UpdateDate, UpdateUser = x.UpdateUser }).ToList();

    }
}