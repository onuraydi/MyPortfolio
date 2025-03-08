using Portfolio.DtoLayer.PortfolioDtos.NotificationDtos;

namespace Portfolio.WebUI.Services.PortfolioServices.NotificationServices
{
    public interface INotificationService
    {
        Task<List<GetNotificationDto>> GetNotSeenNotificationAsync();
        Task<List<GetNotificationDto>> GetAllNotificationAsync();
        Task<GetNotificationDto> GetNotificationById(int id);
        Task MarkAsSeenAsync(int id);
        Task MarkAsNotSeenAsync(int id);
        Task DeleteNotification(int id);
        Task DeleteAllNotification();
        Task DeleteSeenNotification();
    }
}
