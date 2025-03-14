﻿using Newtonsoft.Json;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices;

namespace Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices
{
    public class PortfolioBlogService : IPortfolioBlogService
    {
        private readonly HttpClient _httpClient;
        private readonly IPortfolioBlogTagServices _portfolioBlogTagServices;

        public PortfolioBlogService(HttpClient httpClient, IPortfolioBlogTagServices portfolioBlogTagServices)
        {
            _httpClient = httpClient;
            _portfolioBlogTagServices = portfolioBlogTagServices;
        }

        public async Task<CreatePortfolioBlogDto> CreatePortfolioBlogAsync(CreatePortfolioBlogDto createPortfolioBlogDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("portfolioblogs", createPortfolioBlogDto);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<CreatePortfolioBlogDto>(jsonData);
            return values;
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
            var tagValues = await _portfolioBlogTagServices.GetPortfolioBlogTagsByPortfolioBlogIdAsync(id);
            values.PortfolioBlogTags.AddRange(tagValues.PortfolioBlogTags);
            return values;
        }

        public async Task UpdatePortfolioBlogAsync(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            await _httpClient.PutAsJsonAsync("portfolioblogs", updatePortfolioBlogDto);
        }
    }
}
