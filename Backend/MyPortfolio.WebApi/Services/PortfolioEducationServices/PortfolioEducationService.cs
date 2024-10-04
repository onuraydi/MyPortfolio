using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioEducationDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioEducationServices
{
    public class PortfolioEducationService : IPortfolioEducationService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioEducationService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioEducationAsync(CreatePortfolioEducationDto createPortfolioEducationDto)
        {
            var values = _mapper.Map<PortfolioEducation>(createPortfolioEducationDto);
            await _context.portfolioEducations.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioEducationAsync(int id)
        {
            var values = await _context.portfolioEducations.FindAsync(id);
            _context.portfolioEducations.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioEducationDto>> GetAllPortfolioEducationAsync()
        {
            var values = await _context.portfolioEducations.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioEducationDto>>(values);
        }

        public async Task<GetPortfolioEducationByPortfolioEducationId> GetPortfolioEducationByPortfolioEducationIdAsync(int id)
        {
            var values = await _context.portfolioEducations.FindAsync(id);
            return _mapper.Map<GetPortfolioEducationByPortfolioEducationId>(values);
        }

        public async Task UpdatePortfolioEducationAsync(UpdatePortfolioEducationDto updatePortfolioEducationDto)
        {
            var values = _mapper.Map<PortfolioEducation>(updatePortfolioEducationDto);
            _context.portfolioEducations.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
