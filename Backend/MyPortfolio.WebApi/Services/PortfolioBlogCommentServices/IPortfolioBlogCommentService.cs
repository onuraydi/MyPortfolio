using MyPortfolio.WebApi.Dtos.PortfolioBlogCommentDtos;

namespace MyPortfolio.WebApi.Services.PortfolioBlogCommentServices
{
    public interface IPortfolioBlogCommentService
    {
        Task<List<GetAllPortfolioBlogCommentDto>> GetAllPortfolioBlogCommentAsync();
        Task<CreatePortfolioBlogCommentDto> CreatePortfolioBlogCommentAsync(CreatePortfolioBlogCommentDto createPortfolioBlogCommentDto);
        Task DeletePortfolioBlogCommentAsync(int id);
        Task<GetPortfolioBlogCommentByPortfolioBlogCommentIdDto> GetPortfolioBlogCommentByPortfolioBlogCommentIdAsync(int id);

        Task<List<GetPortfolioBlogCommentByPortfolioBlogIdDto>> GetPortfolioBlogCommentByPortfolioBlogIdAsync(int id);
    }
}
