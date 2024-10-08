using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioCertificateDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioCertificateServices
{
    public class PortfolioCertificateService : IPortfolioCertificateService
    {
        private readonly HttpClient _httpClient;

        public PortfolioCertificateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioCertificateAsync(CreatePortfolioCertificateDto createPortfolioCertificateDto)
        {
            await _httpClient.PostAsJsonAsync("portfoliocertificates", createPortfolioCertificateDto);
        }

        public async Task DeletePortfolioCertificateAsync(int id)
        {
            await _httpClient.DeleteAsync("portfoliocertificates?id=" + id);
        }

        public async Task<List<GetAllPortfolioCertificateDto>> GetAllPortfolioCertificateAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfoliocertificates");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllPortfolioCertificateDto>>(jsonData);
            return values;
        }

        public async Task<GetPortfolioCertificateByPortfolioCertificateIdDto> GetPortfolioCertificateByPortfolioCertificateIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfoliocertificates/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioCertificateByPortfolioCertificateIdDto>();
            return values;
        }

        public async Task UpdatePortfolioCertificateAsync(UpdatePortfolioCertificateDto updatePortfolioCertificateDto)
        {
            await _httpClient.PutAsJsonAsync("portfoliocertificates", updatePortfolioCertificateDto);
        }
    }
}
