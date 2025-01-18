using Portfolio.DtoLayer.PortfolioDtos.PortfolioRoutingFooterDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioRoutingFooterServices
{
    public interface IPortfolioRoutingFooterService
    {
        Task<List<GetAllPortfolioRoutingFooterDto>> GetAllPortfolioRoutingFooterAsync();
        Task CreatePortfolioRoutingFooterDto(CreatePortfolioRoutingFooterDto createPortfolioRoutingFooterDto);
        Task UpdatePortfolioRoutingFooterDto(UpdatePortfolioRoutingFooterDto updatePortfolioRoutingFooterDto);
        Task DeletePortfolioRoutingFooterDto(int id);
        Task<GetPortfolioRoutingFooterByPortfolioRoutingFooterIdDto> GetPortfolioRoutingFooterByPortfolioRoutingFooterIdAsync(int id);
    }
}
