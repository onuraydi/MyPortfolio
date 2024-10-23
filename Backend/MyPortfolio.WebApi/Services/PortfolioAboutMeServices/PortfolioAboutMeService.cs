using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioAboutMeDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioAboutMeServices
{
    public class PortfolioAboutMeService : IPortfolioAboutMeService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioAboutMeService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetPortfolioAboutMeDto> GetPortfolioAboutMeAsync()
        {
            var values = await _context.portfolioAboutMe.FirstOrDefaultAsync();
            return _mapper.Map<GetPortfolioAboutMeDto>(values); 
        }

        public async Task<GetPortfolioAboutMeByPortfolioAboutMeIdDto> GetPortfolioAboutMeByPortfolioAboutMeIdAsync(int id)
        {
            var values = await _context.portfolioAboutMe.FindAsync(id);
            return _mapper.Map<GetPortfolioAboutMeByPortfolioAboutMeIdDto>(values);
        }

        public async Task UpdatePortfolioAboutMeAsync(UpdatePortfolioAboutMeDto updatePortfolioAboutMeDto)
        {
            var values = _mapper.Map<PortfolioAboutMe>(updatePortfolioAboutMeDto);
            _context.portfolioAboutMe.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
