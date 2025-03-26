using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;

namespace Portfolio.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioBlogService _portfolioBlogService;

        public _BlogViewComponentPartial(IPortfolioBlogService portfolioBlogService)
        {
            _portfolioBlogService = portfolioBlogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioBlogService.GetSuggestedPortfolioBlog();
            return View(values);
        }
    }
}
