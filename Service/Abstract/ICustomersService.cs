using Core.Utilities.Results.Abstract;
using Model.Dtos.Customers;
using Model.Request.Common;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface ICustomersService
    {
        List<CustomersDto> GetActiveCustomers();
        CustomersDto GetActiveCustomersById(int id);


        IDataResult<List<CustomersDto>> GetAllCustomers();
        IDataResult<List<CustomersDto>> InsertCustomers(CustomersDto model);
        IDataResult<List<CustomersDto>> UpdateCustomers(CustomersDto model);
        IDataResult<List<CustomersDto>> DeleteCustomers(IdRequest model);
        IDataResult<List<CustomersDto>> UndoDeleteCustomers(IdRequest model);
        IDataResult<CustomersDto> GetCustomersById(IdRequest model);
    }
}
