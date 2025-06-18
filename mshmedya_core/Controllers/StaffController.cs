using Microsoft.AspNetCore.Mvc;
using Model.Dtos.Staff;
using Model.Request.Common;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIWeb.Controllers
{
    public class StaffController : MshController
    {
        private readonly IStaffService _service;
        public StaffController(IStaffService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _StaffList()
        {
            return _List(null);
        }

        [HttpGet]
        public PartialViewResult _List(List<StaffDto> model)
        {
            if (model == null)
                model = _service.GetAllStaff().data;

            PartialViewResult p = PartialView("_StaffList", model);

            return p;
        }

        [HttpGet]
        public PartialViewResult _InsertStaff()
        {
            PartialViewResult p = PartialView("_InsertStaff");

            return p;
        }

        [HttpPost]
        public PartialViewResult InsertStaff(StaffDto model)
        {
            var result = _service.InsertStaff(model);

            return _List(result.data);
        }


        [HttpPost]
        public PartialViewResult _UpdateStaff([FromBody] IdRequest model)
        {
            StaffDto result = _service.GetStaffById(model).data;

            PartialViewResult p = PartialView("_UpdateStaff", result);

            return p;
        }
        [HttpPost]
        public PartialViewResult UpdateStaff(StaffDto model)
        {
            var result = _service.UpdateStaff(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _DeleteStaff([FromBody] IdRequest model)
        {
            var result = _service.DeleteStaff(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _UndoDeleteStaff([FromBody] IdRequest model)
        {
            var result = _service.UndoDeleteStaff(model);

            return _List(result.data);
        }

    }
}
