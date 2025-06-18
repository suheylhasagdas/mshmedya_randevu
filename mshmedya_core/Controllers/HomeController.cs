using Microsoft.AspNetCore.Mvc;
using Model.Dtos.Appointments;
using Model.ViewModels;
using Service.Abstract;
using System;

namespace UIWeb.Controllers
{
    public class HomeController : MshController
    {
        private readonly IAppointmentsService _service;
        private readonly IStaffService _staffService;
        private readonly IStaffServicesService _staffServicesService;
        private readonly IStaffSessionsService _staffSessionsService;
        private readonly ICustomersService _customersService;
        private readonly IServicesService _servicesService;
        private readonly ISessionsService _sessionsService;
        public HomeController(IAppointmentsService service, IStaffService staffService, IServicesService servicesService, ISessionsService sessionsService, ICustomersService customersService, IStaffServicesService staffServicesService, IStaffSessionsService staffSessionsService)
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
            HomeViewModel model = new HomeViewModel();
            model.Appointments = _service.GetActiveAppointmentsByDate(new CalendarRequestDto { CurrentDate = DateTime.Now });
            model.CustomersCount = _customersService.GetActiveCustomers().Count;
            model.AppointmentsCount = _service.GetActiveFutureAppointments().Count;
            model.StaffCount = _staffService.GetActiveStaff().Count;
            model.ServicesCount = _staffServicesService.GetActiveStaffServices().Count;
            return View(model);
        }
    }
}
