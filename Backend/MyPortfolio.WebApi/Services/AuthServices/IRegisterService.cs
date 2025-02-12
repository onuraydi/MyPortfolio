using MyPortfolio.WebApi.Entites.Identity;

namespace MyPortfolio.WebApi.Services.AuthServices
{
    public interface IRegisterService
    {
        Task Register(RegisterModel registerModel);
    }
}
