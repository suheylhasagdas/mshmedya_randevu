using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace UIWeb.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionHandler.Path;
            ViewBag.ExceptionMessage = exceptionHandler.Error.Message;
            ViewBag.StackTrace = exceptionHandler.Error.StackTrace;
            return View();
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404: RedirectToAction("404", "Error");
                    break;

                default: RedirectToAction("Error");
                    break;
            }
            return View();
        }

        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
