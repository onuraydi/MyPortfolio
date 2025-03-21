﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminLayoutController : AdminBaseController
    {
        public IActionResult AdminLayout()
        {
            return View();
        }
    }
}
