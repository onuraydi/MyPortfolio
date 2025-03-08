using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.WebApi.Services.NotificationServices;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        // burada get ve delete işlemlerini gerçekleştirip bildirim gönderilmesi gerekilen kısımların servislerinde de bildirim ekleme işlemlerini gerçekleştireceğim.

        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet("GetAllNotification")]
        public async Task<IActionResult> GetAllNotification()
        {
            var values = await _notificationService.GetAllNotificationAsync();
            if(values != null)
            {
                return Ok(values);
            }
            return Ok("Herhangi bir bildirim bulunmamakta.");
        }
        [HttpGet("GetNotSeenNotification")]
        public async Task<IActionResult> GetNotSeenNotification()
        {
            var values = await _notificationService.GetNotSeenNotificationAsync();
            if(values != null)
            {
                return Ok(values);
            }
            return Ok("Tüm bildirimleri gördünüz.");
        }

        [HttpGet("GetNotificationById/{id}")]
        public async Task<IActionResult> GetNotificarionById(int id)
        {
            var values = await _notificationService.GetNotificationById(id);
            if(values != null)
            {
                return Ok(values);
            }
            return Ok("Böyle bir bildirim yok.");
        }

        [HttpPost("MarkAsSeen/{id}")]
        public async Task<IActionResult> MarkAsSeen(int id)
        {
            await _notificationService.MarkAsSeenAsync(id);
            return Ok("Görüldü olarak işaretlendi");
        }

        [HttpPost("MArkAsNotSeen/{id}")]
        public async Task<IActionResult> MarkAsNotSeen(int id)
        {
            await _notificationService.MarkAsNotSeenAsync(id);
            return Ok("Görülmedi olarak işaretlendi");
        }

        [HttpDelete("DeleteAllNotification")]
        public async Task<IActionResult> DeleteAllNotification()
        {
            await _notificationService.DeleteAllNotification();
            return Ok("Tüm bildirimler silindi");
        }

        [HttpDelete("DeleteNotification/{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _notificationService.DeleteNotification(id);
            return Ok("Bildirim silindi");
        }

        [HttpDelete("DeleteSeenNotification")]
        public async Task<IActionResult> DeleteSeenNotification()
        {
            await _notificationService.DeleteSeenNotification();
            return Ok("Görülen bildirimler silindi");
        }
    }
}
