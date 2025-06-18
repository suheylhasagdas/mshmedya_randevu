using Core.Helpers.Abstract;
using Core.Utilities.Results.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Filters
{
    public class ActionFiltersAttribute : ActionFilterAttribute
    {
        private readonly IAppUserService _userService;

        public ActionFiltersAttribute(IAppUserService userService, IHttpContextAccessor context)
        {
            _userService = userService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!_userService.IsAuthanticated)
            {
                if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    JsonResult jsonResult = new JsonResult(new ErrorResult() { responseText = "Sisteme yeniden giriş yapmanız gerekmektedir!", success = false });

                    context.Result = jsonResult;
                    return;
                }
                else
                {
                    context.Result = new RedirectResult("~/Login/LogOut");
                    return;
                }
            }



            base.OnActionExecuting(context);
        }
    }
}
