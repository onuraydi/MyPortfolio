using Portfolio.DtoLayer.PortfolioDtos.PortfolioCertificateDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioCertificateServices
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
