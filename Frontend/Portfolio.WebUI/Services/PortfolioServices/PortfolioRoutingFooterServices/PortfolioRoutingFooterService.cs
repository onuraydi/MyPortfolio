using Portfolio.DtoLayer.PortfolioDtos.PortfolioRoutingFooterDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioRoutingFooterServices
{
    public class PortfolioRoutingFooterService : IPortfolioRoutingFooterService
    {
        private readonly HttpClient _httpClient;

        public PortfolioRoutingFooterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioRoutingFooterDto(CreatePortfolioRoutingFooterDto createPortfolioRoutingFooterDto)
        {
            await _httpClient.PostAsJsonAsync("portfolioroutingfooters", createPortfolioRoutingFooterDto);
        }

        public async Task DeletePortfolioRoutingFooterDto(int id)
        {
            await _httpClient.DeleteAsync("portfolioroutingfooters?id=" + id);
        }

        public async Task<List<GetAllPortfolioRoutingFooterDto>> GetAllPortfolioRoutingFooterAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioroutingfooters");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetAllPortfolioRoutingFooterDto>>();
            return values;
        }

        public async Task<GetPortfolioRoutingFooterByPortfolioRoutingFooterIdDto> GetPortfolioRoutingFooterByPortfolioRoutingFooterIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioroutingfooters/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioRoutingFooterByPortfolioRoutingFooterIdDto>();
            return values;
        }

        public async Task UpdatePortfolioRoutingFooterDto(UpdatePortfolioRoutingFooterDto updatePortfolioRoutingFooterDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioroutingfooters", updatePortfolioRoutingFooterDto);
        }
    }
}
