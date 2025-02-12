using MyPortfolio.WebApi.Entites.Identity;

namespace MyPortfolio.WebApi.Services.AuthServices
{
    public interface ILoginService
    {
        Task<TokenModel> Login(LoginModel loginModel);
    }
}
