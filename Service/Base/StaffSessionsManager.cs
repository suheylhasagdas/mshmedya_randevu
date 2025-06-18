using Core.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Base;
using DataAccess.Abstract.Repositories;
using Model.Dtos.StaffSessions;
using Model.Entities;
using Model.Request.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Base
{
    public class StaffSessionsManager : IStaffSessionsService
    {

        private readonly IStaffSessionsRepository _service;
        private readonly IStaffService _staffService;
        private readonly ISessionsService _sessionsService;
        private readonly IFileService _fileService;
        private readonly IAppUserService _appUserService;
        public StaffSessionsManager(IStaffSessionsRepository service, IFileService fileService, IAppUserService appUserService, IStaffService staffService, ISessionsService sessionsService)
        {
            _service = service;
            _staffService = staffService;
            _sessionsService = sessionsService;
            _fileService = fileService;
            _appUserService = appUserService;
        }
        public List<StaffSessionsDto> GetActiveStaffSessions()
        {
            var result = SetStaffSessions(_service.Where(x => x.IsActive == true));

            return result;
        }

        public StaffSessionsDto GetActiveStaffSessionsById(int id)
        {
            var result = SetStaffSessions(_service.Find(x => x.Id == id));

            return result;
        }
        IDataResult<List<StaffSessionsDto>> IStaffSessionsService.GetAllStaffSessions()
        {
            var result = SetStaffSessions(_service.GetList().OrderByDescending(x => x.StaffId).ToList());

            return new SuccessDataResult<List<StaffSessionsDto>>(result);
        }

        public IDataResult<List<StaffSessionsDto>> InsertStaffSessions(StaffSessionsDto model)
        {

            StaffSessionsDto StaffSessions = new StaffSessionsDto();
            StaffSessions.SessionId = model.SessionId;
            StaffSessions.StaffId = model.StaffId;
            
            var isInserted =_service.Where(x => x.SessionId == model.SessionId && x.StaffId == model.StaffId && x.IsActive).Any();
            if (isInserted)
                throw new Exception("Personele ait bu Seans kaydı zaten var!");
            
            _service.Insert(StaffSessions);

            var result = SetStaffSessions(_service.GetList().OrderByDescending(x => x.StaffId).ToList());

            return new SuccessDataResult<List<StaffSessionsDto>>(result);
        }
        public IDataResult<List<StaffSessionsDto>> DeleteStaffSessions(IdRequest model)
        {
            StaffSessions StaffSessions = _service.Find(x => x.Id == model.Id);

            _service.SoftDelete(StaffSessions);

            var result = SetStaffSessions(_service.GetList().OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<StaffSessionsDto>>(result);
        }
        public IDataResult<List<StaffSessionsDto>> UpdateStaffSessions(StaffSessionsDto model)
        {
            StaffSessionsDto StaffSessions = SetStaffSessions(_service.Find(x => x.Id == model.Id));
            StaffSessions.SessionId = model.SessionId;
            StaffSessions.StaffId = model.StaffId;

            var isInserted = _service.Where(x => x.SessionId == model.SessionId && x.StaffId == model.StaffId && x.Id != model.Id).Any();
            if (isInserted)
                throw new Exception("Personele ait bu Seans kaydı zaten var!");

            _service.Update(StaffSessions);

            var result = SetStaffSessions(_service.GetList().OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<StaffSessionsDto>>(result);
        }

        public IDataResult<List<StaffSessionsDto>> UndoDeleteStaffSessions(IdRequest model)
        {
            StaffSessions StaffSessions = _service.Find(x => x.Id == model.Id);

            _service.UndoSoftDelete(StaffSessions);

            var result = SetStaffSessions(_service.GetList().OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<StaffSessionsDto>>(result);
        }

        public IDataResult<StaffSessionsDto> GetStaffSessionsById(IdRequest model)
        {
            StaffSessionsDto response = SetStaffSessions(_service.Find(x => x.Id == model.Id));

            StaffSessionsDto result = SetStaffSessions(response);

            return new SuccessDataResult<StaffSessionsDto>(result);
        }
        public IDataResult<List<StaffSessionsDto>> GetStaffSessionsByStaffId(IdRequest model)
        {

            var result = SetStaffSessions(_service.GetList(x=>x.StaffId == model.Id).ToList());

            return new SuccessDataResult<List<StaffSessionsDto>>(result);
        }

        private StaffSessionsDto SetStaffSessions(StaffSessions model)
        {
            var staff = _staffService.GetActiveStaffById(model.StaffId);
            var sessions = _sessionsService.GetActiveSessionsById(model.SessionId);
            StaffSessionsDto item = new StaffSessionsDto();
            item.Id = model.Id;
            item.SessionId = model.SessionId;
            item.StaffId = model.StaffId;
            item.IsActive = model.IsActive;
            item.StaffName = $"{staff.Name} {staff.Surname }";
            item.Sessions = sessions;
            item.CreateDate = model.CreateDate;
            item.CreateUser = model.CreateUser;
            item.UpdateDate = model.UpdateDate;
            item.UpdateUser = model.UpdateUser;
            return item;

        }
        private List<StaffSessionsDto> SetStaffSessions(IEnumerable<StaffSessions> model) => model.Select(x => new StaffSessionsDto { Id = x.Id, StaffId = x.StaffId, SessionId = x.SessionId, IsActive = x.IsActive, CreateDate = x.CreateDate, CreateUser = x.CreateUser, UpdateDate = x.UpdateDate, UpdateUser = x.UpdateUser, StaffName = _staffService.GetActiveStaffById(x.StaffId).FullName, Sessions = _sessionsService.GetActiveSessionsById(x.SessionId) }).ToList();

    }
}