
namespace Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var filestream = new FileStream(filePath,FileMode.Create))
            {
                await image.CopyToAsync(filestream);
            }

            return Path.Combine("/uploads/", fileName);
        }
    }
}
