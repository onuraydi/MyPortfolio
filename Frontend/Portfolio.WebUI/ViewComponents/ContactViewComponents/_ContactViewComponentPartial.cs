using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
