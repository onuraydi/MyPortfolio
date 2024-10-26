using Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectDtos;
using Portfolio.DtoLayer.PortfolioDtos.ProjectImageDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectServices
{
    public interface IPortfolioProjectService
    {
        Task<List<GetAllPortfolioProjectDto>> GetAllPortfolioProjectAsync();
        Task CreatePortfolioProjectAsync(CreatePortfolioProjectDto createPortfolioProjectDto);
        Task UpdatePortfolioProjectAsync(UpdatePortfolioProjectDto updatePortfolioProjectDto);
        Task DeletePortfolioProjectAsync(int id);
        Task<UpdatePortfolioProjectDto> GetAllPortfolioProjectByPortfolioProjectIdAsync(int id);
    }
}
