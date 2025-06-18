using Microsoft.AspNetCore.Mvc;
using Model.Dtos.StaffSessions;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;

namespace UIWeb.Controllers
{
    public class StaffSessionsController : MshController
    {
        private readonly IStaffSessionsService _service;
        private readonly IStaffService _staffService;
        private readonly ISessionsService _sessionsService;
        public StaffSessionsController(IStaffSessionsService service, IStaffService staffService, ISessionsService sessionsService)
        {
            _service = service;
            _staffService = staffService;
            _sessionsService = sessionsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _StaffSessionsList()
        {
            return _List(null);
        }

        [HttpGet]
        public PartialViewResult _List(List<StaffSessionsDto> model)
        {
            if (model == null)
                model = _service.GetAllStaffSessions().data;

            PartialViewResult p = PartialView("_StaffSessionsList", model);

            return p;
        }

        [HttpGet]
        public PartialViewResult _InsertStaffSessions()
        {
            var model = new StaffSessionsDto();
            model.StaffList = _staffService.GetActiveStaff();
            model.SessionsList = _sessionsService.GetActiveSessions();

            PartialViewResult p = PartialView("_InsertStaffSessions", model);

            return p;
        }

        [HttpPost]
        public PartialViewResult InsertStaffSessions(StaffSessionsDto model)
        {
            var result = _service.InsertStaffSessions(model);

            return _List(result.data);
        }


        [HttpPost]
        public PartialViewResult _UpdateStaffSessions([FromBody] IdRequest model)
        {
            StaffSessionsDto result = _service.GetStaffSessionsById(model).data;
            result.StaffList = _staffService.GetActiveStaff();
            result.SessionsList = _sessionsService.GetActiveSessions();

            PartialViewResult p = PartialView("_UpdateStaffSessions", result);

            return p;
        }
        [HttpPost]
        public PartialViewResult UpdateStaffSessions(StaffSessionsDto model)
        {
            var result = _service.UpdateStaffSessions(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _DeleteStaffSessions([FromBody] IdRequest model)
        {
            var result = _service.DeleteStaffSessions(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _UndoDeleteStaffSessions([FromBody] IdRequest model)
        {
            var result = _service.UndoDeleteStaffSessions(model);

            return _List(result.data);
        }

    }
}
