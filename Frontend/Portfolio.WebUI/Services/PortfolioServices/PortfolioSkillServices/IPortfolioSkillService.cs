using Portfolio.DtoLayer.PortfolioDtos.PortfolioSkillDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioSkillServices
{
    public interface IPortfolioSkillService
    {
        Task<List<GetAllPortfolioSkillDto>> GetAllPortfolioSkillAsync();
        Task CreatePortfolioSkillAsync(CreatePortfolioSkillDto createPortfolioSkillDto);
        Task UpdatePortfolioSkillAsync(UpdatePortfolioSkillDto updatePortfolioSkillDto);
        Task DeletePortfolioSkillAsync(int id);
        Task<GetPortfolioSkillByPortfolioSkillIdDto> GetPortfolioSkillByPortfolioSkillIdAsync(int id);
    }
}
