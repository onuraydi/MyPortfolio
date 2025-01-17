using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioSocialMediaFooterServices;

namespace Portfolio.WebUI.ViewComponents.UILayoutComponents
{
    public class _FooterUILayoutComponentPartial:ViewComponent
    {
        private readonly IPortfolioSocialMediaFooterService _portfolioSocialMediaFooterService;

        public _FooterUILayoutComponentPartial(IPortfolioSocialMediaFooterService portfolioSocialMediaFooterService)
        {
            _portfolioSocialMediaFooterService = portfolioSocialMediaFooterService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioSocialMediaFooterService.GetAllPortfolioSocialMediaFooterAsync();
            return View(values);
        }
    }
}
