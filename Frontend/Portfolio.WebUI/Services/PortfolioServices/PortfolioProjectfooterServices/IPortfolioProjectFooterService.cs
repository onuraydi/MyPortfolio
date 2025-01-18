using Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectFooterDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectfooterServices
{
    public interface IPortfolioProjectFooterService
    {
        Task<List<GetAllPortfolioProjectFooterDto>> GetAllPortfolioProjectFooterAsync();
        Task CreatePortfolioProjectFooterAsync(CreatePortfolioProjectFooterDto createPortfolioProjectFooterDto);
        Task UpdatePortfolioProjectFooterAsync(UpdatePortfolioProjectFooterDto updatePortfolioProjectFooterDto);
        Task DeletePortfolioProjectFooterAsync(int id);
        Task<GetPortfollioProjectFooterByPortfolioProjectFooterIdDto> GetPortfollioProjectFooterByPortfolioProjectFooterIdAsync(int id);
    }
}
