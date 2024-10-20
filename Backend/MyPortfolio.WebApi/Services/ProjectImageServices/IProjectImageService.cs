using MyPortfolio.WebApi.Dtos.ProjectImageDtos;

namespace MyPortfolio.WebApi.Services.ProjectImageServices
{
    public interface IProjectImageService
    {
        Task<List<GetProjectImageByPortfolioProjectIdDto>> GetProjectImageByPortfolioProjectIdAsync(int id);
        Task CreateProjectImageAsync(CreateProjectImageDto createProjectImageDto);
        Task UpdateProjectImageAsync(UpdateProjectImageDto updateProjectImageDto);
        Task DeleteProjectImageAsync(int id);
    }
}
