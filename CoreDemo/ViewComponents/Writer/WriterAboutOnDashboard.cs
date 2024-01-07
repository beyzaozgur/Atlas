using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterAboutOnDashboard: ViewComponent
	{

		private readonly UserManager<User> _userManager;

		public WriterAboutOnDashboard(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public IViewComponentResult Invoke()
		{
			var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
			var user = _userManager.FindByIdAsync(userId).Result;
			return View(user);
		}
	}
}
