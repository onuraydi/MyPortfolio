using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioMainTitleDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioMainTitleServices
{
    public class PortfolioMainTitleService : IPortfolioMainTitleService
    {
        private readonly HttpClient _httpClient;

        public PortfolioMainTitleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetPortfolioMainTitleDto>> GetPortfolioMainTitleAsync()
        {
            var responseMessage = await _httpClient.GetAsync("PortfolioMainTitles");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetPortfolioMainTitleDto>>(jsonData);
            return values;
        }

        public async Task<GetPortfolioMainTitleByPortfolioMainTitleIdDto> GetPortfolioMainTitleByPortfolioMainTitleIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfoliomaintitles/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioMainTitleByPortfolioMainTitleIdDto>();
            return values;
        }

        public async Task UpdatePortfolioMainTitleAsync(UpdatePortfolioMainTitleDto updatePortfolioMainTitleDto)
        {
            await _httpClient.PutAsJsonAsync("portfoliomaintitles", updatePortfolioMainTitleDto);
        }
    }
}
