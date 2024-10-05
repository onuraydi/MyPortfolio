using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
