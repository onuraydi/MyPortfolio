using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioFreelanceDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioFreelanceServices
{
    public class PortfolioFreelanceService : IPortfolioFreelanceService
    {
        private readonly HttpClient _httpClient;

        public PortfolioFreelanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioFreelanceAsync(CreatePortfolioFreelanceDto createPortfolioFreelanceDto)
        {
            await _httpClient.PostAsJsonAsync("portfoliofreelances",createPortfolioFreelanceDto);
        }

        public async Task DeletePortfolioFreelanceAsync(int id)
        {
            await _httpClient.DeleteAsync("portfoliofreelances?id=" + id);
        }

        public async Task<List<GetAllPortfolioFreelanceDto>> GetAllPortfolioFreelanceAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfoliofreelances");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetAllPortfolioFreelanceDto>>();
            return values;
        }

        public async Task<GetPortfolioFreelanceByPortfolioFreelanceIdDto> GetPortfolioFreelanceByPortfolioFreelanceIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfoliofreelances/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioFreelanceByPortfolioFreelanceIdDto>();
            return values;
        }

        public async Task UpdatePortfolioFreelanceAsync(UpdatePortfolioFreelanceDto updatePortfolioFreelanceDto)
        {
            await _httpClient.PutAsJsonAsync("portfoliofreelances", updatePortfolioFreelanceDto);
        }
    }
}
