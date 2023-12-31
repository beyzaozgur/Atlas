using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
			var values = blogManager.GetBlogListWithCategoryByWriter(1);
			return View(values);
        }

        [AllowAnonymous]
		[HttpGet]
        public IActionResult BlogAdd()
        {
			CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
			List<SelectListItem> categories = (from x in categoryManager.GetAll() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
			ViewBag.categories = categories;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
			blog.BlogStatus = false;
			blog.CreateDate = DateTime.Now;
			blog.BlogImage = "~/CoreBlogTema/web/images/3.jpg";
			blog.BlogThumbnailImage = "~/CoreBlogTema/web/images/3.jpg";
            blog.WriterID = 1;
			blogManager.AddBlog(blog);
			return RedirectToAction("BlogListByWriter", "Blog");
        }

        [AllowAnonymous]
        public IActionResult BlogDelete(int id)
        {
			var values = blogManager.GetByID(id);
			blogManager.DeleteBlog(values);
			return Json(new { result = true });
		}

		// to set existing values to update page
		[AllowAnonymous]
		[HttpGet]
		public IActionResult BlogUpdate(int id)
		{
			CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
			List<SelectListItem> categories = (from x in categoryManager.GetAll() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
			ViewBag.categories = categories;
			var values = blogManager.GetByID(id);
			return View(values);
		}

		// to update blog data
		[AllowAnonymous]
		[HttpPost]
		public IActionResult BlogUpdate(Blog blog)
		{
			blogManager.UpdateBlog(blog);
			return RedirectToAction("BlogListByWriter", "Blog");
		}
	}
}
