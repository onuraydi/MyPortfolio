using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioSocialMediaFooter;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioSocialMediaFooterServices
{
    public class PortfolioSocialMediaFooterService : IPortfolioSocialMediaFooterService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioSocialMediaFooterService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioSocialMediaFooterAsync(CreatePortfolioSocialMediaFooterDto createPortfolioSocialMediaFooterDto)
        {
            var values = _mapper.Map<PortfolioSocialMediaFooter>(createPortfolioSocialMediaFooterDto);
            await _context.PortfolioSocialMediaFooters.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioSocialMediaFooterAsync(int id)
        {
            var values = await _context.PortfolioSocialMediaFooters.FindAsync(id);
            _context.PortfolioSocialMediaFooters.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioSocialMediaFooterDto>> GetAllPortfolioSocialMediaFooterAsync()
        {
            var values = await _context.PortfolioSocialMediaFooters.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioSocialMediaFooterDto>>(values);
        }

        public async Task<GetPortfolioSocialMediaFooterByIdDto> GetPortfolioSocialMediaFooterByIdAsync(int id)
        {
            var values = await _context.PortfolioSocialMediaFooters.FindAsync(id);
            return _mapper.Map<GetPortfolioSocialMediaFooterByIdDto>(values);
        }

        public async Task UpdatePortfolioSocialMediaFooterAsync(UpdatePortfolioSocialMediaFooterDto updatePortfolioSocialMediaFooterDto)
        {
            var values = _mapper.Map<PortfolioSocialMediaFooter>(updatePortfolioSocialMediaFooterDto);
            _context.PortfolioSocialMediaFooters.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
