using MyPortfolio.WebApi.Dtos.PortfolioAboutMeDtos;

namespace MyPortfolio.WebApi.Services.PortfolioAboutMeServices
{
    public interface IPortfolioAboutMeService
    {
        Task<GetPortfolioAboutMeDto> GetPortfolioAboutMeAsync();
        Task UpdatePortfolioAboutMeAsync(UpdatePortfolioAboutMeDto updatePortfolioAboutMeDto);
    }
}
