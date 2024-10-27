using MyPortfolio.WebApi.Dtos.ProjectImageDtos;

namespace MyPortfolio.WebApi.Services.ProjectImageServices
{
    public interface IProjectImageService
    {
        Task UpdateProjectImageAsync(UpdateProjectImageDto updateProjectImageDto);
        Task DeleteProjectImageByProjectImageIdAsync(int id);

        Task<List<GetProjectImageByPortfolioProjectIdDto>> GetProjectImagesByPortfolioProjectIdAsync(int id);
    }
}
