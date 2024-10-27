using Portfolio.DtoLayer.PortfolioDtos.ProjectImageDtos;

namespace Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile image);
        Task<List<CreateProjectImageDto>> UploadManyImageAsync(List<IFormFile> images);   
        Task<GetProjectImageByPortfolioProjectIdDto> UpdateManyImageAsync(IFormFile images);
    }
}
