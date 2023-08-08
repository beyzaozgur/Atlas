using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class BlogController : Controller
	{

		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		public IActionResult Index()
		{
			var values = blogManager.GetBlogListWithCategory();
			return View(values);
		}

		public IActionResult BlogReadAll(int id)
		{
			ViewBag.Id = id;
			var values = blogManager.GetBlogByID(id);
			return View(values);	
		}

		[AllowAnonymous]
        public IActionResult BlogListByWriter(int id)
        {
			var values = blogManager.GetBlogListByWriter(1);
			return View(values);
        }

        [AllowAnonymous]
		[HttpGet]
        public IActionResult BlogAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
			blog.BlogStatus = true;
			blog.CreateDate = DateTime.Now;
			blog.WriterID = 1;
			blogManager.AddBlog(blog);
			return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
