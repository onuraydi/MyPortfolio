using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioAboutMeDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioAboutMeServices
{
    public class PortfolioAboutMeService : IPortfolioAboutMeService
    {
        private readonly HttpClient _httpClient;

        public PortfolioAboutMeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetPortfolioAboutMeDto> GetPortfolioAboutMeAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioaboutmeapi");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetPortfolioAboutMeDto>(jsonData);
            return values;
        }

        public async Task<GetPortfolioAboutMeByPortfolioAboutMeIdDto> GetPortfolioAboutMeByPortfolioAboutMeIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioaboutmeapi/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioAboutMeByPortfolioAboutMeIdDto>();
            return values;
        }

        public async Task UpdatePortfolioAboutMeAsync(UpdatePortfolioAboutMeDto updatePortfolioAboutMeDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioaboutmeapi", updatePortfolioAboutMeDto);
        }
    }
}
