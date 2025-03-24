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
            var id = ViewData["id"];
            if (id == null)
            {
                return View();
            }
            var values = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(Convert.ToInt32(id));
            return View(values);
        }
    }
}
