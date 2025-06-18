using Core.Helpers.Abstract;
using Core.Utilities.Extensions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Base;
using DataAccess.Abstract.Repositories;
using Model.Dtos.Services;
using Model.Entities;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Service.Base
{
    public class ServicesManager : IServicesService
    {

        private readonly IServicesRepository _service;
        private readonly IFileService _fileService;
        private readonly IAppUserService _appUserService;
        public ServicesManager(IServicesRepository service, IFileService fileService, IAppUserService appUserService)
        {
            _service = service;
            _fileService = fileService;
            _appUserService = appUserService;
        }
        public List<ServicesDto> GetActiveServices()
        {
            var result = SetServices(_service.Where(x => x.IsActive == true));

            return result;
        }

        public ServicesDto GetActiveServicesById(int id)
        {
            var result = SetServices(_service.Find(x => x.Id == id));

            return result;
        }
        IDataResult<List<ServicesDto>> IServicesService.GetAllServices()
        {
            var result = SetServices(_service.GetList().OrderByDescending(x => x.Id).ToList());

            return new SuccessDataResult<List<ServicesDto>>(result);
        }

        public IDataResult<List<ServicesDto>> InsertServices(ServicesDto model)
        {

            ServicesDto Services = new ServicesDto();
            Services.Name = model.Name.ToTitleCase();
            Services.Description = model.Description;
            Services.Duration = model.Duration;

            _service.Insert(Services);

            var result = SetServices(_service.GetList().OrderByDescending(x => x.Id).ToList());

            return new SuccessDataResult<List<ServicesDto>>(result);
        }
        public IDataResult<List<ServicesDto>> DeleteServices(IdRequest model)
        {
            Services Services = _service.Find(x => x.Id == model.Id);

            _service.SoftDelete(Services);

            var result = SetServices(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<ServicesDto>>(result);
        }
        public IDataResult<List<ServicesDto>> UpdateServices(ServicesDto model)
        {
            ServicesDto Services = SetServices(_service.Find(x => x.Id == model.Id));
            Services.Name = model.Name.ToTitleCase();
            Services.Description = model.Description;
            Services.Duration = model.Duration;

            _service.Update(Services);

            var result = SetServices(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<ServicesDto>>(result);
        }

        public IDataResult<List<ServicesDto>> UndoDeleteServices(IdRequest model)
        {
            Services Services = _service.Find(x => x.Id == model.Id);

            _service.UndoSoftDelete(Services);

            var result = SetServices(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<ServicesDto>>(result);
        }

        public IDataResult<ServicesDto> GetServicesById(IdRequest model)
        {
            ServicesDto response = SetServices(_service.Find(x => x.Id == model.Id));

            ServicesDto result = SetServices(response);

            return new SuccessDataResult<ServicesDto>(result);
        }

        private ServicesDto SetServices(Services model)
        {
            ServicesDto item = new ServicesDto();
            item.Id = model.Id;
            item.Name = model.Name;
            item.Description = model.Description;
            item.Duration = model.Duration;
            item.IsActive = model.IsActive;
            item.CreateDate = model.CreateDate;
            item.CreateUser = model.CreateUser;
            item.UpdateDate = model.UpdateDate;
            item.UpdateUser = model.UpdateUser;
            return item;

        }
        private List<ServicesDto> SetServices(IEnumerable<Services> model) => model.Select(x => new ServicesDto { Id = x.Id, Name = x.Name, Description = x.Description, Duration = x.Duration, IsActive = x.IsActive, CreateDate = x.CreateDate, CreateUser = x.CreateUser, UpdateDate = x.UpdateDate, UpdateUser = x.UpdateUser }).ToList();

    }
}