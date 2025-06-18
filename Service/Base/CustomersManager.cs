using Core.Helpers.Abstract;
using Core.Utilities.Extensions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Base;
using DataAccess.Abstract.Repositories;
using Model.Dtos.Customers;
using Model.Entities;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Service.Base
{
    public class CustomersManager : ICustomersService
    {

        private readonly ICustomersRepository _service;
        private readonly IFileService _fileService;
        private readonly IAppUserService _appUserService;
        public CustomersManager(ICustomersRepository service, IFileService fileService, IAppUserService appUserService)
        {
            _service = service;
            _fileService = fileService;
            _appUserService = appUserService;
        }
        public List<CustomersDto> GetActiveCustomers()
        {
            var result = SetCustomers(_service.Where(x => x.IsActive == true).OrderBy(x => x.Name));

            return result;
        }

        public CustomersDto GetActiveCustomersById(int id)
        {
            var result = SetCustomers(_service.Find(x => x.Id == id));

            return result;
        }
        IDataResult<List<CustomersDto>> ICustomersService.GetAllCustomers()
        {
            var result = SetCustomers(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<CustomersDto>>(result);
        }

        public IDataResult<List<CustomersDto>> InsertCustomers(CustomersDto model)
        {

            Customers Customers = new Customers();
            Customers.Name = model.Name.ToTitleCase();
            Customers.Surname = model.Surname.ToTitleCase();
            Customers.Email = model.Email.ToLower();
            Customers.Phone = model.Phone;
            Customers.Country = model.Country;
            Customers.City = model.City;
            Customers.Address = model.Address;
            Customers.Gender = model.Gender;

            _service.Insert(Customers);

            var result = SetCustomers(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<CustomersDto>>(result);
        }
        public IDataResult<List<CustomersDto>> DeleteCustomers(IdRequest model)
        {
            Customers Customers = _service.Find(x => x.Id == model.Id);

            _service.SoftDelete(Customers);

            var result = SetCustomers(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<CustomersDto>>(result);
        }
        public IDataResult<List<CustomersDto>> UpdateCustomers(CustomersDto model)
        {
            Customers Customers = _service.Find(x => x.Id == model.Id);
            Customers.Name = model.Name.ToTitleCase();
            Customers.Email = model.Email.ToLower();
            Customers.Surname = model.Surname.ToTitleCase();
            Customers.Phone = model.Phone;
            Customers.Country = model.Country;
            Customers.City = model.City;
            Customers.Address = model.Address;
            Customers.Gender = model.Gender;

            _service.Update(Customers);

            var result = SetCustomers(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<CustomersDto>>(result);
        }

        public IDataResult<List<CustomersDto>> UndoDeleteCustomers(IdRequest model)
        {
            Customers Customers = _service.Find(x => x.Id == model.Id);

            _service.UndoSoftDelete(Customers);

            var result = SetCustomers(_service.GetList().OrderByDescending(x => x.Id));

            return new SuccessDataResult<List<CustomersDto>>(result);
        }

        public IDataResult<CustomersDto> GetCustomersById(IdRequest model)
        {
            Customers response = _service.Find(x => x.Id == model.Id);

            CustomersDto result = SetCustomers(response);

            return new SuccessDataResult<CustomersDto>(result);
        }

        private CustomersDto SetCustomers(Customers model)
        {
            CustomersDto item = new CustomersDto();
            item.Id = model.Id;
            item.Email = model.Email;
            item.Name = model.Name;
            item.Surname = model.Surname;
            item.Phone = model.Phone;
            item.Country = model.Country;
            item.City = model.City;
            item.Address = model.Address;
            item.Gender = model.Gender;
            item.IsActive = model.IsActive;
            item.CreateDate = model.CreateDate;
            item.CreateUser = model.CreateUser;
            item.UpdateDate = model.UpdateDate;
            item.UpdateUser = model.UpdateUser;
            return item;

        }
        private List<CustomersDto> SetCustomers(IEnumerable<Customers> model) => model.Select(x => new CustomersDto { Id = x.Id, Email = x.Email, Name = x.Name, Surname = x.Surname, Address = x.Address, City = x.City, Country = x.Country, Gender = x.Gender, Phone = x.Phone, IsActive = x.IsActive, CreateDate = x.CreateDate, CreateUser = x.CreateUser, UpdateDate = x.UpdateDate, UpdateUser = x.UpdateUser }).ToList();

    }
}