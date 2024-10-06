using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioTechnologyServices;

namespace Portfolio.WebUI.ViewComponents.TechnologiesViewComponents
{
    public class _TechnologiesViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioTechnologyService _portfolioTechnologyService;

        public _TechnologiesViewComponentPartial(IPortfolioTechnologyService portfolioTechnologyService)
        {
            _portfolioTechnologyService = portfolioTechnologyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioTechnologyService.GetAllPortfolioTechnologyAsync();
            return View(values);
        }
    }
}
