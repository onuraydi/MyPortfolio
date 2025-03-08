using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.NotificationDtos;
using MyPortfolio.WebApi.Dtos.PortfolioContactDtos;
using MyPortfolio.WebApi.Entites;
using MyPortfolio.WebApi.Services.NotificationServices;
using System.Data;

namespace MyPortfolio.WebApi.Services.PortfolioContactServices
{
    public class PortfolioContactService : IPortfolioContactService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public PortfolioContactService(PortfolioContext context, IMapper mapper, INotificationService notificationService)
        {
            _context = context;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public async Task CreatePortfolioContactAsync(CreatePortfolioContactDto createPortfolioContactDto)
        {
            var values = _mapper.Map<PortfolioContact>(createPortfolioContactDto);
            await _context.portfolioContacts.AddAsync(values);
            _context.SaveChanges();
            var notificationDto = new AddNotificationDto
            {
                isSeen = false,
                NotificationName = values.SenderNameSurname + " adlı kişiden bir mesajınız var.",
                NotificationDescription = "Konu: " + values.MessageSubject,
                NotificationTime = DateTime.Today.Date,
                isBlog = false,
                Href = values.PortfolioContactId,
            };
            await _notificationService.AddNotification(notificationDto);
            
        }

        public async Task DeletePortfolioContactAsync(int id)
        {
            var values = await _context.portfolioContacts.FindAsync(id);
            _context.portfolioContacts.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllPortfolioContactDto>> GetAllPortfolioContactAsync()
        {
            var values = await _context.portfolioContacts.ToListAsync();
            return _mapper.Map<List<GetAllPortfolioContactDto>>(values);
        }

        public async Task<GetPortfolioContactByPortfolioContactDto> GetPortfolioContactByPortfolioContactAsync(int id)
        {
            var values = await _context.portfolioContacts.FindAsync(id);
            return _mapper.Map<GetPortfolioContactByPortfolioContactDto>(values);
        }

        public async Task MarkAsNotRead(int id)
        {
            var values = await _context.portfolioContacts.FindAsync(id);
            values.isRead = false;
            _context.SaveChanges();
        }

        public async Task MarkAsRead(int id)
        {
            var values = await _context.portfolioContacts.FindAsync(id);
            values.isRead = true;
            _context.SaveChanges();
        }

        public async Task UpdatePortfolioContactAsync(UpdatePortfolioContactDto updatePortfolioContactDto)
        {
            var values = _mapper.Map<PortfolioContact>(updatePortfolioContactDto);
            _context.portfolioContacts.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
