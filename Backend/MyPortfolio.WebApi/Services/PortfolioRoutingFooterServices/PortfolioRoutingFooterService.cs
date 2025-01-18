using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioRoutingFooterDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioRoutingFooterServices
{
    public class PortfolioRoutingFooterService : IPortfolioRoutingFooterService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioRoutingFooterService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioRoutingFooterAsync(CreatePortfolioRoutingFooterDto createPortfolioRoutingFooterDto)
        {
            var values = _mapper.Map<PortfolioRoutingFooter>(createPortfolioRoutingFooterDto);
            await _context.PortfolioRoutingFooters.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioRoutingFooterAsync(int id)
        {
            var values = await _context.PortfolioRoutingFooters.FindAsync(id);
            _context.PortfolioRoutingFooters.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetAllPortfolioRoutingFooterDto>> GetAllPortfolioRoutingFooterAsync()
        {
            var values = await _context.PortfolioRoutingFooters.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioRoutingFooterDto>>(values);
        }

        public async Task<GetPortfolioRoutingFooterByPortfolioRoutingFooterIdDto> GetPortfolioRoutingFooterByPortfolioRoutingFooterIdAsync(int id)
        {
            var values = await _context.PortfolioRoutingFooters.FindAsync(id);
            return _mapper.Map<GetPortfolioRoutingFooterByPortfolioRoutingFooterIdDto>(values);
        }

        public async Task UpdatePortfolioRoutingFooterAsync(UpdatePortfolioRoutingFooterDto updatePortfolioRoutingFooterDto)
        {
            var values = _mapper.Map<PortfolioRoutingFooter>(updatePortfolioRoutingFooterDto);
            _context.PortfolioRoutingFooters.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
