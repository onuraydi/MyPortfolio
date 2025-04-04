﻿using MyPortfolio.WebApi.Dtos.PortfolioProjectDtos;
using MyPortfolio.WebApi.Dtos.ProjectImageDtos;

namespace MyPortfolio.WebApi.Services.PortfolioProjectServices
{
    public interface IPortfolioProjectService
    {
        Task<List<GetAllPortfolioProjectDto>> GetAllPortfolioProjectAsync();
        Task CreatePortfolioProjectAsync(CreatePortfolioProjectDto createPortfolioProjectDto);
        Task UpdatePortfolioProjectAsync(UpdatePortfolioProjectDto updatePortfolioProjectDto);
        Task DeletePortfolioProjectAsync(int id);
        Task<GetPortfolioProjectByPortfolioProjectIdDto> GetAllPortfolioProjectByPortfolioProjectIdAsync(int id);
    }
}
