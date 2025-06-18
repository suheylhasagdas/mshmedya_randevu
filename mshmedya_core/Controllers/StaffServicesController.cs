using Microsoft.AspNetCore.Mvc;
using Model.Dtos.StaffServices;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;

namespace UIWeb.Controllers
{
    public class StaffServicesController : MshController
    {
        private readonly IStaffServicesService _service;
        private readonly IStaffService _staffService;
        private readonly IServicesService _servicesService;
        public StaffServicesController(IStaffServicesService service, IStaffService staffService, IServicesService servicesService)
        {
            _service = service;
            _staffService = staffService;
            _servicesService = servicesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _StaffServicesList()
        {
            return _List(null);
        }

        [HttpGet]
        public PartialViewResult _List(List<StaffServicesDto> model)
        {
            if (model == null)
                model = _service.GetAllStaffServices().data;

            PartialViewResult p = PartialView("_StaffServicesList", model);

            return p;
        }

        [HttpGet]
        public PartialViewResult _InsertStaffServices()
        {
            var model = new StaffServicesDto();
            model.StaffList = _staffService.GetActiveStaff();
            model.ServicesList = _servicesService.GetActiveServices();

            PartialViewResult p = PartialView("_InsertStaffServices", model);

            return p;
        }

        [HttpPost]
        public PartialViewResult InsertStaffServices(StaffServicesDto model)
        {
            var result = _service.InsertStaffServices(model);

            return _List(result.data);
        }


        [HttpPost]
        public PartialViewResult _UpdateStaffServices([FromBody] IdRequest model)
        {
            StaffServicesDto result = _service.GetStaffServicesById(model).data;
            result.StaffList = _staffService.GetActiveStaff();
            result.ServicesList = _servicesService.GetActiveServices();

            PartialViewResult p = PartialView("_UpdateStaffServices", result);

            return p;
        }
        [HttpPost]
        public PartialViewResult UpdateStaffServices(StaffServicesDto model)
        {
            var result = _service.UpdateStaffServices(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _DeleteStaffServices([FromBody] IdRequest model)
        {
            var result = _service.DeleteStaffServices(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _UndoDeleteStaffServices([FromBody] IdRequest model)
        {
            var result = _service.UndoDeleteStaffServices(model);

            return _List(result.data);
        }

        [HttpPost]
        public JsonResult GetStaffServicesByStaffId([FromBody] IdRequest model)
        {
            var result = _service.GetStaffServicesByStaffId(model);

            return Json(result.data);
        }

    }
}
