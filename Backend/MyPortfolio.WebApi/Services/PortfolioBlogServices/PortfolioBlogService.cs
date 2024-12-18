using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;
using MyPortfolio.WebApi.Entites;

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

        public async Task<List<GetAllPortfolioBlogDto>> GetAllPortfolioBlogAsync()
        {
            var values = await _context.portfolioBlogs.Include(x =>x.PortfolioBlogTags).ToListAsync();
            return _mapper.Map<List<GetAllPortfolioBlogDto>>(values);
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
