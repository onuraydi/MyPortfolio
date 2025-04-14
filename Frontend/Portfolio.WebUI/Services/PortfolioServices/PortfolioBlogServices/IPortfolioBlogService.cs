using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices
{
    public interface IPortfolioBlogService
    {
        Task<List<GetAllPortfolioBlogDto>> GetAllPortfolioBlogAsync();
        Task<CreatePortfolioBlogDto> CreatePortfolioBlogAsync(CreatePortfolioBlogDto createPortfolioBlogDto);
        Task UpdatePortfolioBlogAsync(UpdatePortfolioBlogDto updatePortfolioBlogDto);
        Task DeletePortfolioBlogAsync(int id);
        Task MarkSuggested(int id);
        Task<GetPortfolioBlogByPortfolioBlogIdDto> GetPortfolioBlogByPortfolioBlogIdAsync(int id);
        Task<List<GetAllPortfolioBlogDto>> GetSuggestedPortfolioBlog();
        Task<List<GetAllPortfolioBlogDto>> GetBlogByCategory(int id);
        Task<List<GetAllPortfolioBlogDto>> GetBlogByTag(int id);
    }
}
