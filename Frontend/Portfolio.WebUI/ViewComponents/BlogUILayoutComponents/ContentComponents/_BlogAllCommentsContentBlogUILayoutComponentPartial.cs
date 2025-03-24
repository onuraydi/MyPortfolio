using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogAllCommentsContentBlogUILayoutComponentPartial:ViewComponent
    {
        private readonly IPortfolioBlogCommentService _portfolioBlogCommentService;

        public _BlogAllCommentsContentBlogUILayoutComponentPartial(IPortfolioBlogCommentService portfolioBlogCommentService)
        {
            _portfolioBlogCommentService = portfolioBlogCommentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = ViewData["id"];
            var values = await _portfolioBlogCommentService.GetPortfolioBlogCommentByPortfolioBlogIdAsync(Convert.ToInt32(id));
            return View(values);
        }
    }
}
