using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.NotificationDtos;
using MyPortfolio.WebApi.Dtos.PortfolioBlogCommentDtos;
using MyPortfolio.WebApi.Entites;
using MyPortfolio.WebApi.Services.NotificationServices;

namespace MyPortfolio.WebApi.Services.PortfolioBlogCommentServices
{
    public class PortfolioBlogCommentService : IPortfolioBlogCommentService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        public PortfolioBlogCommentService(PortfolioContext context, IMapper mapper, INotificationService notificationService)
        {
            _context = context;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public async Task<CreatePortfolioBlogCommentDto> CreatePortfolioBlogCommentAsync(CreatePortfolioBlogCommentDto createPortfolioBlogCommentDto)
        {
            var values = _mapper.Map<PortfolioBlogComment>(createPortfolioBlogCommentDto);
            await _context.PortfolioComments.AddAsync(values);
            _context.SaveChanges();
            var blogName = await _context.portfolioBlogs.Where(x => x.PortfolioBlogId == values.portfolioBlogId).Select(y => y.Title).FirstOrDefaultAsync();
            var notificationDto = new AddNotificationDto
            {
                isSeen = false,
                NotificationName = values.Name + " adlı kişi " + blogName + " adlı blogunuza yorum yaptı.",
                NotificationDescription = "Konu: " + values.CommentTitle,
                NotificationTime = DateTime.Now.Date,
                isBlog = true,
                Href = values.PortfolioBlogCommentId,
            };
            await _notificationService.AddNotification(notificationDto);
            return _mapper.Map<CreatePortfolioBlogCommentDto>(createPortfolioBlogCommentDto);
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
                CommentDate = y.CommentDate,
                Name = y.Name,
                Surname = y.Surname,
                CommentDetail = y.CommentDetail,
                email = y.email,
                CommentTitle = y.CommentTitle,
                portfolioBlogId = y.portfolioBlogId,
            }).ToList();
            return _mapper.Map<List<GetPortfolioBlogCommentByPortfolioBlogIdDto>>(values2);
            
        }
    }
}
