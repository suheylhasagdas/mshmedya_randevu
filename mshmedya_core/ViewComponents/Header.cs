using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using Model.ViewModels;

namespace UIWeb.ViewComponents
{
    public class Header : ViewComponent
    {
        public Header()
        {
        }
        public IViewComponentResult Invoke()
        {
            LayoutViewModel model = new LayoutViewModel();


            return View(model);
        }
    }
}
