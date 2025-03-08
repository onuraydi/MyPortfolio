using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.NotificationServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioContactServices;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IPortfolioBlogCommentService _commentService;
        private readonly IPortfolioContactService _contactService;

        public NotificationController(INotificationService notificationService, IPortfolioBlogCommentService commentService, IPortfolioContactService contactService)
        {
            _notificationService = notificationService;
            _commentService = commentService;
            _contactService = contactService;
        }

        [HttpGet]
        [Route("GetAllNotification")]
        public async Task<IActionResult> GetAllNotification()
        {
            var values = await _notificationService.GetAllNotificationAsync();
            return View(values);
        }

        [HttpGet]
        [Route("GetNotificationById/{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var values = await _notificationService.GetNotificationById(id);
            return View(values);
        }

        [HttpGet]
        [Route("GetNotSeenNotification")]
        public async Task<IActionResult> GetNotSeenNotification()
        {
            var values = await _notificationService.GetNotSeenNotificationAsync();
            return View(values);
        }

        [HttpPost("MarkAsSeen/{id}")]
        [Route("MarkAsSeen/{id}")]
        public async Task<IActionResult> MarkAsSeen(int id)
        {
            await _notificationService.MarkAsSeenAsync(id);
            return RedirectToAction("GetAllNotification", "Notification", new { area = "Admin" });
        }

        [HttpPost("MarkAsNotSeen/{id}")]
        [Route("MarkAsNotSeen/{id}")]
        public async Task<IActionResult> MarkAsNotSeen(int id)
        {
            await _notificationService.MarkAsNotSeenAsync(id);
            return RedirectToAction("GetAllNotification", "Notification", new { area = "Admin" });
        }

        [HttpDelete("{id}")]
        [Route("DeleteNotification/{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _notificationService.DeleteNotification(id);
            return RedirectToAction("GetAllNotification", "Notification", new { area = "Admin" });
        }

        [HttpDelete("DeleteSeenNotification")]
        [Route("DeleteSeenNotification")]
        public async Task<IActionResult> DeleteSeenNotification()
        {
            await _notificationService.DeleteSeenNotification();
            return RedirectToAction("GetAllNotification", "Notification", new { area = "Admin" });
        }

        [HttpDelete("DeleteAllNotification")]
        [Route("DeleteAllNotification")]
        public async Task<IActionResult> DeleteAllNotification()
        {
            await _notificationService.DeleteAllNotification();
            return RedirectToAction("GetAllNotification", "Notification", new { area = "Admin" });
        }

        [HttpGet("GoDetail")]
        [Route("GoDetail/{id}")]
        public async Task<IActionResult> GoDetail(int id)
        {
            var values = await _notificationService.GetNotificationById(id);
            if(values.isBlog == true)
            {
                return Redirect("/Admin/PortfolioBlogComment/GetByIdPortfolioBlogComment/" + values.Href);
                //return _commentService.GetPortfolioBlogCommentByPortfolioBlogCommentIdAsync(values.Href);
            }
            else
            {
                return Redirect("/Admin/PortfolioContact/GetByIdPortfolioContact/" + values.Href);
                //await _contactService.GetPortfolioContactByPortfolioContactIdAsync(values.Href);
            }
        }
    }
}
