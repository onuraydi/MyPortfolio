using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Dtos.BlogCategoryDtos;
using MyPortfolio.WebApi.Services.BlogCategoryServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController : ControllerBase
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogCategoriesController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBlogCategory()
        {
            var values = await _blogCategoryService.GetAllBlogCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogCategoryById(int id)
        {
            var values = await _blogCategoryService.GetBlogCategoryByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(AddBlogCategoryDto addBlogCategoryDto)
        {
            await _blogCategoryService.CreateBlogCategoryAsync(addBlogCategoryDto);
            return Ok("Kategori ekleme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlogCategory(GetBlogCategoryDto getBlogCategoryDto)
        {
            await _blogCategoryService.UpdateBlogCategoryAsync(getBlogCategoryDto);
            return Ok("Kategori güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogCategory(int id)
        {
            await _blogCategoryService.DeleteBlogCategoryAsync(id);
            return Ok("Kategori silme işlemi başarılı");
        }
    }
}
