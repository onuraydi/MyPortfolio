using Portfolio.DtoLayer.PortfolioDtos.BlogCategoryDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.BlogCategoryServices
{
    public interface IBlogCategoryService
    {
        Task<List<GetBlogCategoryDto>> GetAllPortfolioBlogCategoryAsync();
        Task CreatePortfolioBlogCategoryAsync(CreateBlogCategoryDto createBlogCategoryDto);
        Task UpdatePortfolioBlogCategoryAsync(GetBlogCategoryDto getBlogCategoryDto);
        Task<GetBlogCategoryDto> GetPortfolioBlogCategoryByIdAsync(int id);
        Task DeleteCategoryAsync(int id);
        // Categoriye göre blog getirme olacak
    }
}
