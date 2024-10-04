using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioExperienceDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioExperienceServices
{
    public class PortfolioExperienceService : IPortfolioExperienceService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioExperienceService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioExperienceAsync(CreatePortfolioExperienceDto createPortfolioExperienceDto)
        {
            var values = _mapper.Map<PortfolioExperience>(createPortfolioExperienceDto);
            await _context.portfolioExperiences.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioExperienceAsync(int id)
        {
            var values = await _context.portfolioExperiences.FindAsync(id);
            _context.portfolioExperiences.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioExperienceDto>> GetAllPortfolioExperienceAsync()
        {
            var values = await _context.portfolioExperiences.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioExperienceDto>>(values);
        }

        public async Task<GetPortfolioExperienceByPortfolioExperienceIdDto> GetPortfolioExperienceByportfolioExperienceIdAsync(int id)
        {
            var values = await _context.portfolioExperiences.FindAsync(id);
            return _mapper.Map<GetPortfolioExperienceByPortfolioExperienceIdDto>(values);
        }

        public async Task UpdatePortfolioExperienceAsync(UpdatePortfolioExperienceDto updatePortfolioExperienceDto)
        {
            var values = _mapper.Map<PortfolioExperience>(updatePortfolioExperienceDto);
            _context.portfolioExperiences.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
