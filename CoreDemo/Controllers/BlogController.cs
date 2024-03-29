﻿using BusinessLayer.Concrete;
using CoreDemo.ViewModels;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
	{

		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		CommentManager commentManager = new CommentManager(new EfCommentRepository());

		private readonly UserManager<User> _userManager;

		public BlogController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var values = blogManager.GetBlogListWithCategoryAndCommentsAndUser();
			return View(values);
		}

		public IActionResult BlogReadAll(int id)
		{
			var commentCountByBlog = commentManager.GetListByBlogId(id).Count();

			ViewBag.commentCount = commentCountByBlog;

			var values = blogManager.GetBlogWithUserByBlogId(id);
			return View(values);	
		}

		[AllowAnonymous]
        public IActionResult BlogListByWriter(int id)
        {
			var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
			var values = blogManager.GetBlogListWithCategoryByWriter(Int32.Parse(userId));
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
        public IActionResult BlogAdd(AddUpdateBlogModel b)
        {
			Blog blog = new Blog();
			var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);

			blog.BlogTitle = b.BlogTitle;
			blog.BlogContent = b.BlogContent;
			blog.BlogStatus = true;
			blog.CreateDate = DateTime.Now;
            blog.UserID = Int32.Parse(userId);
			blog.CategoryID = b.CategoryID;

            if (b.BlogImage != null)
            {
                var extension = Path.GetExtension(b.BlogImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                b.BlogImage.CopyTo(stream);
                blog.BlogImage = newImageName;
            }

            blogManager.TAdd(blog);
			return RedirectToAction("BlogListByWriter", "Blog");
        }

        [AllowAnonymous]
        public IActionResult BlogDelete(int id)
        {
			var values = blogManager.GetById(id);
			blogManager.TDelete(values);
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
			var values = blogManager.GetById(id);
			return View(values);
		}

		// to update blog data
		[AllowAnonymous]
		[HttpPost]
		public IActionResult BlogUpdate(AddUpdateBlogModel b)
		{
			Blog blog = new Blog();

			blog.BlogID = b.BlogID;
			blog.BlogTitle = b.BlogTitle;
			blog.BlogContent = b.BlogContent;
			blog.BlogStatus = false;
			blog.CreateDate = DateTime.Now;
			blog.UserID = 1;
			blog.CategoryID = b.CategoryID;

			if (b.BlogImage != null)
			{
				var extension = Path.GetExtension(b.BlogImage.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImages/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				b.BlogImage.CopyTo(stream);
				blog.BlogImage = newImageName;
			}

			blogManager.TUpdate(blog);
			return RedirectToAction("BlogListByWriter", "Blog");
		}
	}
}
