using Core.Utilities.Results.Abstract;
using Model.Dtos.Sessions;
using Model.Request.Common;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface ISessionsService
    {
        List<SessionsDto> GetActiveSessions();
        SessionsDto GetActiveSessionsById(int id);


        IDataResult<List<SessionsDto>> GetAllSessions();
        IDataResult<List<SessionsDto>> InsertSessions(SessionsDto model);
        IDataResult<List<SessionsDto>> UpdateSessions(SessionsDto model);
        IDataResult<List<SessionsDto>> DeleteSessions(IdRequest model);
        IDataResult<List<SessionsDto>> UndoDeleteSessions(IdRequest model);
        IDataResult<SessionsDto> GetSessionsById(IdRequest model);
        IDataResult<SessionsDto> GetSessionsByStartEndTime(SessionsStartEndTimeRequestDto model);
    }
}
