using Portfolio.WebUI.Models;

namespace Portfolio.WebUI.Services.IdentityServices.Abstract
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
