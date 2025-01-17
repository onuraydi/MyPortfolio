using Portfolio.DtoLayer.PortfolioDtos.PortfolioFreelanceDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioFreelanceServices
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
