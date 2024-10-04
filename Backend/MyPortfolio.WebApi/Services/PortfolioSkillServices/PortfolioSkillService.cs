using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioSkillDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioSkillServices
{
    public class PortfolioSkillService : IPortfolioSkillService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioSkillService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioSkillAsync(CreatePortfolioSkillDto createPortfolioSkillDto)
        {
            var values = _mapper.Map<PortfolioSkill>(createPortfolioSkillDto);
            await _context.portfolioSkills.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioSkillAsync(int id)
        {
            var values = await _context.portfolioSkills.FindAsync(id);
            _context.portfolioSkills.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioSkillDto>> GetAllPortfolioSkillAsync()
        {
            var values = await _context.portfolioSkills.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioSkillDto>>(values);
        }

        public async Task<GetPortfolioSkillBySkillIdDto> GetPortfolioSkillBySkillIdAsync(int id)
        {
            var values = await _context.portfolioSkills.FindAsync(id);
            return _mapper.Map<GetPortfolioSkillBySkillIdDto>(values);
        }

        public async Task UpdatePortfolioSkillAsync(UpdatePortfolioSkillDto updatePortfolioSkillDto)
        {
            var values = _mapper.Map<PortfolioSkill>(updatePortfolioSkillDto);
            _context.portfolioSkills.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
