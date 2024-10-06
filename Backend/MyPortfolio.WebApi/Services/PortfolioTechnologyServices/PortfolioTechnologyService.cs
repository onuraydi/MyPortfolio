using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioTechnologyDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioTechnologyServices
{
    public class PortfolioTechnologyService : IPortfolioTechnologyService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioTechnologyService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioTechnologyAsync(CreatePortfolioTechnologyDto createPortfolioTechnologyDto)
        {
            var values = _mapper.Map<PortfolioTechnology>(createPortfolioTechnologyDto);
            await _context.portfolioTechnologies.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioTechnologyAsync(int id)
        {
            var values = await _context.portfolioTechnologies.FindAsync(id);
            _context.portfolioTechnologies.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioTechnologyDto>> GetAllPortfolioTechnologyAsync()
        {
            var values = await _context.portfolioTechnologies.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioTechnologyDto>>(values);
        }

        public async Task<GetPortfolioTechnologyByPortfolioTechnologyIdDto> GetPortfolioTechnologyByPortfolioTechnologyIdAsync(int id)
        {
            var values = await _context.portfolioTechnologies.FindAsync(id);
            return _mapper.Map<GetPortfolioTechnologyByPortfolioTechnologyIdDto>(values);
        }

        public async Task UpdatePortfolioTechnologyAsync(UpdatePortfolioTechnologyDto updatePortfolioTechnologyDto)
        {
            var values = _mapper.Map<PortfolioTechnology>(updatePortfolioTechnologyDto);
            _context.portfolioTechnologies.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
