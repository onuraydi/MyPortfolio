using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioMainTitleDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioMainTitleServices
{
    public class PortfolioMainTitleService : IPortfolioMainTitleService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioMainTitleService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetPortfolioMainTitleDto>> GetPortfolioMainTitleAsync()
        {
            var values = await _context.PortfolioMainTitles.ToListAsync();
            return _mapper.Map<List<GetPortfolioMainTitleDto>>(values);
        }

        public async Task<GetPortfolioMainTitleByPortfolioMainTitleIdDto> GetPortfolioMainTitleByPortfolioMainTitleIdAsync(int id)
        {
            var values = await _context.PortfolioMainTitles.FindAsync(id);
            return _mapper.Map<GetPortfolioMainTitleByPortfolioMainTitleIdDto>(values);
        }

        public async Task UpdatePortfolioMainTitleAsync(UpdatePortfoiloMainTitleDto updatePortfoiloMainTitleDto)
        {
            var values = _mapper.Map<PortfolioMainTitle>(updatePortfoiloMainTitleDto);
            _context.PortfolioMainTitles.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
