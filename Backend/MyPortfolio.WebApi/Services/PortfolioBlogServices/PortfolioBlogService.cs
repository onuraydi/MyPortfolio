using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;
using MyPortfolio.WebApi.Entites;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyPortfolio.WebApi.Services.PortfolioBlogServices
{
    public class PortfolioBlogService : IPortfolioBlogService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioBlogService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreatePortfolioBlogDto> CreatePortfolioBlogAsync(CreatePortfolioBlogDto createPortfolioBlogDto)
        {
            try
            {
                var blog = _mapper.Map<PortfolioBlog>(createPortfolioBlogDto);
                
                // Tag'leri ekle
                if (createPortfolioBlogDto.TagIds != null && createPortfolioBlogDto.TagIds.Any())
                {
                    var tags = await _context.PortfolioBlogTags
                        .Where(t => createPortfolioBlogDto.TagIds.Contains(t.PortfolioBlogTagId))
                        .ToListAsync();

                    if (tags.Count != createPortfolioBlogDto.TagIds.Count)
                    {
                        throw new Exception("Bazı tag'ler bulunamadı. Lütfen geçerli tag ID'leri gönderin.");
                    }

                    blog.PortfolioBlogTags = tags;
                }

                // Kategorileri ekle
                if (createPortfolioBlogDto.CategoryIds != null && createPortfolioBlogDto.CategoryIds.Any())
                {
                    var categories = await _context.BlogCategories
                        .Where(c => createPortfolioBlogDto.CategoryIds.Contains(c.BlogCategoryId))
                        .ToListAsync();

                    if (categories.Count != createPortfolioBlogDto.CategoryIds.Count)
                    {
                        throw new Exception("Bazı kategoriler bulunamadı. Lütfen geçerli kategori ID'leri gönderin.");
                    }

                    blog.PortfolioBlogCategories = categories;
                }

                await _context.portfolioBlogs.AddAsync(blog);
                await _context.SaveChangesAsync();

                return createPortfolioBlogDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Blog oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task DeletePortfolioBlogAsync(int id)
        {
            var values = await _context.portfolioBlogs.FindAsync(id);
            _context.portfolioBlogs.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioBlogDto>> GetAllPortfolioBlogAsync(string query = "")
        {
            var values = await _context.portfolioBlogs.Include(x => x.PortfolioBlogTags).Include(y => y.PortfolioBlogCategories).ToListAsync();
            if (string.IsNullOrEmpty(query))
            {
                return _mapper.Map<List<GetAllPortfolioBlogDto>>(values);
            }
            else
            {
                var result = values.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                               b.PortfolioBlogTags.Any(tag => tag.TagName.Contains(query, StringComparison.OrdinalIgnoreCase)))
                   .ToList();

                return _mapper.Map<List<GetAllPortfolioBlogDto>>(result);
            }
        }

        public async Task<List<GetAllPortfolioBlogDto>> GetBlogByCategory(int id)
        {
            var values = await _context.BlogCategories.Where(x => x.BlogCategoryId == id).SelectMany(y => y.PortfolioBlogs).Include(a => a.PortfolioBlogCategories).Include(b => b.PortfolioBlogTags).ToListAsync();
            return _mapper.Map<List<GetAllPortfolioBlogDto>>(values);
        }

        public async Task<List<GetAllPortfolioBlogDto>> GetBlogByTag(int id)
        {
            var values = await _context.PortfolioBlogTags.Where(x => x.PortfolioBlogTagId == id).SelectMany(y => y.PortfolioBlogs).Include(a => a.PortfolioBlogTags).Include(b => b.PortfolioBlogCategories).ToListAsync();
            return _mapper.Map<List<GetAllPortfolioBlogDto>>(values);
        }

        public async Task<GetPortfolioBlogByPortfolioBlogIdDto> GetPortfolioBlogByPortfolioBlogIdAsync(int id)
        {
            var values = await _context.portfolioBlogs.Include(x=> x.PortfolioBlogTags).Include(y => y.PortfolioBlogCategories).Where(x => x.PortfolioBlogId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetPortfolioBlogByPortfolioBlogIdDto>(values);
        }

        public async Task<List<GetAllPortfolioBlogDto>> GetSuggestedPortfolioBlog()
        {
            var values = await _context.portfolioBlogs.Where(x => x.isSuggested == true).ToListAsync();
            return _mapper.Map<List<GetAllPortfolioBlogDto>>(values);
        }

        public async Task MarkSuggested(int id)
        {
            var values = await _context.portfolioBlogs.Where(x => x.PortfolioBlogId == id).FirstOrDefaultAsync();
            if(values.isSuggested == false)
            {
                values.isSuggested = true;
            }
            else
            {
                values.isSuggested = false;
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePortfolioBlogAsync(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            try
            {
                var existingBlog = await _context.portfolioBlogs
                    .Include(b => b.PortfolioBlogTags)
                    .Include(b => b.PortfolioBlogCategories)
                    .FirstOrDefaultAsync(b => b.PortfolioBlogId == updatePortfolioBlogDto.PortfolioBlogId);

                if (existingBlog == null)
                {
                    throw new Exception("Blog bulunamadı.");
                }

                // Mevcut tag ve kategorileri temizle
                existingBlog.PortfolioBlogTags.Clear();
                existingBlog.PortfolioBlogCategories.Clear();

                // Yeni tag'leri ekle
                if (updatePortfolioBlogDto.TagIds != null && updatePortfolioBlogDto.TagIds.Any())
                {
                    var tags = await _context.PortfolioBlogTags
                        .Where(t => updatePortfolioBlogDto.TagIds.Contains(t.PortfolioBlogTagId))
                        .ToListAsync();
                    foreach (var tag in tags)
                    {
                        existingBlog.PortfolioBlogTags.Add(tag);
                    }
                }

                // Yeni kategorileri ekle
                if (updatePortfolioBlogDto.CategoryIds != null && updatePortfolioBlogDto.CategoryIds.Any())
                {
                    var categories = await _context.BlogCategories
                        .Where(c => updatePortfolioBlogDto.CategoryIds.Contains(c.BlogCategoryId))
                        .ToListAsync();
                    foreach (var category in categories)
                    {
                        existingBlog.PortfolioBlogCategories.Add(category);
                    }
                }

                // Diğer özellikleri güncelle
                existingBlog.Title = updatePortfolioBlogDto.Title;
                existingBlog.SubContent = updatePortfolioBlogDto.SubContent;
                existingBlog.Content = updatePortfolioBlogDto.Content;
                existingBlog.CoverImage = updatePortfolioBlogDto.CoverImage;
                existingBlog.PublishDate = updatePortfolioBlogDto.PublishDate;
                existingBlog.isSuggested = updatePortfolioBlogDto.isSuggested;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Blog güncellenirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
