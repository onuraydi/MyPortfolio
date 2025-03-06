using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.NotificationDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Services.NotificationServices
{
    public class NotificationService : INotificationService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public NotificationService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddNotification(AddNotificationDto addNotificationDto)
        {
            var values = _mapper.Map<Notification>(addNotificationDto);
            values.isSeen = false;
            await _context.notifications.AddAsync(values);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllNotification()
        {
            var values = await _context.notifications.ToListAsync();
            _context.notifications.RemoveRange(values);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotification(int id)
        {
            var values = await _context.notifications.FindAsync(id);
            _context.notifications.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeenNotification()
        {
            var values = await _context.notifications.Where(x => x.isSeen == true).ToListAsync();
            _context.notifications.RemoveRange(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetNotificationDto>> GetAllNotificationAsync()
        {
            var values = await _context.notifications.ToListAsync();
            return _mapper.Map<List<GetNotificationDto>>(values);
        }

        public async Task<GetNotificationDto> GetNotificationById(int id)
        {
            var values = await _context.notifications.FindAsync(id);
            return _mapper.Map<GetNotificationDto>(values);
        }

        public async Task<List<GetNotificationDto>> GetNotSeenNotificationAsync()
        {
            var values = await _context.notifications.Where(x => x.isSeen == false).ToListAsync();
            return _mapper.Map<List<GetNotificationDto>>(values);
        }

        public async Task MarkAsNotSeenAsync(int id)
        {
            var values = await _context.notifications.FindAsync(id);
            values.isSeen = false;
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsSeenAsync(int id)
        {
            var values = await _context.notifications.FindAsync(id);
            values.isSeen = true;
            await _context.SaveChangesAsync();
        }
    }
}
