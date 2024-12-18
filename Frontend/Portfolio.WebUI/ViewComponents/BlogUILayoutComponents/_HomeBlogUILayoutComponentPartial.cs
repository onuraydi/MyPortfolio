using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents
{
    public class _HomeBlogUILayoutComponentPartial:ViewComponent
    {
        private readonly IPortfolioBlogService _portfolioBlogService;

        public _HomeBlogUILayoutComponentPartial(IPortfolioBlogService portfolioBlogService)
        {
            _portfolioBlogService = portfolioBlogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = Convert.ToInt32(ViewData["id"]);
            var values = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(id);
            return View(values);
        }
    }
}
