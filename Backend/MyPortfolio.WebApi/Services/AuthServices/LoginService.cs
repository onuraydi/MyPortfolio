using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyPortfolio.WebApi.Entites.Identity;
using MyPortfolio.WebApi.Services.TokenServices;
using System.IdentityModel.Tokens.Jwt;

namespace MyPortfolio.WebApi.Services.AuthServices
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public LoginService(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<TokenModel> Login(LoginModel loginModel)
        {
            User user = await _userManager.FindByEmailAsync(loginModel.Email);
            bool checkPassword = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if(user is null || !checkPassword)
            {
                throw new Exception();
            }

            var roles = await _userManager.GetRolesAsync(user);

            JwtSecurityToken token = await _tokenService.CreateToken(user,roles);
            string refreshToken = _tokenService.GenerateRefreshToken();

            //int.TryParse()
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpirtTime = DateTime.Now.AddDays(60);  // 60 kısmı jwt'nin refreshtokenvalidityDays'den alınmalı 

            await _userManager.UpdateAsync(user);

            await _userManager.UpdateSecurityStampAsync(user);

            var _token = new JwtSecurityTokenHandler().WriteToken(token);

            await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken",_token);

            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = DateTime.Now.AddMinutes(60)
            };
        }
    }
}
