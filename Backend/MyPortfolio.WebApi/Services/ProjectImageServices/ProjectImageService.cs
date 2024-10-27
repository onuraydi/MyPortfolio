using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.ProjectImageDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.ProjectImageServices
{
    public class ProjectImageService : IProjectImageService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public ProjectImageService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DeleteProjectImageByProjectImageIdAsync(int id)
        {
            var values = await _context.ProjectImages.FindAsync(id);
            _context.ProjectImages.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetProjectImageByPortfolioProjectIdDto>> GetProjectImagesByPortfolioProjectIdAsync(int id)
        {
            var values = await _context.ProjectImages.Where(x => x.PortfolioProjectId == id).ToListAsync();
            return _mapper.Map<List<GetProjectImageByPortfolioProjectIdDto>>(values);
        }

        public async Task UpdateProjectImageAsync(UpdateProjectImageDto updateProjectImageDto)
        {
            var values = _mapper.Map<ProjectImage>(updateProjectImageDto);
            _context.ProjectImages.UpdateRange(values);
            await _context.SaveChangesAsync();
        }
    }
}
