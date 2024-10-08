using Portfolio.DtoLayer.PortfolioDtos.PortfolioEducationDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioEducationServices
{
    public class PortfolioEducationService : IPortfolioEducationService
    {
        private readonly HttpClient _httpClient;

        public PortfolioEducationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioEducationAsync(CreatePortfolioEducationDto createPortfolioEducationDto)
        {
            await _httpClient.PostAsJsonAsync("portfolioeducations", createPortfolioEducationDto);
        }

        public async Task DeletePortfolioEducationAsync(int id)
        {
            await _httpClient.DeleteAsync("portfolioeducations?id=" + id);
        }

        public async Task<List<GetAllPortfolioEducationDto>> GetAllPortfolioEducationAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioeducations");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetAllPortfolioEducationDto>>();  // refaktör gerekebilir
            return values;
        }

        public async Task<GetPortfolioEducationByPortfolioEducationDto> GetPortfolioEducationByPortfolioEducationAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioeducations/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioEducationByPortfolioEducationDto>();
            return values;
        }

        public async Task UpdatePortfolioEducationAsync(UpdatePortfolioEducationDto updatePortfolioEducationDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioeducations", updatePortfolioEducationDto);
        }
    }
}
