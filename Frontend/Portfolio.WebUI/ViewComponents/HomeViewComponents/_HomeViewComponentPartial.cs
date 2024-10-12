using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioMainTitleServices;

namespace Portfolio.WebUI.ViewComponents.HomeViewComponents
{
    public class _HomeViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioMainTitleService _portfolioMainTitleService;

        public _HomeViewComponentPartial(IPortfolioMainTitleService portfolioMainTitleService)
        {
            _portfolioMainTitleService = portfolioMainTitleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioMainTitleService.GetPortfolioMainTitleAsync();
            return View(values);
        }

    }
}
