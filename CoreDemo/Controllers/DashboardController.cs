using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class DashboardController : Controller
	{

		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		CommentManager commentManager = new CommentManager(new EfCommentRepository());

		private readonly UserManager<User> _userManager;

		public DashboardController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);

			ViewBag.allBlogsCard = blogManager.GetAll().Count();
			ViewBag.myBlogsCard = blogManager.GetBlogListByWriter(Int32.Parse(userId)).Count();
			ViewBag.myCommentsCard = commentManager.GetCommentCountByWriterId(1);

			return View();
		}
	}
}
