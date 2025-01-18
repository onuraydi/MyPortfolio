using MyPortfolio.WebApi.Dtos.PortfolioProjectFooterDtos;

namespace MyPortfolio.WebApi.Services.PortfolioProjectFooterServices
{
    public interface IPortfolioProjectFooterService
    {
        Task<List<GetAllPortfolioProjectFooterDto>> GetAllPortfolioProjectFooterAsync();
        Task CreatePortfolioProjectFooterAsync(CreatePortfolioProjectFooterDto createPortfolioProjectFooterDto);
        Task UpdatePortfolioProjectFooterAsync(UpdatePortfolioProjectFooterDto updatePortfolioProjectFooterDto);
        Task DeletePortfolioProjectFooterAsync(int id);
        Task<GetPortfolioProjectFooterByPortfolioProjectFooterIdDto> GetPortfolioProjectFooterByPortfolioProjectFooterIdAsync(int id);
    }
}
