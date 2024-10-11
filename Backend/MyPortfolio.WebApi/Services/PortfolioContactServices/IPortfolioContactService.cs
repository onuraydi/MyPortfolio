using MyPortfolio.WebApi.Dtos.PortfolioContactDtos;

namespace MyPortfolio.WebApi.Services.PortfolioContactServices
{
    public interface IPortfolioContactService
    {
        Task<List<GetAllPortfolioContactDto>> GetAllPortfolioContactAsync();
        Task CreatePortfolioContactAsync(CreatePortfolioContactDto createPortfolioContactDto);
        Task UpdatePortfolioContactAsync(UpdatePortfolioContactDto updatePortfolioContactDto);
        Task DeletePortfolioContactAsync(int id);
        Task<GetPortfolioContactByPortfolioContactDto> GetPortfolioContactByPortfolioContactAsync(int id);
        Task MarkAsRead(int id);
        Task MarkAsNotRead(int id);
    }
}
