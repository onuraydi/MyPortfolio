using Portfolio.DtoLayer.PortfolioDtos.PortfolioContactDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioContactServices
{
    public interface IPortfolioContactService
    {
        Task<List<GetAllPortfolioContactDto>> GetAllPortfolioContactAsync();
        Task CreatePortfolioContactAsync(CreatePortfolioContactDto createPortfolioContactDto);
        Task UpdatePortfolioContactAsync(UpdatePortfolioContactDto updatePortfolioContactDto);
        Task DeletePortfolioContactAsync(int id);
        Task<GetPortfolioContactByPortfolioContactIdDto> GetPortfolioContactByPortfolioContactIdAsync(int id);
        Task MarkAsRead(int id);
        Task MarkAsNotRead(int id);
    }
}
