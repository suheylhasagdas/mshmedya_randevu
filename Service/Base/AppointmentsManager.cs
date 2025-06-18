using Core.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Base;
using DataAccess.Abstract.Repositories;
using Model.Dtos.Appointments;
using Model.Dtos.Sessions;
using Model.Dtos.StaffSessions;
using Model.Entities;
using Model.Request.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Base
{
    public class AppointmentsManager : IAppointmentsService
    {

        private readonly IAppointmentsRepository _service;
        private readonly IStaffService _staffService;
        private readonly IStaffSessionsService _staffSessionsService;
        private readonly ISessionsService _sessionsService;
        private readonly ICustomersService _customersService;
        private readonly IServicesService _servicesService;
        private readonly IFileService _fileService;
        private readonly IAppUserService _appUserService;
        public AppointmentsManager(IAppointmentsRepository service, IFileService fileService, IAppUserService appUserService, IStaffService staffService, IServicesService servicesService, IStaffSessionsService staffSessionsService, ISessionsService sessionsService, ICustomersService customersService)
        {
            _service = service;
            _staffService = staffService;
            _staffSessionsService = staffSessionsService;
            _servicesService = servicesService;
            _customersService = customersService;
            _fileService = fileService;
            _appUserService = appUserService;
            _sessionsService = sessionsService;
        }
        public List<AppointmentsDto> GetActiveAppointments()
        {
            var result = SetAppointments(_service.Where(x => x.IsActive == true));

            return result;
        }
        public List<AppointmentsDto> GetActiveFutureAppointments()
        {
            var result = SetAppointments(_service.Where(x => x.IsActive == true && x.StartDateTime >= DateTime.Now));

            return result;
        }
        public List<AppointmentsDto> GetActiveAppointmentsByDate(CalendarRequestDto model)
        {
            var result = SetAppointments(_service.Where(x => x.IsActive == true && x.StartDateTime.Date == model.CurrentDate.Date));

            return result;
        }

        public AppointmentsDto GetActiveAppointmentsById(int id)
        {
            var result = SetAppointments(_service.Find(x => x.Id == id));

            return result;
        }
        IDataResult<List<AppointmentsDto>> IAppointmentsService.GetAllAppointments()
        {
            var result = SetAppointments(_service.GetList().OrderByDescending(x => x.StaffId).ToList());

            return new SuccessDataResult<List<AppointmentsDto>>(result);
        }

        public IDataResult<List<AppointmentsDto>> InsertAppointments(AppointmentsDto model)
        {
            model = CheckAppointment(model);

            AppointmentsDto Appointments = new AppointmentsDto();
            Appointments.ServiceId = model.ServiceId;
            Appointments.StaffId = model.StaffId;
            Appointments.StartDateTime = model.StartDateTime;
            Appointments.EndDateTime = model.EndDateTime;
            Appointments.CustomerId = model.CustomerId;
            
            _service.Insert(Appointments);

            var result = SetAppointments(_service.GetList().OrderByDescending(x => x.StaffId).ToList());

            return new SuccessDataResult<List<AppointmentsDto>>(result);
        }
        public IDataResult<List<AppointmentsDto>> DeleteAppointments(IdRequest model)
        {
            Appointments Appointments = _service.Find(x => x.Id == model.Id);

            _service.SoftDelete(Appointments);

            var result = SetAppointments(_service.GetList().OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<AppointmentsDto>>(result);
        }
        public IDataResult<List<AppointmentsDto>> UpdateAppointments(AppointmentsDto model)
        {
            model = CheckAppointment(model);

            AppointmentsDto Appointments = SetAppointments(_service.Find(x => x.Id == model.Id));
            Appointments.ServiceId = model.ServiceId;
            Appointments.StaffId = model.StaffId;
            Appointments.StartDateTime = model.StartDateTime;
            Appointments.EndDateTime = model.EndDateTime;
            Appointments.CustomerId = model.CustomerId;

            _service.Update(Appointments);

            var result = SetAppointments(_service.GetList().OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<AppointmentsDto>>(result);
        }

        private AppointmentsDto CheckAppointment(AppointmentsDto model)
        {
            var session = _sessionsService.GetSessionsById(new IdRequest { Id = model.SessionId }).data;

            var startDateTime = DateTime.Parse(model.AppointmentDate + " " + session.StartTime);
            var endDateTime = DateTime.Parse(model.AppointmentDate + " " + session.EndTime);

            model.StartDateTime = startDateTime;
            model.EndDateTime = endDateTime;

            var staffSessions = GetStaffAvailableSessions(new AvailableSessionsRequestDto { StaffId = model.StaffId, AppointmentDate = model.AppointmentDate }, model.Id).data;
            var hasStaffSession = staffSessions.AvailableSessions.Find(x => TimeSpan.Parse(x.Sessions.StartTime) == TimeSpan.Parse(session.StartTime) || TimeSpan.Parse(x.Sessions.EndTime) == TimeSpan.Parse(session.EndTime));
            
            if (hasStaffSession == null)
                throw new Exception("İlgili Personelin bu Seans tanımı bulunamadı!");
            
            if (!hasStaffSession.IsAvailable)
                throw new Exception("Bu saat aralığında bir randevu kaydı zaten var!");

            return model;
        }

        public IDataResult<List<AppointmentsDto>> UndoDeleteAppointments(IdRequest model)
        {
            CheckAppointment(GetAppointmentsById(model).data);

            Appointments Appointments = _service.Find(x => x.Id == model.Id);

            _service.UndoSoftDelete(Appointments);

            var result = SetAppointments(_service.GetList().OrderByDescending(x => x.StaffId));

            return new SuccessDataResult<List<AppointmentsDto>>(result);
        }

        public IDataResult<AppointmentsDto> GetAppointmentsById(IdRequest model)
        {
            AppointmentsDto response = SetAppointments(_service.Find(x => x.Id == model.Id));

            AppointmentsDto result = SetAppointments(response);

            return new SuccessDataResult<AppointmentsDto>(result);
        }

        public IDataResult<AvailableSessionsResponseDto> GetStaffAvailableSessions(AvailableSessionsRequestDto model, int? appointmentId = null)
        {
            List<Appointments> StaffAppointments = _service.Where(x => x.StartDateTime.Date == Convert.ToDateTime(model.AppointmentDate).Date).ToList();

            List<StaffSessionsDto> StaffSessions = _staffSessionsService.GetStaffSessionsByStaffId(new IdRequest { Id = model.StaffId }).data;

            foreach (var ses in StaffSessions)
            {
                var anyApp = StaffAppointments.Find(x => (x.StartDateTime.ToString("HH:mm") == ses.Sessions.StartTime || x.EndDateTime.ToString("HH:mm") == ses.Sessions.EndTime) && (appointmentId.HasValue ? x.Id == appointmentId : 1 == 1) && x.IsActive == true);
                if (anyApp == null)
                {
                    ses.IsAvailable = true;
                }
            }

            return new SuccessDataResult<AvailableSessionsResponseDto>(new AvailableSessionsResponseDto { AvailableSessions = StaffSessions });
        }

        private AppointmentsDto SetAppointments(Appointments model)
        {
            var staff = _staffService.GetActiveStaffById(model.StaffId);
            var service = _servicesService.GetActiveServicesById(model.ServiceId);
            var customer = _customersService.GetActiveCustomersById(model.CustomerId);
            AppointmentsDto item = new AppointmentsDto();
            item.Id = model.Id;
            item.ServiceId = model.ServiceId;
            item.SessionId = _sessionsService.GetSessionsByStartEndTime(new SessionsStartEndTimeRequestDto { StartTime = model.StartDateTime.ToString("HH:mm"), EndTime = model.EndDateTime.ToString("HH:mm") }).data.Id;
            item.StaffId = model.StaffId;
            item.CustomerId = model.CustomerId;
            item.CustomerName = customer.FullName;
            item.IsActive = model.IsActive;
            item.StartDateTime = model.StartDateTime;
            item.EndDateTime = model.EndDateTime;
            item.StartTime = model.StartDateTime.ToString("HH:mm");
            item.EndTime = model.EndDateTime.ToString("HH:mm");
            item.AppointmentDate = model.StartDateTime.ToString("dd MMM yyyy");
            item.Staff = staff;
            item.ServiceName = service.Name;
            item.CreateDate = model.CreateDate;
            item.CreateUser = model.CreateUser;
            item.UpdateDate = model.UpdateDate;
            item.UpdateUser = model.UpdateUser;
            return item;

        }
        private List<AppointmentsDto> SetAppointments(IEnumerable<Appointments> model) => model.Select(x => new AppointmentsDto { Id = x.Id, CustomerId = x.CustomerId, CustomerName = _customersService.GetActiveCustomersById(x.CustomerId).FullName, StaffId = x.StaffId, StartTime = x.StartDateTime.ToString("HH:mm"), EndTime = x.EndDateTime.ToString("HH:mm"), ServiceId = x.ServiceId, StartDateTime = x.StartDateTime, EndDateTime = x.EndDateTime, AppointmentDate = x.StartDateTime.ToString("dd MMM yyyy"), IsActive = x.IsActive, CreateDate = x.CreateDate, CreateUser = x.CreateUser, UpdateDate = x.UpdateDate, UpdateUser = x.UpdateUser, Staff = _staffService.GetActiveStaffById(x.StaffId), ServiceName = _servicesService.GetActiveServicesById(x.ServiceId).Name, SessionId = _sessionsService.GetSessionsByStartEndTime(new SessionsStartEndTimeRequestDto { StartTime = x.StartDateTime.ToString("HH:mm"), EndTime = x.EndDateTime.ToString("HH:mm") }).data.Id }).ToList();

    }
}