using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace UIWeb.ViewComponents
{
    public class Footer : ViewComponent
    {
        public Footer()
        {
        }
        public IViewComponentResult Invoke()
        {
            LayoutViewModel model = new LayoutViewModel();

            return View(model);
        }
    }
}
