using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.PortfolioBlogCommentDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.PortfolioBlogCommentServices
{
    public class PortfolioBlogCommentService : IPortfolioBlogCommentService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public PortfolioBlogCommentService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePortfolioBlogCommentAsync(CreatePortfolioBlogCommentDto createPortfolioBlogCommentDto)
        {
            var values = _mapper.Map<PortfolioBlogComment>(createPortfolioBlogCommentDto);
            await _context.PortfolioComments.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeletePortfolioBlogCommentAsync(int id)
        {
            var values = await _context.PortfolioComments.FindAsync(id);
            _context.PortfolioComments.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioBlogCommentDto>> GetAllPortfolioBlogCommentAsync()
        {
            var values = await _context.PortfolioComments.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioBlogCommentDto>>(values);
        }

        public async Task<GetPortfolioBlogCommentByPortfolioBlogCommentIdDto> GetPortfolioBlogCommentByPortfolioBlogCommentIdAsync(int id)
        {
            var values = await _context.PortfolioComments.FindAsync(id);
            return _mapper.Map<GetPortfolioBlogCommentByPortfolioBlogCommentIdDto>(values);
        }

        public async Task<List<GetPortfolioBlogCommentByPortfolioBlogIdDto>> GetPortfolioBlogCommentByPortfolioBlogIdAsync(int id)
        {
            
            var values = await _context.PortfolioComments.Where(x => x.portfolioBlogId == id).Include(x => x.PortfolioBlog).ToListAsync();
            var values2 = values.Select(y => new GetPortfolioBlogCommentByPortfolioBlogIdDto
            {
                PortfolioBlogCommentId = y.PortfolioBlogCommentId,
                Name = y.Name,
                Surname = y.Surname,
                CommentDetail = y.CommentDetail,
                CommentRate = y.CommentRate,
                CommentTitle = y.CommentTitle,
                portfolioBlogId = y.portfolioBlogId
            }).ToList();
            return _mapper.Map<List<GetPortfolioBlogCommentByPortfolioBlogIdDto>>(values2);
            
        }
    }
}
