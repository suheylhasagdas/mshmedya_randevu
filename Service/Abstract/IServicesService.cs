using Core.Utilities.Results.Abstract;
using Model.Dtos.Services;
using Model.Request.Common;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface IServicesService
    {
        List<ServicesDto> GetActiveServices();
        ServicesDto GetActiveServicesById(int id);


        IDataResult<List<ServicesDto>> GetAllServices();
        IDataResult<List<ServicesDto>> InsertServices(ServicesDto model);
        IDataResult<List<ServicesDto>> UpdateServices(ServicesDto model);
        IDataResult<List<ServicesDto>> DeleteServices(IdRequest model);
        IDataResult<List<ServicesDto>> UndoDeleteServices(IdRequest model);
        IDataResult<ServicesDto> GetServicesById(IdRequest model);
    }
}
