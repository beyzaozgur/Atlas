using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class NotificationController : Controller
	{
		NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());

		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult AllNotification()
		{
			var values = notificationManager.GetAll();
			return View(values);
		}

		[AllowAnonymous]
		public IActionResult DeleteNotification(int id)
		{
			var notification = notificationManager.GetById(id);
			notificationManager.TDelete(notification);
			return Json(new { result = true });
		}
	}
}
