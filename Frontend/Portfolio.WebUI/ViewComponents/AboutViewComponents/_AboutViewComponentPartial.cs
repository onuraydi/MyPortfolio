using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioAboutMeServices;

namespace Portfolio.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioAboutMeService _portfolioAboutMeService;

        public _AboutViewComponentPartial(IPortfolioAboutMeService portfolioAboutMeService)
        {
            _portfolioAboutMeService = portfolioAboutMeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioAboutMeService.GetPortfolioAboutMeAsync();
            return View(values);
        }
    }
}
