using MyPortfolio.WebApi.Dtos.PortfolioRoutingFooterDtos;

namespace MyPortfolio.WebApi.Services.PortfolioRoutingFooterServices
{
    public interface IPortfolioRoutingFooterService
    {
        Task<List<GetAllPortfolioRoutingFooterDto>> GetAllPortfolioRoutingFooterAsync();
        Task CreatePortfolioRoutingFooterAsync(CreatePortfolioRoutingFooterDto createPortfolioRoutingFooterDto);
        Task UpdatePortfolioRoutingFooterAsync(UpdatePortfolioRoutingFooterDto updatePortfolioRoutingFooterDto);
        Task DeletePortfolioRoutingFooterAsync(int id);
        Task<GetPortfolioRoutingFooterByPortfolioRoutingFooterIdDto> GetPortfolioRoutingFooterByPortfolioRoutingFooterIdAsync(int id);
    }
}
