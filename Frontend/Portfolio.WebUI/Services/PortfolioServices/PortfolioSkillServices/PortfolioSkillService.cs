using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioSkillDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioSkillServices
{
    public class PortfolioSkillService : IPortfolioSkillService
    {
        private readonly HttpClient _httpClient;

        public PortfolioSkillService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioSkillAsync(CreatePortfolioSkillDto createPortfolioSkillDto)
        {
            await _httpClient.PostAsJsonAsync("portfolioskills", createPortfolioSkillDto);
        }

        public async Task DeletePortfolioSkillAsync(int id)
        {
            await _httpClient.DeleteAsync("portfolioskills?id=" + id);
        }

        public async Task<List<GetAllPortfolioSkillDto>> GetAllPortfolioSkillAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioskills");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllPortfolioSkillDto>>(jsonData);
            return values;
        }

        public async Task<GetPortfolioSkillByPortfolioSkillIdDto> GetPortfolioSkillByPortfolioSkillIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioskills/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioSkillByPortfolioSkillIdDto>();
            return values;
        }

        public async Task UpdatePortfolioSkillAsync(UpdatePortfolioSkillDto updatePortfolioSkillDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioskills", updatePortfolioSkillDto);
        }
    }
}
