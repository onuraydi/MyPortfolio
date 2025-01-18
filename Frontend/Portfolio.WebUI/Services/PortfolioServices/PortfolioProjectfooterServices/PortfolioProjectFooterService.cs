using Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectFooterDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectfooterServices
{
    public class PortfolioProjectFooterService : IPortfolioProjectFooterService
    {
        private readonly HttpClient _httpClient;

        public PortfolioProjectFooterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioProjectFooterAsync(CreatePortfolioProjectFooterDto createPortfolioProjectFooterDto)
        {
            await _httpClient.PostAsJsonAsync("portfolioprojectfooters", createPortfolioProjectFooterDto);
        }

        public async Task DeletePortfolioProjectFooterAsync(int id)
        {
            await _httpClient.DeleteAsync("portfolioprojectfooters?id=" + id);
        }

        public async Task<List<GetAllPortfolioProjectFooterDto>> GetAllPortfolioProjectFooterAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioprojectfooters");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetAllPortfolioProjectFooterDto>>();
            return values;
        }

        public async Task<GetPortfollioProjectFooterByPortfolioProjectFooterIdDto> GetPortfollioProjectFooterByPortfolioProjectFooterIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioprojectfooters/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfollioProjectFooterByPortfolioProjectFooterIdDto>();
            return values;
        }

        public async Task UpdatePortfolioProjectFooterAsync(UpdatePortfolioProjectFooterDto updatePortfolioProjectFooterDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioprojectfooters", updatePortfolioProjectFooterDto);
        }
    }
}
