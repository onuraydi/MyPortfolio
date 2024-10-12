using Portfolio.DtoLayer.PortfolioDtos.PortfolioMainTitleDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioMainTitleServices
{
    public interface IPortfolioMainTitleService
    {
        Task<List<GetPortfolioMainTitleDto>> GetPortfolioMainTitleAsync();
        Task UpdatePortfolioMainTitleAsync(UpdatePortfolioMainTitleDto updatePortfolioMainTitleDto);
        Task<GetPortfolioMainTitleByPortfolioMainTitleIdDto> GetPortfolioMainTitleByPortfolioMainTitleIdAsync(int id);
    }
}
