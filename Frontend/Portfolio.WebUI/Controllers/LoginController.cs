﻿using Duende.IdentityModel.Client;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.LoginDtos;
using Portfolio.WebUI.Models;
using Portfolio.WebUI.Services.IdentityServices.Abstract;
using Portfolio.WebUI.Services.PortfolioServices.LoginServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Portfolio.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityService _identityService;

        public LoginController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var values = await _identityService.SignIn(loginDto);

            if (values == true)
            {
                return RedirectToAction("GetPortfolioAboutMe", "PortfolioAboutMe", new { area = "Admin" });
            }
            return View();  // 401 vb. bir sayfa gidecek 
        }



        //private readonly IHttpClientFactory _httpClientFactory;

        //public LoginController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDto loginDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync("https://localhost:5001/api/Logins", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonData = await response.Content.ReadAsStringAsync();
        //        var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
        //        {
        //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //        });

        //        if (tokenModel != null)
        //        {
        //            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        //            var token = handler.ReadJwtToken(tokenModel.Token);
        //            var claims = token.Claims.ToList();

        //            if (tokenModel.Token != null)
        //            {
        //                claims.Add(new Claim("portfolioToken", tokenModel.Token));
        //                var cliamsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
        //                var authProps = new AuthenticationProperties
        //                {
        //                    ExpiresUtc = tokenModel.ExpireDate,
        //                    IsPersistent = true
        //                };
        //                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(cliamsIdentity), authProps);
        //                return RedirectToAction("GetPortfolioAboutMe", "PortfolioAboutMe", new { area = "Admin" });
        //            }
        //        }
        //    }
        //    return BadRequest();
        //}
    }
}
