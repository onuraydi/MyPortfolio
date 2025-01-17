using MyPortfolio.WebApi.Dtos.PortfolioFreelanceDtos;

namespace MyPortfolio.WebApi.Services.PorfolioFreelanceServices
{
    public interface IPortfolioFreelanceService
    {
        Task<List<GetAllPortfolioFreelanceDto>> GetAllPortfolioFreelanceAsync();
        Task CreatePortfolioFreelanceAsync(CreatePortfolioFreelanceDto createPortfolioFreelanceDto); 
        Task UpdatePortfolioFreelanceAsync(UpdatePortfolioFreelanceDto updatePortfolioFreelanceDto);
        Task DeletePortfolioFreelanceAsync(int id);
        Task<GetPortfolioFreelanceByPortfolioFreelanceIdDto> GetPortfolioFreelanceByPortfolioFreelanceIdAsync(int id);
    }
}
