using Core.Utilities.Results.Abstract;
using Model.Dtos.StaffServices;
using Model.Request.Common;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface IStaffServicesService
    {
        List<StaffServicesDto> GetActiveStaffServices();
        StaffServicesDto GetActiveStaffServicesById(int id);


        IDataResult<List<StaffServicesDto>> GetAllStaffServices();
        IDataResult<List<StaffServicesDto>> InsertStaffServices(StaffServicesDto model);
        IDataResult<List<StaffServicesDto>> UpdateStaffServices(StaffServicesDto model);
        IDataResult<List<StaffServicesDto>> DeleteStaffServices(IdRequest model);
        IDataResult<List<StaffServicesDto>> UndoDeleteStaffServices(IdRequest model);
        IDataResult<StaffServicesDto> GetStaffServicesById(IdRequest model);
        IDataResult<List<StaffServicesDto>> GetStaffServicesByStaffId(IdRequest model);
    }
}
