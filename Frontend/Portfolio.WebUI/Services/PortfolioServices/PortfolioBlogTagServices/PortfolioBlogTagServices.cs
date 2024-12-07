using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices
{
    public class PortfolioBlogTagServices : IPortfolioBlogTagServices
    {
        private readonly HttpClient _httpClient;
        public PortfolioBlogTagServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioBlogTagAsync(CreatePortfolioBlogTagDto createPortfolioBlogTagDto)
        {
            await _httpClient.PostAsJsonAsync("portfolioblogtags",createPortfolioBlogTagDto);
        }

        public async Task DeletePortfolioBlogTagAsync(int id)
        {
            await _httpClient.DeleteAsync("portfolioblogtags?id=" + id);
        }

        public async Task<List<GetAllPortfolioBlogTagDto>> GetAllPortfolioBlogTagAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogtags");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetAllPortfolioBlogTagDto>>();
            return values;
        }

        public async Task<GetPortfolioBlogTagByPortfolioBlogTagIdDto> GetPortfolioBlogTagByPortfolioBlogTagIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogtags/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioBlogTagByPortfolioBlogTagIdDto>();
            return values;
        }

        public async Task<List<GetPortfolioBlogsByPortfolioTagId>> GetPortfolioBlogTagsByPortfolioBlogTagIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogtags/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetPortfolioBlogsByPortfolioTagId>>();
            return values;
        }

        public async Task UpdatePortfolioBlogTagAsync(UpdatePortfolioBlogTagDto updatePortfolioBlogTagDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioblogtags", updatePortfolioBlogTagDto);
        }
    }
}
