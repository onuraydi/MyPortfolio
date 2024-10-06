using Portfolio.DtoLayer.PortfolioDtos.PortfolioAboutMeDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioAboutMeServices
{
    public interface IPortfolioAboutMeService
    {
        Task<GetPortfolioAboutMeDto> GetPortfolioAboutMeAsync();
        Task UpdatePortfolioAboutMeAsync(UpdatePortfolioAboutMeDto updatePortfolioAboutMeDto);
        Task<GetPortfolioAboutMeByPortfolioAboutMeIdDto> GetPortfolioAboutMeByPortfolioAboutMeIdAsync(int id);
    }
}
