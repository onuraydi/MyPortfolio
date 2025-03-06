namespace MyPortfolio.WebApi.Dtos.NotificationDtos
{
    public class AddNotificationDto
    {
        public string NotificationName { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime NotificationTime { get; set; }
        public bool isSeen { get; set; }
    }
}
