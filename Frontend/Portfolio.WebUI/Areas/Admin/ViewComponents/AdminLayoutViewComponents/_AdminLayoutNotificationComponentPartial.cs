using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.NotificationServices;

namespace Portfolio.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutNotificationComponentPartial:ViewComponent
    {
        private readonly INotificationService _notificationService;

        public _AdminLayoutNotificationComponentPartial(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _notificationService.GetAllNotificationAsync();
            return View(values);
        }
    }
}
