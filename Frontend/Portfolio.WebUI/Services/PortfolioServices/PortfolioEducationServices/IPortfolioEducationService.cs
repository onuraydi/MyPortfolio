using Portfolio.DtoLayer.PortfolioDtos.PortfolioEducationDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioEducationServices
{
    public interface IPortfolioEducationService
    {
        Task<List<GetAllPortfolioEducationDto>> GetAllPortfolioEducationAsync();
        Task CreatePortfolioEducationAsync(CreatePortfolioEducationDto createPortfolioEducationDto);
        Task UpdatePortfolioEducationAsync(UpdatePortfolioEducationDto updatePortfolioEducationDto);
        Task DeletePortfolioEducationAsync(int id);
        Task<GetPortfolioEducationByPortfolioEducationDto> GetPortfolioEducationByPortfolioEducationAsync(int id); 
    }
}
