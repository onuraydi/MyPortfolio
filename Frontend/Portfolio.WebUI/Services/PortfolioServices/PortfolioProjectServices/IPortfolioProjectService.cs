using Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectServices
{
    public interface IPortfolioProjectService
    {
        Task<List<GetAllPortfolioProjectDto>> GetAllPortfolioProjectAsync();
        Task CreatePortfolioProjectAsync(CreatePortfolioProjectDto createPortfolioProjectDto);
        Task UpdatePortfolioProjectAsync(UpdatePortfolioProjectDto updatePortfolioProjectDto);
        Task DeletePortfolioProjectAsync(int id);
        Task<GetPortfolioProjectByPortfolioProjectIdDto> GetAllPortfolioProjectByPortfolioProjectIdAsync(int id);
    }
}
