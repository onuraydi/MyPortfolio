using MyPortfolio.WebApi.Dtos.PortfolioMainTitleDtos;

namespace MyPortfolio.WebApi.Services.PortfolioMainTitleServices
{
    public interface IPortfolioMainTitleService
    {
        Task<GetPortfolioMainTitleDto> GetPortfolioMainTitleAsync();
        Task UpdatePortfolioMainTitleAsync(UpdatePortfoiloMainTitleDto updatePortfoiloMainTitleDto);
        Task<GetPortfolioMainTitleByPortfolioMainTitleIdDto> GetPortfolioMainTitleByPortfolioMainTitleIdAsync(int id);
    }
}
