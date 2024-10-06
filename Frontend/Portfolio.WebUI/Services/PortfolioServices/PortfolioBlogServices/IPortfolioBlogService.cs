using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices
{
    public interface IPortfolioBlogService
    {
        Task<List<GetAllPortfolioBlogDto>> GetAllPortfolioBlogAsync();
        Task CreatePortfolioBlogAsync(CreatePortfolioBlogDto createPortfolioBlogDto);
        Task UpdatePortfolioBlogAsync(UpdatePortfolioBlogDto updatePortfolioBlogDto);
        Task DeletePortfolioBlogAsync(int id);
        Task<GetPortfolioBlogByPortfolioBlogIdDto> GetPortfolioBlogByPortfolioBlogIdAsync(int id);
    }
}
