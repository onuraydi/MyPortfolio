﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioMainTitleDtos;
using MyPortfolio.WebApi.Services.PortfolioMainTitleServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioMainTitlesController : ControllerBase
    {
        private readonly IPortfolioMainTitleService _portfolioMainTitleService;

        public PortfolioMainTitlesController(IPortfolioMainTitleService portfolioMainTitleService)
        {
            _portfolioMainTitleService = portfolioMainTitleService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPortfolioMainTitle()
        {
            var values = await _portfolioMainTitleService.GetPortfolioMainTitleAsync();
            return Ok(values);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioMainTitleByPortfolioMainTitleId(int id)
        {
            var values = await _portfolioMainTitleService.GetPortfolioMainTitleByPortfolioMainTitleIdAsync(id);
            return Ok(values);
        }
       
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioMainTitle(UpdatePortfoiloMainTitleDto updatePortfoiloMainTitleDto)
        {
            await _portfolioMainTitleService.UpdatePortfolioMainTitleAsync(updatePortfoiloMainTitleDto);
            return Ok("Ana başlığı güncelleme işlemi başarılı");
        }
    }
}
