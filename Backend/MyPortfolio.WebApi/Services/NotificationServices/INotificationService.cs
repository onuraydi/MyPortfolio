using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyPortfolio.WebApi.Dtos.NotificationDtos;

namespace MyPortfolio.WebApi.Services.NotificationServices
{
    public interface INotificationService
    {
        Task<List<GetNotificationDto>> GetNotSeenNotificationAsync();
        Task<List<GetNotificationDto>> GetAllNotificationAsync();
        Task<GetNotificationDto> GetNotificationById(int id);
        Task AddNotification(AddNotificationDto addNotificationDto);
        Task MarkAsSeenAsync(int id);
        Task MarkAsNotSeenAsync(int id);
        Task DeleteNotification(int id);
        Task DeleteAllNotification();
        Task DeleteSeenNotification();
    }
}
