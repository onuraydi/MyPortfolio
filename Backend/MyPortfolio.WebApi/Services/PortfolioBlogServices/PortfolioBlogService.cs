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
                var values = _mapper.Map<PortfolioBlog>(createPortfolioBlogDto);
                
                // Eğer tag ID'leri varsa, ilişkilendirme yap
                if (createPortfolioBlogDto.TagIds != null && createPortfolioBlogDto.TagIds.Any())
                {
                    var existingTags = await _context.PortfolioBlogTags
                        .Where(t => createPortfolioBlogDto.TagIds.Contains(t.PortfolioBlogTagId))
                        .ToListAsync();

                    if (existingTags.Count != createPortfolioBlogDto.TagIds.Count)
                    {
                        throw new Exception("Bazı tag'ler bulunamadı. Lütfen geçerli tag ID'leri gönderin.");
                    }

                    values.PortfolioBlogTags = existingTags;
                }

                await _context.portfolioBlogs.AddAsync(values);
                await _context.SaveChangesAsync();
                return _mapper.Map<CreatePortfolioBlogDto>(values);
            }
            catch (Exception ex)
            {
                throw new Exception($"Blog eklenirken bir hata oluştu: {ex.Message}");
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
            var values = await _context.portfolioBlogs.Include(x => x.PortfolioBlogTags).ToListAsync();
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

        public async Task<GetPortfolioBlogByPortfolioBlogIdDto> GetPortfolioBlogByPortfolioBlogIdAsync(int id)
        {
            var values = await _context.portfolioBlogs.Include(x=> x.PortfolioBlogTags).Where(x => x.PortfolioBlogId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetPortfolioBlogByPortfolioBlogIdDto>(values);
        }

        public async Task UpdatePortfolioBlogAsync(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            // Mevcut blog'u ve ilişkili tag'leri getir
            var existingBlog = await _context.portfolioBlogs
                .Include(x => x.PortfolioBlogTags)
                .FirstOrDefaultAsync(x => x.PortfolioBlogId == updatePortfolioBlogDto.PortfolioBlogId);

            if (existingBlog == null)
            {
                throw new Exception("Blog bulunamadı");
            }

            // Blog özelliklerini güncelle
            existingBlog.Title = updatePortfolioBlogDto.Title;
            existingBlog.SubContent = updatePortfolioBlogDto.SubContent;
            existingBlog.Content = updatePortfolioBlogDto.Content;
            existingBlog.CoverImage = updatePortfolioBlogDto.CoverImage;
            existingBlog.PublishDate = updatePortfolioBlogDto.PublishDate;

            // Tag ilişkilerini güncelle
            if (updatePortfolioBlogDto.TagIds != null && updatePortfolioBlogDto.TagIds.Any())
            {
                // Mevcut tag'leri temizle
                existingBlog.PortfolioBlogTags.Clear();

                // Yeni tag'leri ekle
                var newTags = await _context.PortfolioBlogTags
                    .Where(t => updatePortfolioBlogDto.TagIds.Contains(t.PortfolioBlogTagId))
                    .ToListAsync();

                foreach (var tag in newTags)
                {
                    existingBlog.PortfolioBlogTags.Add(tag);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
