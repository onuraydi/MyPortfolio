using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioProjectFooterDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioProjectFooterServices
{
    public class PortfolioProjectFooterService : IPortfolioProjectFooterService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;
public PortfolioProjectFooterService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioProjectFooterAsync(CreatePortfolioProjectFooterDto createPortfolioProjectFooterDto)
        {
            var values = _mapper.Map<PortfolioProjectFooter>(createPortfolioProjectFooterDto);
            await _context.PortfolioProjectFooters.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioProjectFooterAsync(int id)
        {
            var values = await _context.PortfolioProjectFooters.FindAsync(id);
            _context.PortfolioProjectFooters.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetAllPortfolioProjectFooterDto>> GetAllPortfolioProjectFooterAsync()
        {
            var values = await _context.PortfolioProjectFooters.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioProjectFooterDto>>(values);
        }

        public async Task<GetPortfolioProjectFooterByPortfolioProjectFooterIdDto> GetPortfolioProjectFooterByPortfolioProjectFooterIdAsync(int id)
        {
            var values = await _context.PortfolioProjectFooters.FindAsync(id);
            return _mapper.Map<GetPortfolioProjectFooterByPortfolioProjectFooterIdDto>(values);
        }

        public async Task UpdatePortfolioProjectFooterAsync(UpdatePortfolioProjectFooterDto updatePortfolioProjectFooterDto)
        {
            var values = _mapper.Map<PortfolioProjectFooter>(updatePortfolioProjectFooterDto);
            _context.PortfolioProjectFooters.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
