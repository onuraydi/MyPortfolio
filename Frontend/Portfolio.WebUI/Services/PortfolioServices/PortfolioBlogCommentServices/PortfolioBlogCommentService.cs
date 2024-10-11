using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogCommentDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices
{
    public class PortfolioBlogCommentService : IPortfolioBlogCommentService
    {
        private readonly HttpClient _httpClient;

        public PortfolioBlogCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioBlogCommentAsync(CreatePortfolioBlogCommentDto createPortfolioBlogCommentDto)
        {
            await _httpClient.PostAsJsonAsync("portfolioblogcomments", createPortfolioBlogCommentDto);
        }

        public async Task DeletePortfolioBlogCommentAsync(int id)
        {
            await _httpClient.DeleteAsync("portfolioblogcomments?id=" + id);
        }

        public async Task<List<GetAllPortfolioBlogCommentDto>> GetAllPortfolioBlogCommentAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogcomments");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetAllPortfolioBlogCommentDto>>();
            return values;
        }

        public async Task<GetPortfolioBlogCommentByPortfolioBlogCommentIdDto> GetPortfolioBlogCommentByPortfolioBlogCommentIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogcomments/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioBlogCommentByPortfolioBlogCommentIdDto>();
            return values;
        }
    }
}
