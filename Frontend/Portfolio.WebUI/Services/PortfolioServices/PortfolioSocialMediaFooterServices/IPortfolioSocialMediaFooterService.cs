using Portfolio.DtoLayer.PortfolioDtos.PortfolioSocialMediaFooterDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioSocialMediaFooterServices
{
    public interface IPortfolioSocialMediaFooterService
    {
        Task<List<GetAllPortfolioSocialMediaFooterDto>> GetAllPortfolioSocialMediaFooterAsync();
        Task CreatePortfolioSocialMediaFooterAsync(CreatePortfolioSocialMediaFooterDto createPortfolioSocialMediaFooterDto);
        Task UpdatePortfolioSocialMediaFooterAsync(UpdatePortfolioSocialMediaFooterDto updatePortfolioSocialMediaFooterDto);
        Task DeletePortfolioSocialMediaFooterAsync(int id);
        Task<GetPortfolioSocilaMediaFooterByIdDto> GetPortfolioSocilaMediaFooterByIdAsync(int id);
    }
}
