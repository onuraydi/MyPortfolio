namespace Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile image);
    }
}
