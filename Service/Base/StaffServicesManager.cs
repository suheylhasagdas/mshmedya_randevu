using Core.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Base;
using DataAccess.Abstract.Repositories;
using Model.Dtos.StaffServices;
using Model.Entities;
using Model.Request.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Base
{
    public class StaffServicesManager : IStaffServicesService
    {

        private readonly IStaffServicesRepository _service;
        private readonly IStaffService _staffService;
        private readonly IServicesService _servicesService;
        private readonly IFileService _fileService;
        private readonly IAppUserService _appUserService;
        public StaffServicesManager(IStaffServicesRepository service, IFileService fileService, IAppUserService appUserService, IStaffService staffService, IServicesService servicesService)
        {
            _service = service;
            _staffService = staffService;
            _servicesService = servicesService;
            _fileService = fileService;
            _appUserService = appUserService;
        }
        public List<StaffServicesDto> GetActiveStaffServices()
        {
            var result = SetStaffServices(_service.Where(x => x.IsActive == true));

            return result;
        }

        public StaffServicesDto GetActiveStaffServicesById(int id)
        {
            var result = SetStaffServices(_service.Find(x => x.Id == id));

            return result;
        }
        IDataResult<List<StaffServicesDto>> IStaffServicesService.GetAllStaffServices()
        {
            var result = SetStaffServices(_service.GetList().OrderByDescending(x => x.StaffId).ToList());

            return new SuccessDataResult<List<StaffServicesDto>>(result);
        }

        public IDataResult<List<StaffServicesDto>> InsertStaffServices(StaffServicesDto model)
        {

            StaffServicesDto StaffServices = new StaffServicesDto();
            StaffServices.ServiceId = model.ServiceId;
            StaffServices.StaffId = model.StaffId;
            
            var isInserted =_service.Where(x => x.ServiceId == model.ServiceId && x.StaffId == model.StaffId && x.IsActive).Any();
            if (isInserted)
                throw new Exception("Personele ait bu Hizmet kaydı zaten var!");
            
            _service.Insert(StaffServices);

            var result = SetStaffServices(_service.GetList().OrderByDescending(x => x.StaffId).ToList());

            return new SuccessDataResult<List<StaffServicesDto>>(result);
        }
        public IDataResult<List<StaffServicesDto>> DeleteStaffServices(IdRequest model)
        {
            StaffServices StaffServices = _service.Find(x => x.Id == model.Id);

            _service.SoftDelete(StaffServices);

            var result = SetStaffServices(_service.GetList().OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<StaffServicesDto>>(result);
        }
        public IDataResult<List<StaffServicesDto>> UpdateStaffServices(StaffServicesDto model)
        {
            StaffServicesDto StaffServices = SetStaffServices(_service.Find(x => x.Id == model.Id));
            StaffServices.ServiceId = model.ServiceId;
            StaffServices.StaffId = model.StaffId;

            var isInserted = _service.Where(x => x.ServiceId == model.ServiceId && x.StaffId == model.StaffId && x.Id != model.Id).Any();
            if (isInserted)
                throw new Exception("Personele ait bu Hizmet kaydı zaten var!");

            _service.Update(StaffServices);

            var result = SetStaffServices(_service.GetList().OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<StaffServicesDto>>(result);
        }

        public IDataResult<List<StaffServicesDto>> UndoDeleteStaffServices(IdRequest model)
        {
            StaffServices StaffServices = _service.Find(x => x.Id == model.Id);

            _service.UndoSoftDelete(StaffServices);

            var result = SetStaffServices(_service.GetList().OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<StaffServicesDto>>(result);
        }

        public IDataResult<StaffServicesDto> GetStaffServicesById(IdRequest model)
        {
            StaffServicesDto response = SetStaffServices(_service.Find(x => x.Id == model.Id));

            StaffServicesDto result = SetStaffServices(response);

            return new SuccessDataResult<StaffServicesDto>(result);
        }

        public IDataResult<List<StaffServicesDto>> GetStaffServicesByStaffId(IdRequest model)
        {
            var result = SetStaffServices(_service.GetList(x=>x.StaffId == model.Id).OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<StaffServicesDto>>(result);
        }

        private StaffServicesDto SetStaffServices(StaffServices model)
        {
            var staff = _staffService.GetActiveStaffById(model.StaffId);
            var service = _servicesService.GetActiveServicesById(model.ServiceId);
            StaffServicesDto item = new StaffServicesDto();
            item.Id = model.Id;
            item.ServiceId = model.ServiceId;
            item.StaffId = model.StaffId;
            item.IsActive = model.IsActive;
            item.StaffName = staff.FullName;
            item.ServiceName = service.Name;
            item.ServiceDuration = service.Duration;
            item.CreateDate = model.CreateDate;
            item.CreateUser = model.CreateUser;
            item.UpdateDate = model.UpdateDate;
            item.UpdateUser = model.UpdateUser;
            return item;

        }
        private List<StaffServicesDto> SetStaffServices(IEnumerable<StaffServices> model) => model.Select(x => new StaffServicesDto { Id = x.Id, StaffId = x.StaffId, ServiceId = x.ServiceId, IsActive = x.IsActive, CreateDate = x.CreateDate, CreateUser = x.CreateUser, UpdateDate = x.UpdateDate, UpdateUser = x.UpdateUser, StaffName = _staffService.GetActiveStaffById(x.StaffId).FullName, ServiceName = _servicesService.GetActiveServicesById(x.ServiceId).Name, ServiceDuration = _servicesService.GetActiveServicesById(x.ServiceId).Duration } ).ToList();

    }
}