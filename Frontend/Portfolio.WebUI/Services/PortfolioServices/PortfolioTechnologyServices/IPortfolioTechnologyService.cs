using Portfolio.DtoLayer.PortfolioDtos.PortfolioTechnologyDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioTechnologyServices
{
    public interface IPortfolioTechnologyService
    {
        Task<List<GetAllPortfolioTechnologyDto>> GetAllPortfolioTechnologyAsync();
        Task CreatePortfolioTechnologyAsync(CreatePortfolioTechnologyDto createPortfolioTechnologyDto);
        Task UpdatePortfolioTechnologyAsync(UpdatePortfolioTechnologyDto updatePortfolioTechnologyDto);
        Task DeletePortfolioTechnologyAsync(int id);
        Task<GetPortfolioTechnologyByPortfolioTechnologyIdDto> GetPortfolioTechnologyByPortfolioTechnologyIdAsync(int
            id);
    }
}
