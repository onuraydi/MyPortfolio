using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioSocialMediaFooterServices;

namespace Portfolio.WebUI.ViewComponents.FooterViewComponents
{
    public class _SocialMediaFooterViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioSocialMediaFooterService _portfolioSocialMediaFooterService;

        public _SocialMediaFooterViewComponentPartial(IPortfolioSocialMediaFooterService portfolioSocialMediaFooterService)
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
