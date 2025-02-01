using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;
using MyPortfolio.WebApi.Entites;
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
            var values = _mapper.Map<PortfolioBlog>(createPortfolioBlogDto);
            await _context.portfolioBlogs.AddAsync(values);
            _context.SaveChanges();
            return _mapper.Map<CreatePortfolioBlogDto>(values);
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
            var values = await _context.portfolioBlogs.FindAsync(id);
            return _mapper.Map<GetPortfolioBlogByPortfolioBlogIdDto>(values);
        }

        public async Task UpdatePortfolioBlogAsync(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            var values = _mapper.Map<PortfolioBlog>(updatePortfolioBlogDto);
            _context.portfolioBlogs.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
