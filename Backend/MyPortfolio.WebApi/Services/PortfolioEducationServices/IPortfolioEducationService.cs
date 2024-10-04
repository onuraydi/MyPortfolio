using MyPortfolio.WebApi.Dtos.PortfolioEducationDtos;

namespace MyPortfolio.WebApi.Services.PortfolioEducationServices
{
    public interface IPortfolioEducationService
    {
        Task<List<GetAllPortfolioEducationDto>> GetAllPortfolioEducationAsync();
        Task CreatePortfolioEducationAsync(CreatePortfolioEducationDto createPortfolioEducationDto);
        Task UpdatePortfolioEducationAsync(UpdatePortfolioEducationDto updatePortfolioEducationDto);
        Task DeletePortfolioEducationAsync(int id);
        Task<GetPortfolioEducationByPortfolioEducationId> GetPortfolioEducationByPortfolioEducationIdAsync(int id);
    }
}
