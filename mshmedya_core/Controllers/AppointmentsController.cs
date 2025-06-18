using Microsoft.AspNetCore.Mvc;
using Model.Dtos.Appointments;
using Model.Dtos.Services;
using Model.Dtos.Sessions;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;

namespace UIWeb.Controllers
{
    public class AppointmentsController : MshController
    {
        private readonly IAppointmentsService _service;
        private readonly IStaffService _staffService;
        private readonly IStaffServicesService _staffServicesService;
        private readonly IStaffSessionsService _staffSessionsService;
        private readonly ICustomersService _customersService;
        private readonly IServicesService _servicesService;
        private readonly ISessionsService _sessionsService;
        public AppointmentsController(IAppointmentsService service, IStaffService staffService, IServicesService servicesService, ISessionsService sessionsService, ICustomersService customersService, IStaffServicesService staffServicesService, IStaffSessionsService staffSessionsService)
        {
            _service = service;
            _staffService = staffService;
            _servicesService = servicesService;
            _sessionsService = sessionsService;
            _customersService = customersService;
            _staffServicesService = staffServicesService;
            _staffSessionsService = staffSessionsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _AppointmentsList()
        {
            return _List(null);
        }

        [HttpGet]
        public PartialViewResult _List(List<AppointmentsDto> model)
        {
            if (model == null)
                model = _service.GetAllAppointments().data;

            PartialViewResult p = PartialView("_AppointmentsList", model);

            return p;
        }

        [HttpGet]
        public PartialViewResult _InsertAppointments()
        {
            var model = new AppointmentsDto();
            model.StaffList = _staffService.GetActiveStaff();
            model.ServicesList = new List<ServicesDto>();
            model.SessionsList = new List<SessionsDto>();
            model.CustomersList = _customersService.GetActiveCustomers();

            PartialViewResult p = PartialView("_InsertAppointments", model);

            return p;
        }

        [HttpPost]
        public PartialViewResult InsertAppointments(AppointmentsDto model)
        {
            var result = _service.InsertAppointments(model);

            return _List(result.data);
        }


        [HttpPost]
        public PartialViewResult _UpdateAppointments([FromBody] IdRequest model)
        {
            AppointmentsDto result = _service.GetAppointmentsById(model).data;
            result.StaffList = _staffService.GetActiveStaff();
            result.ServicesList = new List<ServicesDto>();
            result.SessionsList = new List<SessionsDto>();
            result.CustomersList = _customersService.GetActiveCustomers();

            PartialViewResult p = PartialView("_UpdateAppointments", result);

            return p;
        }

        [HttpPost]
        public PartialViewResult _InsertCalendarAppointments([FromBody] AppointmentsDto model)
        {
            model.StaffList = new List<Model.Dtos.Staff.StaffDto>();
            model.StaffList.Add(_staffService.GetActiveStaffById(model.StaffId));
            model.ServicesList = new List<ServicesDto>();
            model.SessionsList = new List<SessionsDto>();
            model.CustomersList = _customersService.GetActiveCustomers();
            var session = _sessionsService.GetActiveSessionsById(model.SessionId);
            model.StartTime = session.StartTime;
            model.EndTime = session.EndTime;

            PartialViewResult p = PartialView("_InsertCalendarAppointments", model);

            return p;
        }
        [HttpPost]
        public PartialViewResult UpdateAppointments(AppointmentsDto model)
        {
            var result = _service.UpdateAppointments(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _DeleteAppointments([FromBody] IdRequest model)
        {
            var result = _service.DeleteAppointments(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _UndoDeleteAppointments([FromBody] IdRequest model)
        {
            var result = _service.UndoDeleteAppointments(model);

            return _List(result.data);
        }

        [HttpPost]
        public JsonResult GetStaffAvailableSessions([FromBody] AvailableSessionsRequestDto model)
        {
            var result = _service.GetStaffAvailableSessions(model);

            return Json(result.data);
        }
        public IActionResult Calendar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCalendar([FromBody] CalendarRequestDto date)
        {
            CalendarDto model = new CalendarDto();
            model.Staffs = _staffService.GetActiveStaff();
            model.StaffSessions = _staffSessionsService.GetActiveStaffSessions();
            model.Sessions = _sessionsService.GetActiveSessions();
            model.Appointments = _service.GetActiveAppointmentsByDate(date);
            return Json(model);
        }

    }
}
