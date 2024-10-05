using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class denemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
