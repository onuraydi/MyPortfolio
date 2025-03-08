using Portfolio.DtoLayer.PortfolioDtos.NotificationDtos;
using System.Net.Http.Json;

namespace Portfolio.WebUI.Services.PortfolioServices.NotificationServices
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;

        public NotificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteAllNotification()
        {
            await _httpClient.DeleteAsync("Notifications/DeleteAllNotification");
        }

        public async Task DeleteNotification(int id)
        {
            await _httpClient.DeleteAsync("Notifications/DeleteNotification/" + id);
        }

        public async Task DeleteSeenNotification()
        {
            await _httpClient.DeleteAsync("Notifications/DeleteSeenNotification");
        }

        public async Task<List<GetNotificationDto>> GetAllNotificationAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Notifications/GetAllNotification");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetNotificationDto>>();
            return values;
        }

        public async Task<GetNotificationDto> GetNotificationById(int id)
        {
            var responseMessage = await _httpClient.GetAsync("Notifications/GetNotificationById/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetNotificationDto>();
            return values;
        }

        public async Task<List<GetNotificationDto>> GetNotSeenNotificationAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Notifications/GetNotSeenNotification");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<GetNotificationDto>>();
            return values;
        }

        public async Task MarkAsNotSeenAsync(int id)
        {
            await _httpClient.PostAsJsonAsync("Notifications/MArkAsNotSeen/"+id,id);
        }

        public async Task MarkAsSeenAsync(int id)
        {
            await _httpClient.PostAsJsonAsync("Notifications/MarkAsSeen/" + id, id);
        }
    }
}
