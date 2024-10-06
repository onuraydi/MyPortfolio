using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioTechnologyDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioTechnologyServices
{
    public class PortfolioTechnologyService : IPortfolioTechnologyService
    {
        private readonly HttpClient _httpClient;

        public PortfolioTechnologyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioTechnologyAsync(CreatePortfolioTechnologyDto createPortfolioTechnologyDto)
        {
            await _httpClient.PostAsJsonAsync("portfoliotechnologies", createPortfolioTechnologyDto);
        }

        public async Task DeletePortfolioTechnologyAsync(int id)
        {
            await _httpClient.DeleteAsync("portfoliotechnologies?id=" + id);
        }

        public async Task<List<GetAllPortfolioTechnologyDto>> GetAllPortfolioTechnologyAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfoliotechnologies");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllPortfolioTechnologyDto>>(jsonData);
            return values;
        }

        public async Task<GetPortfolioTechnologyByPortfolioTechnologyIdDto> GetPortfolioTechnologyByPortfolioTechnologyIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfoliotechnologies/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioTechnologyByPortfolioTechnologyIdDto>();
            return values;
        }

        public async Task UpdatePortfolioTechnologyAsync(UpdatePortfolioTechnologyDto updatePortfolioTechnologyDto)
        {
            await _httpClient.PutAsJsonAsync("portfoliotechnologies", updatePortfolioTechnologyDto);
        }
    }
}
