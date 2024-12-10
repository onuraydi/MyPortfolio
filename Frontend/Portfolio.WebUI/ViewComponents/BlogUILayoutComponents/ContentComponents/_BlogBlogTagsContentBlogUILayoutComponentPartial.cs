using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogBlogTagsContentBlogUILayoutComponentPartial:ViewComponent
    {
        private readonly IPortfolioBlogTagServices _portfolioBlogTagServices;
        public _BlogBlogTagsContentBlogUILayoutComponentPartial(IPortfolioBlogTagServices portfolioBlogTagServices)
        {
            _portfolioBlogTagServices = portfolioBlogTagServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioBlogTagServices.GetAllPortfolioBlogTagAsync();
            return View(values);
        }
    }
}
