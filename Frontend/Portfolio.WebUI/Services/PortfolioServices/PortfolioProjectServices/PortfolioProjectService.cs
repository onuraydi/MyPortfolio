using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectDtos;
using Portfolio.DtoLayer.PortfolioDtos.ProjectImageDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectServices
{
    public class PortfolioProjectService : IPortfolioProjectService
    {
        private readonly HttpClient _httpClient;

        public PortfolioProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePortfolioProjectAsync(CreatePortfolioProjectDto createPortfolioProjectDto)
        {
            await _httpClient.PostAsJsonAsync("portfolioprojects", createPortfolioProjectDto);
        }

        public async Task DeletePortfolioProjectAsync(int id)
        {
            await _httpClient.DeleteAsync("portfolioprojects?id=" + id);
        }

        public async Task DeleteProjectImagesByProjectImageIdAsync(int id)
        {
            await _httpClient.DeleteAsync("projectimages?id=" + id);
        }

        public async Task<List<GetAllPortfolioProjectDto>> GetAllPortfolioProjectAsync()
        {
            var responseMessage = await _httpClient.GetAsync("portfolioprojects");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetAllPortfolioProjectDto>>(jsonData);
            return values;
        }

        public async Task<UpdatePortfolioProjectDto> GetAllPortfolioProjectByPortfolioProjectIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("portfolioprojects/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdatePortfolioProjectDto>();
            return values;
        }

        public async Task<List<GetProjectImageByPortfolioProjectIdDto>> GetProjectImageByPortfolioProjectIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("projectimages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetProjectImageByPortfolioProjectIdDto>>();
            return values;
        }

        public async Task UpdatePortfolioProjectAsync(UpdatePortfolioProjectDto updatePortfolioProjectDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioprojects", updatePortfolioProjectDto);
        }

        public async Task UpdateProjectImageAsync(GetProjectImageByPortfolioProjectIdDto getProjectImageByPortfolioProjectIdDto)
        {
            await _httpClient.PutAsJsonAsync("projectimages", getProjectImageByPortfolioProjectIdDto);
        }
    }
}
