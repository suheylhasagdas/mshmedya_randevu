using Microsoft.AspNetCore.Mvc;
using Model.Dtos.Customers;
using Model.Request.Common;
using Service.Abstract;
using System.Collections.Generic;

namespace UIWeb.Controllers
{
    public class CustomersController : MshController
    {
        private readonly ICustomersService _service;
        public CustomersController(ICustomersService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _CustomersList()
        {
            return _List(null);
        }

        [HttpGet]
        public PartialViewResult _List(List<CustomersDto> model)
        {
            if (model == null)
                model = _service.GetAllCustomers().data;

            PartialViewResult p = PartialView("_CustomersList", model);

            return p;
        }

        [HttpGet]
        public PartialViewResult _InsertCustomers()
        {
            PartialViewResult p = PartialView("_InsertCustomers");

            return p;
        }

        [HttpPost]
        public PartialViewResult InsertCustomers(CustomersDto model)
        {
            var result = _service.InsertCustomers(model);

            return _List(result.data);
        }


        [HttpPost]
        public PartialViewResult _UpdateCustomers([FromBody] IdRequest model)
        {
            CustomersDto result = _service.GetCustomersById(model).data;

            PartialViewResult p = PartialView("_UpdateCustomers", result);

            return p;
        }
        [HttpPost]
        public PartialViewResult UpdateCustomers(CustomersDto model)
        {
            var result = _service.UpdateCustomers(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _DeleteCustomers([FromBody] IdRequest model)
        {
            var result = _service.DeleteCustomers(model);

            return _List(result.data);
        }

        [HttpPost]
        public PartialViewResult _UndoDeleteCustomers([FromBody] IdRequest model)
        {
            var result = _service.UndoDeleteCustomers(model);

            return _List(result.data);
        }

    }
}
