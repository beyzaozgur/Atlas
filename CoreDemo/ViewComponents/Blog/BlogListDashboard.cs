using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class BlogListDashboard: ViewComponent
	{
		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = blogManager.GetLast5BlogsWithCategory();
			return View(values);
		}
	}
}
