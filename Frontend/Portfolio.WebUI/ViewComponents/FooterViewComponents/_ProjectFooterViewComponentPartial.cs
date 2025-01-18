using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectfooterServices;

namespace Portfolio.WebUI.ViewComponents.FooterViewComponents
{
    public class _ProjectFooterViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioProjectFooterService _portfolioProjectFooterService;

        public _ProjectFooterViewComponentPartial(IPortfolioProjectFooterService portfolioProjectFooterService)
        {
            _portfolioProjectFooterService = portfolioProjectFooterService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioProjectFooterService.GetAllPortfolioProjectFooterAsync();
            return View(values);
        }
    }
}
