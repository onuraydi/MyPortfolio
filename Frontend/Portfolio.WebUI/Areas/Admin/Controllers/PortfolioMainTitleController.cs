using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioMainTitleDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioMainTitleServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioMainTitle")]
    public class PortfolioMainTitleController : Controller
    {
        private readonly IPortfolioMainTitleService _portfolioMainTitleService;
        public PortfolioMainTitleController(IPortfolioMainTitleService portfolioMainTitleService)
        {
            _portfolioMainTitleService = portfolioMainTitleService;
        }

        [HttpGet]
        [Route("GetPortfolioMainTitle")]
        public async Task<IActionResult> GetPortfolioMainTitle()
        {
            var values = await _portfolioMainTitleService.GetPortfolioMainTitleAsync();
            return View(values);
        }

        [HttpGet]
        [Route("UpdatePortfolioMainTitle/{id}")]
        public async Task<IActionResult> UpdatePortfolioMainTitle(int id)
        {
            var values = await _portfolioMainTitleService.GetPortfolioMainTitleByPortfolioMainTitleIdAsync(id);
            return View(values);
        }

        [HttpPut]  // daha sonra post yapmak gerekebilir
        [Route("UpdatePortfolioMainTitle/{id}")]  // burada ID'ye gerek var mı?
        public async Task<IActionResult> UpdatePortfolioMainTitle(UpdatePortfolioMainTitleDto updatePortfolioMainTitleDto)
        {
            await _portfolioMainTitleService.UpdatePortfolioMainTitleAsync(updatePortfolioMainTitleDto);
            return RedirectToAction("GetPortfolioMainTitle","PortfolioMainTitle",new {area = "Admin"});
        }

    }
}
