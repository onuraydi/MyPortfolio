using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogContentContentBlogUILayoutComponentPartial:ViewComponent
    {
        private readonly IPortfolioBlogService _portfolioBlogService;

        public _BlogContentContentBlogUILayoutComponentPartial(IPortfolioBlogService portfolioBlogService)
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
