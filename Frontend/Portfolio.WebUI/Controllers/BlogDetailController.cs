using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogCommentDtos;
using Portfolio.WebUI.Models;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;

namespace Portfolio.WebUI.Controllers
{
    public class BlogDetailController : Controller
    {
        //private readonly IPortfolioBlogService _portfolioBlogService;
        private readonly IPortfolioBlogCommentService _portfolioBlogCommentService;


        public BlogDetailController(IPortfolioBlogCommentService portfolioBlogCommentService)
        {
            _portfolioBlogCommentService = portfolioBlogCommentService;
        }

        public async Task<IActionResult> GetBlogDetail(int id,BlogsViewModel blogsView)
        {

            ViewBag.id = id;
            var values = await _portfolioBlogCommentService.GetPortfolioBlogCommentByPortfolioBlogIdAsync(id);
            var blogsViewModel = new BlogsViewModel()
            {
                BlogComments = values,
            };

            ViewData["id"] = id;
            
            return View(blogsViewModel);
        }

        public async Task<IActionResult> AddComment(int id, BlogsViewModel blogsView)
        {
            ViewBag.id = id;
            var values = await _portfolioBlogCommentService.CreatePortfolioBlogCommentAsync(blogsView.CreateComment);
            var blogsViewModel = new BlogsViewModel()
            {
                CreateComment = values
            };
            ViewData["id"] = blogsView.CreateComment.portfolioBlogId;
            return RedirectToAction("GetBlogDetail", new { id = blogsView.CreateComment.portfolioBlogId });
        }
    }
}
