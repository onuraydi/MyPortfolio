using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.BlogCategoryDtos;
using Portfolio.WebUI.Services.PortfolioServices.BlogCategoryServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("Admin/BlogCategory")]
    public class BlogCategoryController : Controller
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogCategoryController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        [HttpGet]
        [Route("GetAllPortfolioBlogCategories")]
        public async Task<IActionResult> GetAllPortfolioBlogCategories()
        {
            var values = await _blogCategoryService.GetAllPortfolioBlogCategoryAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioBlogCategory")]
        public IActionResult CreatePortfolioBlogCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePortfolioBlogCategory")]
        public async Task<IActionResult> CreatePortfolioBlogCategory(CreateBlogCategoryDto createBlogCategoryDto)
        {
            await _blogCategoryService.CreatePortfolioBlogCategoryAsync(createBlogCategoryDto);
            return RedirectToAction("GetAllPortfolioBlogCategories", "BlogCategory", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdatePortfolioBlogCategory/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlogCategory(int id)
        {
            var values = await _blogCategoryService.GetPortfolioBlogCategoryByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioBlogCategory/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlogCategory(GetBlogCategoryDto getBlogCategoryDto)
        {
            await _blogCategoryService.UpdatePortfolioBlogCategoryAsync(getBlogCategoryDto);
            return RedirectToAction("GetAllPortfolioBlogCategories", "BlogCategory", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioBlogCategory/{id}")]
        public async Task<IActionResult> DeletePortfolioBlogCategory(int id)
        {
            await _blogCategoryService.DeleteCategoryAsync(id);
            return RedirectToAction("GetAllPortfolioBlogCategories", "BlogCategory", new { area = "Admin" });
        }
    }
}
