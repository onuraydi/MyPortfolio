using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices;
using System.Net.Http.Json;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices
{
    public class PortfolioBlogService : IPortfolioBlogService
    {
        private readonly HttpClient _httpClient;
        //private readonly IPortfolioBlogTagServices _portfolioBlogTagServices;

        public PortfolioBlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreatePortfolioBlogDto> CreatePortfolioBlogAsync(CreatePortfolioBlogDto createPortfolioBlogDto)
        {
            try
            {
                var responseMessage = await _httpClient.PostAsJsonAsync("portfolioblogs", new
                {
                    Title = createPortfolioBlogDto.Title,
                    SubContent = createPortfolioBlogDto.SubContent,
                    Content = createPortfolioBlogDto.Content,
                    CoverImage = createPortfolioBlogDto.CoverImage,
                    PublishDate = createPortfolioBlogDto.PublishDate,
                    isSuggested = createPortfolioBlogDto.isSuggested,
                    TagIds = createPortfolioBlogDto.TagIds,
                    CategoryIds = createPortfolioBlogDto.CategoryIds
                });

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var errorContent = await responseMessage.Content.ReadAsStringAsync();
                    throw new Exception($"API hatası: {errorContent}");
                }

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return createPortfolioBlogDto; // Orijinal DTO'yu geri dön
            }
            catch (Exception ex)
            {
                throw new Exception($"Blog oluşturma hatası: {ex.Message}");
            }
        }

        public async Task DeletePortfolioBlogAsync(int id)
        {
            await _httpClient.DeleteAsync("portfolioblogs?id=" + id);
        }

        public async Task<List<GetAllPortfolioBlogDto>> GetAllPortfolioBlogAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogs");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllPortfolioBlogDto>>(jsonData);
            return values;
        }

        public async Task<GetPortfolioBlogByPortfolioBlogIdDto> GetPortfolioBlogByPortfolioBlogIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogs/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetPortfolioBlogByPortfolioBlogIdDto>();
            return values;
        }

        public async Task<List<GetAllPortfolioBlogDto>> GetSuggestedPortfolioBlog()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioblogs/GetSuggestedPortfolioBlog");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllPortfolioBlogDto>>(jsonData);
            return values;
        }

        public async Task MarkSuggested(int id)
        {
            await _httpClient.GetAsync("portfolioblogs/markSuggested/" + id);
        }

        public async Task UpdatePortfolioBlogAsync(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            try
            {
                var responseMessage = await _httpClient.PutAsJsonAsync("portfolioblogs", new
                {
                    PortfolioBlogId = updatePortfolioBlogDto.PortfolioBlogId,
                    Title = updatePortfolioBlogDto.Title,
                    SubContent = updatePortfolioBlogDto.SubContent,
                    Content = updatePortfolioBlogDto.Content,
                    CoverImage = updatePortfolioBlogDto.CoverImage,
                    PublishDate = updatePortfolioBlogDto.PublishDate,
                    isSuggested = updatePortfolioBlogDto.isSuggested,
                    TagIds = updatePortfolioBlogDto.TagIds,
                    CategoryIds = updatePortfolioBlogDto.CategoryIds
                });

                if (!responseMessage.IsSuccessStatusCode)
                {
                    var errorContent = await responseMessage.Content.ReadAsStringAsync();
                    throw new Exception($"API hatası: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Blog güncelleme hatası: {ex.Message}");
            }
        }
    }
}
