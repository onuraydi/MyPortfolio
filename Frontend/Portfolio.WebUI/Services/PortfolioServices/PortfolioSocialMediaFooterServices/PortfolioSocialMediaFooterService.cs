using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioSocialMediaFooterDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioSocialMediaFooterServices
{
    public class PortfolioSocialMediaFooterService : IPortfolioSocialMediaFooterService
    {
        private readonly HttpClient _httpClient;

        public PortfolioSocialMediaFooterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioSocialMediaFooterAsync(CreatePortfolioSocialMediaFooterDto createPortfolioSocialMediaFooterDto)
        {
            await _httpClient.PostAsJsonAsync("portfoliosocialmediafooters", createPortfolioSocialMediaFooterDto);
        }

        public async Task DeletePortfolioSocialMediaFooterAsync(int id)
        {
            await _httpClient.DeleteAsync("portfoliosocialmediafooters?id=" + id);
        }

        public async Task<List<GetAllPortfolioSocialMediaFooterDto>> GetAllPortfolioSocialMediaFooterAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfoliosocialmediafooters");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllPortfolioSocialMediaFooterDto>>(jsonData);
            return values;
        }

        public async Task<GetPortfolioSocilaMediaFooterByIdDto> GetPortfolioSocilaMediaFooterByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfoliosocialmediafooters/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetPortfolioSocilaMediaFooterByIdDto>(jsonData);
            return values;
        }

        public async Task UpdatePortfolioSocialMediaFooterAsync(UpdatePortfolioSocialMediaFooterDto updatePortfolioSocialMediaFooterDto)
        {
            await _httpClient.PutAsJsonAsync("portfoliosocialmediafooters", updatePortfolioSocialMediaFooterDto);
        }
    }
}
