
namespace Portfolio.WebUI.Services.CvUploadServices
{
    public class CvUploadService : ICvUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CvUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> CreateCvFileAsync(IFormFile cvFile)
        {
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");

            if(!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = cvFile.FileName + Path.GetExtension(cvFile.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var fileStream = new FileStream(filePath,FileMode.Create))
            {
                await cvFile.CopyToAsync(fileStream);
            }

            return Path.Combine("/Uploads/", fileName);
        }
    }
}
