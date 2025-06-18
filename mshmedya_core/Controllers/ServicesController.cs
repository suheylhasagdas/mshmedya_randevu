using Microsoft.AspNetCore.Mvc;
using Model.Dtos.Services;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;

namespace UIWeb.Controllers
{
    public class ServicesController : MshController
    {
        private readonly IServicesService _service;
        public ServicesController(IServicesService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _ServicesList()
        {
            return _List(null);
        }

        [HttpGet]
        public PartialViewResult _List(List<ServicesDto> model)
        {
            if (model == null)
                model = _service.GetAllServices().data;

            PartialViewResult p = PartialView("_ServicesList", model);

            return p;
        }

        [HttpGet]
        public PartialViewResult _InsertServices()
        {
            PartialViewResult p = PartialView("_InsertServices");

            return p;
        }

        [HttpPost]
        public PartialViewResult InsertServices(ServicesDto model)
        {
            var result = _service.InsertServices(model);

            return _List(result.data);
        }


        [HttpPost]
        public PartialViewResult _UpdateServices([FromBody] IdRequest model)
        {
            ServicesDto result = _service.GetServicesById(model).data;

            PartialViewResult p = PartialView("_UpdateServices", result);

            return p;
        }
        [HttpPost]
        public PartialViewResult UpdateServices(ServicesDto model)
        {
            var result = _service.UpdateServices(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _DeleteServices([FromBody] IdRequest model)
        {
            var result = _service.DeleteServices(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _UndoDeleteServices([FromBody] IdRequest model)
        {
            var result = _service.UndoDeleteServices(model);

            return _List(result.data);
        }

    }
}
