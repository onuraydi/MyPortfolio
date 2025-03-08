using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.NotificationDtos
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
