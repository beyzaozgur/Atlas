using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class DashboardController : Controller
	{

		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		CommentManager commentManager = new CommentManager(new EfCommentRepository());

		[AllowAnonymous]
		public IActionResult Index()
		{
			ViewBag.allBlogsCard = blogManager.GetAll().Count();
			ViewBag.myBlogsCard = blogManager.GetBlogListByWriter(1).Count();
			ViewBag.myCommentsCard = commentManager.GetCommentCountByWriterId(1);

			return View();
		}
	}
}
