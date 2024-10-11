using Portfolio.DtoLayer.PortfolioDtos.PortfolioContactDtos;
using System.Net.Http.Json;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioContactServices
{
    public class PortfolioContactService : IPortfolioContactService
    {
        private readonly HttpClient _httpClient;

        public PortfolioContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioContactAsync(CreatePortfolioContactDto createPortfolioContactDto)
        {
            await _httpClient.PostAsJsonAsync("portfoliocontacts", createPortfolioContactDto);
        }

        public async Task DeletePortfolioContactAsync(int id)
        {
            await _httpClient.DeleteAsync("portfoliocontacts?id="+id);
        }

        public async Task<List<GetAllPortfolioContactDto>> GetAllPortfolioContactAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfoliocontacts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetAllPortfolioContactDto>>();
            return values;
        }

        public async Task<GetPortfolioContactByPortfolioContactIdDto> GetPortfolioContactByPortfolioContactIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfoliocontacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioContactByPortfolioContactIdDto>();
            return values;
        }

        public async Task MarkAsNotRead(int id)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync($"portfoliocontacts/MarkAsNotRead/{id}",id);
        }

        public async Task MarkAsRead(int id)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync($"portfoliocontacts/MarkAsRead/{id}", id);
        }

        public async Task UpdatePortfolioContactAsync(UpdatePortfolioContactDto updatePortfolioContactDto)
        {
            await _httpClient.PutAsJsonAsync("portfoliocontacts", updatePortfolioContactDto);
        }
    }
}
