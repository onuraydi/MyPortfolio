using Portfolio.DtoLayer.PortfolioDtos.LoginDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.LoginServices
{
    public interface IloginServices
    {
        Task<string> Login(LoginDto loginDto);
    }
}
