using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioExperineceDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioExperienceServices
{
    public class PortfolioExperienceService : IPortfolioExperienceService
    {
        private readonly HttpClient _httpClient;

        public PortfolioExperienceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioExperienceAsync(CreatePortfolioExperienceDto createPortfolioExperienceDto)
        {
            await _httpClient.PostAsJsonAsync("portfolioexperiences",createPortfolioExperienceDto);
        }

        public async Task DeletePortfolioExperienceAsync(int id)
        {
            await _httpClient.DeleteAsync("portfolioexperiences?id=" + id); 
        }

        public async Task<List<GetAllPortfolioExperienceDto>> GetAllPortfolioExperienceAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioexperiences");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllPortfolioExperienceDto>>(jsonData);
            return values;
        }

        public async Task<GetPortfolioExperienceByPortfolioExperienceIdDto> GetPortfolioExperienceByPortfolioExperienceIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioexperiences/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioExperienceByPortfolioExperienceIdDto>();
            return values;
        }

        public async Task UpdatePortfolioExperienceAsync(UpdatePortfolioExperienceDto updatePortfolioExperienceDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioexperiences", updatePortfolioExperienceDto);
        }
    }
}
