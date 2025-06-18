using Core.Utilities.Results.Abstract;
using Model.Dtos.StaffSessions;
using Model.Request.Common;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface IStaffSessionsService
    {
        List<StaffSessionsDto> GetActiveStaffSessions();
        StaffSessionsDto GetActiveStaffSessionsById(int id);


        IDataResult<List<StaffSessionsDto>> GetAllStaffSessions();
        IDataResult<List<StaffSessionsDto>> InsertStaffSessions(StaffSessionsDto model);
        IDataResult<List<StaffSessionsDto>> UpdateStaffSessions(StaffSessionsDto model);
        IDataResult<List<StaffSessionsDto>> DeleteStaffSessions(IdRequest model);
        IDataResult<List<StaffSessionsDto>> UndoDeleteStaffSessions(IdRequest model);
        IDataResult<StaffSessionsDto> GetStaffSessionsById(IdRequest model);
        IDataResult<List<StaffSessionsDto>> GetStaffSessionsByStaffId(IdRequest model);
    }
}
