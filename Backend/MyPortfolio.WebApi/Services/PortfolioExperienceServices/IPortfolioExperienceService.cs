using MyPortfolio.WebApi.Dtos.PortfolioExperienceDtos;

namespace MyPortfolio.WebApi.Services.PortfolioExperienceServices
{
    public interface IPortfolioExperienceService
    {
        Task<List<GetAllPortfolioExperienceDto>> GetAllPortfolioExperienceAsync();
        Task CreatePortfolioExperienceAsync(CreatePortfolioExperienceDto createPortfolioExperienceDto);
        Task UpdatePortfolioExperienceAsync(UpdatePortfolioExperienceDto updatePortfolioExperienceDto);
        Task DeletePortfolioExperienceAsync(int id);
        Task<GetPortfolioExperienceByPortfolioExperienceIdDto> GetPortfolioExperienceByportfolioExperienceIdAsync(int id);
    }
}
