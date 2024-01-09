using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());

		private readonly UserManager<User> _userManager;
		public WriterNotification(UserManager<User> userManager)
		{
			_userManager = userManager;
		}
		public IViewComponentResult Invoke()
        {
			var userId = Int32.Parse(_userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User));
			Expression<Func<Notification, bool>> expression = x => x.NotifiedUserID == userId;
			var values = notificationManager.GetAll(expression).OrderByDescending(x => x.NotificationDate).Take(3).ToList();
			return View(values);
        }
    }
}
