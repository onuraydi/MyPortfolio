using Portfolio.DtoLayer.PortfolioDtos.PortfolioExperineceDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioExperienceServices
{
    public interface IPortfolioExperienceService
    {
        Task<List<GetAllPortfolioExperienceDto>> GetAllPortfolioExperienceAsync();
        Task CreatePortfolioExperienceAsync(CreatePortfolioExperienceDto createPortfolioExperienceDto);
        Task UpdatePortfolioExperienceAsync(UpdatePortfolioExperienceDto updatePortfolioExperienceDto);
        Task DeletePortfolioExperienceAsync(int id);
        Task<GetPortfolioExperienceByPortfolioExperienceIdDto> GetPortfolioExperienceByPortfolioExperienceIdAsync(int id);
    }
}
