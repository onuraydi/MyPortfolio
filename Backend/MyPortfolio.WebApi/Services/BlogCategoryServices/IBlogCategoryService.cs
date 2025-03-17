using MyPortfolio.WebApi.Dtos.BlogCategoryDtos;

namespace MyPortfolio.WebApi.Services.BlogCategoryServices
{
    public interface IBlogCategoryService
    {
        Task<List<GetBlogCategoryDto>> GetAllBlogCategoryAsync();
        Task CreateBlogCategoryAsync(AddBlogCategoryDto addBlogCategoryDto);
        Task UpdateBlogCategoryAsync(GetBlogCategoryDto getBlogCategoryDto);
        Task<GetBlogCategoryDto> GetBlogCategoryByIdAsync(int id);
        Task DeleteBlogCategoryAsync(int id);
    }
}
