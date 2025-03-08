using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.NotificationDtos;
using MyPortfolio.WebApi.Entites;
using System.Net.Mail;
using System.Net;

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
            string senderEmail = "yazilimdeneme1934@gmail.com";
            string senderPassword = "bvas mqkk hciw sbwd";
            string recipientEmail = "onuraydi@outlook.com";

            var values = _mapper.Map<Notification>(addNotificationDto);
            values.isSeen = false;
            await _context.Notifications.AddAsync(values);
            await _context.SaveChangesAsync();


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail); // Gönderen
            mail.To.Add(recipientEmail); // Alıcı
            mail.Subject = "Web Siten İçin Yeni Bir Bildirim Var"; // Konu
            mail.Body = $"Web siten için {values.NotificationName} başlıklı ve {values.NotificationDescription} açıklamalı bir bildirimin var.";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587) // Gmail SMTP sunucusu
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword), // Kullanıcı adı ve şifre
                EnableSsl = true // SSL bağlantısı
            };

            smtpClient.Send(mail);


        }

        public async Task DeleteAllNotification()
        {
            var values = await _context.Notifications.ToListAsync();
            _context.Notifications.RemoveRange(values);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotification(int id)
        {
            var values = await _context.Notifications.FindAsync(id);
            _context.Notifications.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeenNotification()
        {
            var values = await _context.Notifications.Where(x => x.isSeen == true).ToListAsync();
            _context.Notifications.RemoveRange(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetNotificationDto>> GetAllNotificationAsync()
        {
            var values = await _context.Notifications.ToListAsync();
            return _mapper.Map<List<GetNotificationDto>>(values);
        }

        public async Task<GetNotificationDto> GetNotificationById(int id)
        {
            var values = await _context.Notifications.FindAsync(id);
            return _mapper.Map<GetNotificationDto>(values);
        }

        public async Task<List<GetNotificationDto>> GetNotSeenNotificationAsync()
        {
            var values = await _context.Notifications.Where(x => x.isSeen == false).ToListAsync();
            return _mapper.Map<List<GetNotificationDto>>(values);
        }

        public async Task MarkAsNotSeenAsync(int id)
        {
            var values = await _context.Notifications.FindAsync(id);
            values.isSeen = false;
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsSeenAsync(int id)
        {
            var values = await _context.Notifications.FindAsync(id);
            values.isSeen = true;
            await _context.SaveChangesAsync();
        }
    }
}
