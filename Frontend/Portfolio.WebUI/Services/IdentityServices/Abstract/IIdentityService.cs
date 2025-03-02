using Portfolio.DtoLayer.PortfolioDtos.LoginDtos;

namespace Portfolio.WebUI.Services.IdentityServices.Abstract
{
    public interface IIdentityService
    {
        Task<bool> SignIn(LoginDto loginDto);
        Task<bool> GetRefreshToken();
    }
}
