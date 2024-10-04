using MyPortfolio.WebApi.Dtos.PortfolioCertificateDtos;

namespace MyPortfolio.WebApi.Services.PortfolioCertificateServices
{
    public interface IPortfolioCertificateService
    {
        Task<List<GetAllPortfolioCertificateDto>> GetAllPortfolioCertificateAsync();
        Task CreatePortfolioCertificateAsync(CreatePortfolioCertificateDto createPortfolioCertificateDto);
        Task UpdatePortfolioCertificateAsync(UpdatePortfolioCertificateDto updatePortfolioCertificateDto);
        Task DeletePortfolioCertificateAsync(int id);
        Task<GetPortfolioCertificateByPortfolioCertificateIdDto> GetPortfolioCertificateByPortfolioCertificateIdAsync(int id);
    }
}
