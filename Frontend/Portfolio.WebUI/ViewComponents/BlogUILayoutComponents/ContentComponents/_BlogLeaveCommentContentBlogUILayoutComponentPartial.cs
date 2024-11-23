using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogCommentDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogLeaveCommentContentBlogUILayoutComponentPartial:ViewComponent
    {
        private readonly IPortfolioBlogCommentService _portfolioBlogCommentService;

        public _BlogLeaveCommentContentBlogUILayoutComponentPartial(IPortfolioBlogCommentService portfolioBlogCommentService)
        {
            _portfolioBlogCommentService = portfolioBlogCommentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CreatePortfolioBlogCommentDto createPortfolioBlogCommentDto)
        {
            await _portfolioBlogCommentService.CreatePortfolioBlogCommentAsync(createPortfolioBlogCommentDto);
            return View();
        }
    }
}
