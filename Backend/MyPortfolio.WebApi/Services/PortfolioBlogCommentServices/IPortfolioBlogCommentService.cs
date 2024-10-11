using MyPortfolio.WebApi.Dtos.PortfolioBlogCommentDtos;

namespace MyPortfolio.WebApi.Services.PortfolioBlogCommentServices
{
    public interface IPortfolioBlogCommentService
    {
        Task<List<GetAllPortfolioBlogCommentDto>> GetAllPortfolioBlogCommentAsync();
        Task CreatePortfolioBlogCommentAsync(CreatePortfolioBlogCommentDto createPortfolioBlogCommentDto);
        Task DeletePortfolioBlogCommentAsync(int id);
        Task<GetPortfolioBlogCommentByPortfolioBlogCommentIdDto> GetPortfolioBlogCommentByPortfolioBlogCommentIdAsync(int id);
    }
}
