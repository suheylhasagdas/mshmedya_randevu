using Microsoft.AspNetCore.Mvc;
using Model.Dtos.Sessions;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;

namespace UIWeb.Controllers
{
    public class SessionsController : MshController
    {
        private readonly ISessionsService _service;
        public SessionsController(ISessionsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SessionsList()
        {
            return _List(null);
        }

        [HttpGet]
        public PartialViewResult _List(List<SessionsDto> model)
        {
            if (model == null)
                model = _service.GetAllSessions().data;

            PartialViewResult p = PartialView("_SessionsList", model);

            return p;
        }

        [HttpGet]
        public PartialViewResult _InsertSessions()
        {
            PartialViewResult p = PartialView("_InsertSessions");

            return p;
        }

        [HttpPost]
        public PartialViewResult InsertSessions(SessionsDto model)
        {
            var result = _service.InsertSessions(model);

            return _List(result.data);
        }


        [HttpPost]
        public PartialViewResult _UpdateSessions([FromBody] IdRequest model)
        {
            SessionsDto result = _service.GetSessionsById(model).data;

            PartialViewResult p = PartialView("_UpdateSessions", result);

            return p;
        }
        [HttpPost]
        public PartialViewResult UpdateSessions(SessionsDto model)
        {
            var result = _service.UpdateSessions(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _DeleteSessions([FromBody] IdRequest model)
        {
            var result = _service.DeleteSessions(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _UndoDeleteSessions([FromBody] IdRequest model)
        {
            var result = _service.UndoDeleteSessions(model);

            return _List(result.data);
        }

    }
}
