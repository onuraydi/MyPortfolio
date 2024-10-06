using MyPortfolio.WebApi.Dtos.PortfolioTechnologyDtos;

namespace MyPortfolio.WebApi.Services.PortfolioTechnologyServices
{
    public interface IPortfolioTechnologyService
    {
        Task<List<GetAllPortfolioTechnologyDto>> GetAllPortfolioTechnologyAsync();
        Task CreatePortfolioTechnologyAsync(CreatePortfolioTechnologyDto createPortfolioTechnologyDto);
        Task UpdatePortfolioTechnologyAsync(UpdatePortfolioTechnologyDto updatePortfolioTechnologyDto);
        Task DeletePortfolioTechnologyAsync(int id);
        Task<GetPortfolioTechnologyByPortfolioTechnologyIdDto> GetPortfolioTechnologyByPortfolioTechnologyIdAsync(int id);
    }
}
