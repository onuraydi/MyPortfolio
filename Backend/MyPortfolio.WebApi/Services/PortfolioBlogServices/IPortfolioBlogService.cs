﻿using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;

namespace MyPortfolio.WebApi.Services.PortfolioBlogServices
{
    public interface IPortfolioBlogService
    {
        Task<List<GetAllPortfolioBlogDto>> GetAllPortfolioBlogAsync(string query = "");
        Task<CreatePortfolioBlogDto> CreatePortfolioBlogAsync(CreatePortfolioBlogDto createPortfolioBlogDto);
        Task UpdatePortfolioBlogAsync(UpdatePortfolioBlogDto updatePortfolioBlogDto);
        Task DeletePortfolioBlogAsync(int id);
        Task<GetPortfolioBlogByPortfolioBlogIdDto> GetPortfolioBlogByPortfolioBlogIdAsync(int id);
        Task MarkSuggested(int id);
        Task<List<GetAllPortfolioBlogDto>> GetSuggestedPortfolioBlog();
    }
}
