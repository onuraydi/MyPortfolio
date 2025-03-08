namespace MyPortfolio.WebApi.Dtos.NotificationDtos
{
    public class GetNotificationDto
    {
        public int NotificationId { get; set; }
        public string NotificationName { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime NotificationTime { get; set; }
        public bool isSeen { get; set; }
        public bool isBlog { get; set; }
        public int Href { get; set; }
    }
}
