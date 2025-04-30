using Portfolio.DtoLayer.PortfolioDtos.LoginDtos;
using Portfolio.WebUI.Models;

namespace Portfolio.WebUI.Services.IdentityServices.Abstract
{
    public interface IIdentityService
    {
        Task<bool> SignIn(LoginDto loginDto);
        Task<bool> GetRefreshToken();
    }
}
