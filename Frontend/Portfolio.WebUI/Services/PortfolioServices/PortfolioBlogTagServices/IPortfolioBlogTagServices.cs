using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices
{
    public interface IPortfolioBlogTagServices
    {
        Task<List<GetAllPortfolioBlogTagDto>> GetAllPortfolioBlogTagAsync();
        Task CreatePortfolioBlogTagAsync(CreatePortfolioBlogTagDto createPortfolioBlogTagDto);
        Task UpdatePortfolioBlogTagAsync(UpdatePortfolioBlogTagDto updatePortfolioBlogTagDto);
        Task DeletePortfolioBlogTagAsync(int id);
        Task<GetPortfolioBlogTagByPortfolioBlogTagIdDto> GetPortfolioBlogTagByPortfolioBlogTagIdAsync(int id);
        Task<List<GetPortfolioBlogsByPortfolioTagId>> GetPortfolioBlogTagsByPortfolioBlogTagIdAsync(int id);
    }
}
