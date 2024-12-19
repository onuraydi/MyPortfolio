using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using MyPortfolio.WebApi.Dtos.PortfolioSocialMediaFooter;

namespace MyPortfolio.WebApi.Services.PortfolioSocialMediaFooterServices
{
    public interface IPortfolioSocialMediaFooterService
    {
        Task<List<GetAllPortfolioSocialMediaFooterDto>> GetAllPortfolioSocialMediaFooterAsync();
        Task CreatePortfolioSocialMediaFooterAsync(CreatePortfolioSocialMediaFooterDto createPortfolioSocialMediaFooterDto);
        Task UpdatePortfolioSocialMediaFooterAsync(UpdatePortfolioSocialMediaFooterDto updatePortfolioSocialMediaFooterDto);
        Task DeletePortfolioSocialMediaFooterAsync(int id);
        Task<GetPortfolioSocialMediaFooterByIdDto> GetPortfolioSocialMediaFooterByIdAsync(int id);
    }
}
