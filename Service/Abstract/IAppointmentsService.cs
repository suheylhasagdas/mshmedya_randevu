using Core.Utilities.Results.Abstract;
using Model.Dtos.Appointments;
using Model.Request.Common;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface IAppointmentsService
    {
        List<AppointmentsDto> GetActiveAppointments();
        List<AppointmentsDto> GetActiveFutureAppointments();
        List<AppointmentsDto> GetActiveAppointmentsByDate(CalendarRequestDto model);
        AppointmentsDto GetActiveAppointmentsById(int id);


        IDataResult<List<AppointmentsDto>> GetAllAppointments();
        IDataResult<List<AppointmentsDto>> InsertAppointments(AppointmentsDto model);
        IDataResult<List<AppointmentsDto>> UpdateAppointments(AppointmentsDto model);
        IDataResult<List<AppointmentsDto>> DeleteAppointments(IdRequest model);
        IDataResult<List<AppointmentsDto>> UndoDeleteAppointments(IdRequest model);
        IDataResult<AppointmentsDto> GetAppointmentsById(IdRequest model);
        IDataResult<AvailableSessionsResponseDto> GetStaffAvailableSessions(AvailableSessionsRequestDto model, int? appointmentId = null);
    }
}
