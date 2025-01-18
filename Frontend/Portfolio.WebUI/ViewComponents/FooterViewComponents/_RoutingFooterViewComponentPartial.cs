using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioRoutingFooterServices;

namespace Portfolio.WebUI.ViewComponents.FooterViewComponents
{
    public class _RoutingFooterViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioRoutingFooterService _portfolioRoutingFooterService;

        public _RoutingFooterViewComponentPartial(IPortfolioRoutingFooterService portfolioRoutingFooterService)
        {
            _portfolioRoutingFooterService = portfolioRoutingFooterService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioRoutingFooterService.GetAllPortfolioRoutingFooterAsync();
            return View(values);
        }
    }
}
