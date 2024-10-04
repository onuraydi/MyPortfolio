using MyPortfolio.WebApi.Dtos.PortfolioSkillDtos;

namespace MyPortfolio.WebApi.Services.PortfolioSkillServices
{
    public interface IPortfolioSkillService
    {
        Task<List<GetAllPortfolioSkillDto>> GetAllPortfolioSkillAsync();
        Task CreatePortfolioSkillAsync(CreatePortfolioSkillDto createPortfolioSkillDto);
        Task UpdatePortfolioSkillAsync(UpdatePortfolioSkillDto updatePortfolioSkillDto);
        Task DeletePortfolioSkillAsync(int id);
        Task<GetPortfolioSkillBySkillIdDto> GetPortfolioSkillBySkillIdAsync(int id);
    }
}
