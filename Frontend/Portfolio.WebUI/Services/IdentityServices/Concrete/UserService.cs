using Portfolio.WebUI.Models;
using Portfolio.WebUI.Services.IdentityServices.Abstract;

namespace Portfolio.WebUI.Services.IdentityServices.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/User/getUserInfo");
        }
    }
}
