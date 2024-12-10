using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;
using MyPortfolio.WebApi.Dtos.PortfolioBlogTagDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioBlogTagServices
{
    public class PortfolioBlogTagService : IPortfolioBlogTagService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioBlogTagService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioBlogTagAsync(CreatePortfolioBlogTagDto createPortfolioBlogTagDto)
        {
            var values = _mapper.Map<PortfolioBlogTag>(createPortfolioBlogTagDto);
            await _context.PortfolioBlogTags.AddAsync(values);
            _context.SaveChanges();

        }

        public async Task DeletePortfolioBlogTagAsync(int id)
        {
            var values = await _context.PortfolioBlogTags.FindAsync(id);
            _context.PortfolioBlogTags.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioBlogTagDto>> GetAllPortfolioBlogTagAsync()
        {
            var values = await _context.PortfolioBlogTags.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioBlogTagDto>>(values);
        }

        public async Task<List<GetPortfolioBlogsByPortfolioBlogTagsIdDto>> GetPortfolioBlogByPortfolioBlogTagIdAsync(int id)
        {
            // Belirtilen tag ID'ye göre ilişkili blogları getir
            var values = await _context.portfolioBlogs
                .Include(blog => blog.PortfolioBlogTags) // İlişkili tag'leri dahil et
                .Where(blog => blog.PortfolioBlogTags.Any(tag => tag.PortfolioBlogTagId == id)) // Tag'e göre filtrele
                .ToListAsync();

            return _mapper.Map<List<GetPortfolioBlogsByPortfolioBlogTagsIdDto>>(values);
        }


        public async Task<GetPortfolioBlogTagByPortfolioBlogTagId> GetPortfolioBlogTagByPortfolioBlogTagIdAsync(int id)
        {
            var values = await _context.PortfolioBlogTags.FindAsync(id);
            return _mapper.Map<GetPortfolioBlogTagByPortfolioBlogTagId>(values);
        }

        public async Task<GetPortfolioBlogTagsByPortfolioBlogId> GetPortfolioBlogTagsByPortfolioBlogIdAsync(int id)
        {
            var values = await _context.portfolioBlogs.Include(x => x.PortfolioBlogTags).FirstOrDefaultAsync(y => y.PortfolioBlogId == id);
            return _mapper.Map<GetPortfolioBlogTagsByPortfolioBlogId>(values);
        }

        public async Task UpdatePortfolioBlogTagAsync(UpdatePortfolioBlogTagDto updatePortfolioBlogTagDto)
        {
            var values = _mapper.Map<PortfolioBlogTag>(updatePortfolioBlogTagDto);
            _context.PortfolioBlogTags.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
