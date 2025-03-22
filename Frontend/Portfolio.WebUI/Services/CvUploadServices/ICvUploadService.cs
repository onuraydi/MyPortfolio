namespace Portfolio.WebUI.Services.CvUploadServices
{
    public interface ICvUploadService
    {
        Task<string> CreateCvFileAsync(IFormFile cvFile);
    }
}
