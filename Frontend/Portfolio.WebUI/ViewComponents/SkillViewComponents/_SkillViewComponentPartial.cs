using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.ViewComponents.SkillViewComponents
{
    public class _SkillViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
