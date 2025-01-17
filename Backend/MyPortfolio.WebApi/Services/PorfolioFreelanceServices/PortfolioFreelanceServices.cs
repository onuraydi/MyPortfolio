using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioFreelanceDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PorfolioFreelanceServices
{
    public class PortfolioFreelanceServices : IPortfolioFreelanceService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioFreelanceServices(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioFreelanceAsync(CreatePortfolioFreelanceDto createPortfolioFreelanceDto)
        {
            var values = _mapper.Map<PortfolioFreelance>(createPortfolioFreelanceDto);
            await _context.PortfolioFreelances.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioFreelanceAsync(int id)
        {
            var values = await _context.PortfolioFreelances.FindAsync(id);
            _context.PortfolioFreelances.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioFreelanceDto>> GetAllPortfolioFreelanceAsync()
        {
            var values = await _context.PortfolioFreelances.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioFreelanceDto>>(values);
        }

        public async Task<GetPortfolioFreelanceByPortfolioFreelanceIdDto> GetPortfolioFreelanceByPortfolioFreelanceIdAsync(int id)
        {
            var values = await _context.PortfolioFreelances.FindAsync(id);
            return _mapper.Map<GetPortfolioFreelanceByPortfolioFreelanceIdDto>(values);
        }

        public async Task UpdatePortfolioFreelanceAsync(UpdatePortfolioFreelanceDto updatePortfolioFreelanceDto)
        {
            var values = _mapper.Map<PortfolioFreelance>(updatePortfolioFreelanceDto);
            _context.PortfolioFreelances.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
