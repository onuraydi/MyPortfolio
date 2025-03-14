﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.PortfolioProjectFooterDtos;
using MyPortfolio.WebApi.Services.PortfolioProjectFooterServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioProjectFootersController : ControllerBase
    {
        private readonly IPortfolioProjectFooterService _portfolioProjectFooterService;

        public PortfolioProjectFootersController(IPortfolioProjectFooterService portfolioProjectFooterService)
        {
            _portfolioProjectFooterService = portfolioProjectFooterService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioProjectFooter()
        {
            var values = await _portfolioProjectFooterService.GetAllPortfolioProjectFooterAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioProjectFooterByPortfolioProjectFooterId(int id)
        {
            var values = await _portfolioProjectFooterService.GetPortfolioProjectFooterByPortfolioProjectFooterIdAsync(id);
            return Ok(values);
        }

      
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioProjectFooter(CreatePortfolioProjectFooterDto createPortfolioProjectFooterDto)
        {
            await _portfolioProjectFooterService.CreatePortfolioProjectFooterAsync(createPortfolioProjectFooterDto);
            return Ok("Ekleme işlemi başarılı");
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdatePortfolioProjectFooter(UpdatePortfolioProjectFooterDto updatePortfolioProjectFooterDto)
        {
            await _portfolioProjectFooterService.UpdatePortfolioProjectFooterAsync(updatePortfolioProjectFooterDto);
            return Ok("Güncelleme işlemi başarılı");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolioProjectFooter(int id)
        {
            await _portfolioProjectFooterService.DeletePortfolioProjectFooterAsync(id);
            return Ok("Silme işlemi başarılı");
        }
    }
}
