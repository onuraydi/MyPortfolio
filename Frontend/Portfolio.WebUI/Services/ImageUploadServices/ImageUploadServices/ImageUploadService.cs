﻿
using Portfolio.DtoLayer.PortfolioDtos.ProjectImageDtos;

namespace Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<GetProjectImageByPortfolioProjectIdDto> UpdateManyImageAsync(IFormFile image)
        {
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var filestream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(filestream);
            }

            var result = new GetProjectImageByPortfolioProjectIdDto
            {
                Image = Path.Combine("/uploads/", fileName) // DTO'nun ImagePath veya uygun alanını ayarlayın.
            };

            return result;
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

        public async Task<List<CreateProjectImageDto>> UploadManyImageAsync(List<IFormFile> images)
        {
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var imagePaths = new List<CreateProjectImageDto>();

            foreach (var image in images)
            {

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                using (var fileStream = new FileStream(filePath,FileMode.Create)) 
                {
                    await image.CopyToAsync(fileStream);
                }

                var imagesDto = new CreateProjectImageDto()
                {
                    Image = Path.Combine("/uploads/", fileName),
                };

                imagePaths.Add(imagesDto);
            }

            return imagePaths;
        }
    }
}
