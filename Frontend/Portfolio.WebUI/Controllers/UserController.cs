﻿using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.IdentityServices.Abstract;

namespace Portfolio.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();
            return View(values);    
        }
    }
}
