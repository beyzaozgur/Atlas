using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryListDashboard: ViewComponent
	{
		BlogManager blogManager = new BlogManager(new EfBlogRepository());

		private readonly UserManager<User> _userManager;

		public CategoryListDashboard(UserManager<User> userManager)
		{
			_userManager = userManager;
		}
		public IViewComponentResult Invoke()
		{
			var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);

			var values = blogManager.GetBlogListByWriter(Int32.Parse(userId));
			return View(values);
		}
	}
}
