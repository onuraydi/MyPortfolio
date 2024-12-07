using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;
using MyPortfolio.WebApi.Dtos.PortfolioBlogTagDtos;

namespace MyPortfolio.WebApi.Services.PortfolioBlogTagServices
{
    public interface IPortfolioBlogTagService
    {
        Task<List<GetAllPortfolioBlogTagDto>> GetAllPortfolioBlogTagAsync();
        Task CreatePortfolioBlogTagAsync(CreatePortfolioBlogTagDto createPortfolioBlogTagDto);
        Task UpdatePortfolioBlogTagAsync(UpdatePortfolioBlogTagDto updatePortfolioBlogTagDto);
        Task DeletePortfolioBlogTagAsync(int id);
        Task<GetPortfolioBlogTagByPortfolioBlogTagId> GetPortfolioBlogTagByPortfolioBlogTagIdAsync(int id);
        Task<List<GetPortfolioBlogsByPortfolioBlogTagsIdDto>> GetPortfolioBlogByPortfolioBlogTagIdAsync(int id);
    }
}
