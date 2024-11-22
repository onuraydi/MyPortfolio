using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices
{
    public class PortfolioBlogService : IPortfolioBlogService
    {
        private readonly HttpClient _httpClient;

        public PortfolioBlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioBlogAsync(CreatePortfolioBlogDto createPortfolioBlogDto)
        {
            await _httpClient.PostAsJsonAsync("portfolioblogs", createPortfolioBlogDto);
        }

        public async Task DeletePortfolioBlogAsync(int id)
        {
            await _httpClient.DeleteAsync("portfolioblogs?id=" + id);
        }

        public async Task<List<GetAllPortfolioBlogDto>> GetAllPortfolioBlogAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogs");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllPortfolioBlogDto>>(jsonData);
            return values;
        }

        public async Task<GetPortfolioBlogByPortfolioBlogIdDto> GetPortfolioBlogByPortfolioBlogIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogs/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioBlogByPortfolioBlogIdDto>();
            return values;
        }

        public async Task UpdatePortfolioBlogAsync(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioblogs", updatePortfolioBlogDto);
        }
    }
}
