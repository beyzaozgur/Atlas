using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CoreDemo.Controllers
{
	public class NotificationController : Controller
	{
		NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());

		private readonly UserManager<User> _userManager;
		public NotificationController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult AllNotification()
		{
			var userId = Int32.Parse(_userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User));
			var values = notificationManager.GetNotificationListWithComment(userId);
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
