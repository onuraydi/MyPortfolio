using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.FreelanceViewComponents
{
    public class _FreelanceViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
