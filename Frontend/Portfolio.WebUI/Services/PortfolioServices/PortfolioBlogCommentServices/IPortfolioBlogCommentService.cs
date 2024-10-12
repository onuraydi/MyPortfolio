using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogCommentDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices
{
    public interface IPortfolioBlogCommentService
    {
        Task<List<GetAllPortfolioBlogCommentDto>> GetAllPortfolioBlogCommentAsync();
        Task CreatePortfolioBlogCommentAsync(CreatePortfolioBlogCommentDto createPortfolioBlogCommentDto);
        Task DeletePortfolioBlogCommentAsync(int id);
        Task<GetPortfolioBlogCommentByPortfolioBlogCommentIdDto> GetPortfolioBlogCommentByPortfolioBlogCommentIdAsync(int id);
        Task<List<GetPortfolioBlogCommentByPortfolioBlogIdDto>> GetPortfolioBlogCommentByPortfolioBlogIdAsync(int id);
    }
}
