namespace Portfolio.WebUI.Services.IdentityServices.Abstract
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
