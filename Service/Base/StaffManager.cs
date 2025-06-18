using Core.Helpers.Abstract;
using Core.Utilities.Extensions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Base;
using DataAccess.Abstract.Repositories;
using Model.Dtos.Staff;
using Model.Entities;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Service.Base
{
    public class StaffManager : IStaffService
    {

        private readonly IStaffRepository _service;
        private readonly IFileService _fileService;
        private readonly IAppUserService _appUserService;
        public StaffManager(IStaffRepository service, IFileService fileService, IAppUserService appUserService)
        {
            _service = service;
            _fileService = fileService;
            _appUserService = appUserService;
        }
        public List<StaffDto> GetActiveStaff()
        {
            var result = SetStaff(_service.Where(x => x.IsActive == true).ToList());

            return result;
        }

        public StaffDto GetActiveStaffById(int id)
        {
            var result = SetStaff( _service.Find(x => x.Id == id));

            return result;
        }
        IDataResult<List<StaffDto>> IStaffService.GetAllStaff()
        {
            var result = SetStaff(_service.GetList().OrderByDescending(x => x.Id).ToList());

            return new SuccessDataResult<List<StaffDto>>(result);
        }

        public IDataResult<List<StaffDto>> InsertStaff(StaffDto model)
        {

            StaffDto Staff = new StaffDto();
            Staff.Name = model.Name.ToTitleCase();
            Staff.Surname = model.Surname.ToTitleCase();
            Staff.Email = model.Email.ToLower();
            Staff.Phone = model.Phone;
            Staff.ColorCode = model.ColorCode;

            _service.Insert(Staff);

            var result = SetStaff(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<StaffDto>>(result);
        }
        public IDataResult<List<StaffDto>> DeleteStaff(IdRequest model)
        {
            Staff Staff = _service.Find(x => x.Id == model.Id);

            _service.SoftDelete(Staff);

            var result = SetStaff(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<StaffDto>>(result);
        }
        public IDataResult<List<StaffDto>> UpdateStaff(StaffDto model)
        {
            StaffDto Staff = SetStaff(_service.Find(x => x.Id == model.Id));
            Staff.Name = model.Name.ToTitleCase();
            Staff.Email = model.Email.ToLower();
            Staff.Surname = model.Surname.ToTitleCase();
            Staff.Phone = model.Phone;
            Staff.ColorCode = model.ColorCode;

            _service.Update(Staff);

            var result = SetStaff(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<StaffDto>>(result);
        }

        public IDataResult<List<StaffDto>> UndoDeleteStaff(IdRequest model)
        {
            Staff Staff = _service.Find(x => x.Id == model.Id);

            _service.UndoSoftDelete(Staff);

            var result = SetStaff(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<StaffDto>>(result);
        }

        public IDataResult<StaffDto> GetStaffById(IdRequest model)
        {
            StaffDto response = SetStaff( _service.Find(x => x.Id == model.Id));

            StaffDto result = SetStaff(response);

            return new SuccessDataResult<StaffDto>(result);
        }

        private StaffDto SetStaff(Staff model)
        {
            StaffDto item = new StaffDto();
            item.Id = model.Id;
            item.Email = model.Email;
            item.Name = model.Name;
            item.Surname = model.Surname;
            item.Phone = model.Phone;
            item.ColorCode = model.ColorCode;
            item.IsActive = model.IsActive;
            item.CreateDate = model.CreateDate;
            item.CreateUser = model.CreateUser;
            item.UpdateDate = model.UpdateDate;
            item.UpdateUser = model.UpdateUser;
            return item;

        }
        private List<StaffDto> SetStaff(IEnumerable<Staff> model) => model.Select(x => new StaffDto { Id = x.Id, Email = x.Email, Name = x.Name, Surname = x.Surname, Phone = x.Phone, ColorCode = x.ColorCode, IsActive = x.IsActive, CreateDate = x.CreateDate, CreateUser= x.CreateUser, UpdateDate = x.UpdateDate, UpdateUser = x.UpdateUser }).ToList();
        
    }
}