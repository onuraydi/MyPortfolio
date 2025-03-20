using Portfolio.DtoLayer.PortfolioDtos.BlogCategoryDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.BlogCategoryServices
{
    public class BlogCategoryService:IBlogCategoryService
    {
        private readonly HttpClient _httpClient;

        public BlogCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioBlogCategoryAsync(CreateBlogCategoryDto createBlogCategoryDto)
        {
            await _httpClient.PostAsJsonAsync("BlogCategories", createBlogCategoryDto);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _httpClient.DeleteAsync("BlogCategories/" + id);
        }

        public async Task<List<GetBlogCategoryDto>> GetAllPortfolioBlogCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("BlogCategories");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetBlogCategoryDto>>();
            return values;
        }

        public async Task<GetBlogCategoryDto> GetPortfolioBlogCategoryByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("BlogCategories/"+id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetBlogCategoryDto>();
            return value;
        }

        public async Task UpdatePortfolioBlogCategoryAsync(GetBlogCategoryDto getBlogCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("BlogCategories", getBlogCategoryDto);
        }
    }
}
