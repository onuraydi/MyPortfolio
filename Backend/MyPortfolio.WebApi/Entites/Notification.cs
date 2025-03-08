namespace MyPortfolio.WebApi.Entites
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationName { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime NotificationTime { get; set; }
        public bool isSeen { get; set; } = false;
        public bool isBlog { get; set; }
        public int Href { get; set; }
    }
}
