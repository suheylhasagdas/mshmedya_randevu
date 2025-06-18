using Core.Utilities.Results.Abstract;
using Model.Dtos.Staff;
using Model.Request.Common;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface IStaffService
    {
        List<StaffDto> GetActiveStaff();
        StaffDto GetActiveStaffById(int id);


        IDataResult<List<StaffDto>> GetAllStaff();
        IDataResult<List<StaffDto>> InsertStaff(StaffDto model);
        IDataResult<List<StaffDto>> UpdateStaff(StaffDto model);
        IDataResult<List<StaffDto>> DeleteStaff(IdRequest model);
        IDataResult<List<StaffDto>> UndoDeleteStaff(IdRequest model);
        IDataResult<StaffDto> GetStaffById(IdRequest model);
    }
}
