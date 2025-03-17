using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.BlogCategoryDtos;
using MyPortfolio.WebApi.Entites;
using MyPortfolio.WebApi.Services.PortfolioContactServices;

namespace MyPortfolio.WebApi.Services.BlogCategoryServices
{
    public class BlogCategoryService : IBlogCategoryService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public BlogCategoryService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task CreateBlogCategoryAsync(AddBlogCategoryDto addBlogCategoryDto)
        {
            var values = _mapper.Map<BlogCategory>(addBlogCategoryDto);
            await _context.BlogCategories.AddAsync(values);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlogCategoryAsync(int id)
        {
            var values = await _context.BlogCategories.FindAsync(id);
            _context.BlogCategories.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetBlogCategoryDto>> GetAllBlogCategoryAsync()
        {
            var values = await _context.BlogCategories.ToListAsync();
            return _mapper.Map<List<GetBlogCategoryDto>>(values);
        }

        public async Task<GetBlogCategoryDto> GetBlogCategoryByIdAsync(int id)
        {
            var values = await _context.BlogCategories.FindAsync(id);
            return _mapper.Map<GetBlogCategoryDto>(values);
        }

        public async Task UpdateBlogCategoryAsync(GetBlogCategoryDto getBlogCategoryDto)
        {
            var values = _mapper.Map<BlogCategory>(getBlogCategoryDto);
            _context.BlogCategories.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
