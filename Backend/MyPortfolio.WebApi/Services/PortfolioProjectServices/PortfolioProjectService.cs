using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioProjectDtos;
using MyPortfolio.WebApi.Dtos.ProjectImageDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioProjectServices
{
    public class PortfolioProjectService : IPortfolioProjectService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioProjectService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioProjectAsync(CreatePortfolioProjectDto createPortfolioProjectDto)
        {
            var values = _mapper.Map<PortfolioProject>(createPortfolioProjectDto);
            await _context.portfolioProjects.AddAsync(values);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePortfolioProjectAsync(int id)
        {
            var values = await _context.portfolioProjects.FindAsync(id);
            _context.portfolioProjects.Remove(values);
            _context.SaveChanges();
        }


        public async Task<List<GetAllPortfolioProjectDto>> GetAllPortfolioProjectAsync()  
        {
            var values = await _context.portfolioProjects.Include(x => x.Images).ToListAsync();
            return _mapper.Map<List<GetAllPortfolioProjectDto>>(values);
        }

        public async Task<GetPortfolioProjectByPortfolioProjectIdDto> GetAllPortfolioProjectByPortfolioProjectIdAsync(int id)
        {
            var values = await _context.portfolioProjects.Include(x => x.Images).FirstOrDefaultAsync(y => y.PortfolioProjectId == id);
            return _mapper.Map<GetPortfolioProjectByPortfolioProjectIdDto>(values);
        }

        public async Task UpdatePortfolioProjectAsync(UpdatePortfolioProjectDto updatePortfolioProjectDto)
        {
            var values = _mapper.Map<PortfolioProject>(updatePortfolioProjectDto);
            _context.portfolioProjects.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
