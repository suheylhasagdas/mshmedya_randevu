using Core.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Request.Login;
using Model.Response.Login;
using Service.Abstract;

namespace UIWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAppUsersService _service;
        private readonly IAppUserService _appUserService;
        private readonly ISessionService _sessionService;
        public LoginController(IAppUsersService service, IAppUserService appUserService, ISessionService sessionService)
        {
            _service = service;
            _appUserService = appUserService;
            _sessionService = sessionService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (_appUserService.IsAuthanticated)
                return RedirectToAction(controllerName: "Home", actionName: "Index");
            return View();
        }

        [HttpPost]
        public JsonResult Login(LoginRequest model)
        {
            IDataResult<LoginResponse> result = _service.Login(model);

            return Json(result);
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            _sessionService.RemoveSession();

            return RedirectToAction(controllerName: "Login", actionName: "Index");
        }
    }
}
