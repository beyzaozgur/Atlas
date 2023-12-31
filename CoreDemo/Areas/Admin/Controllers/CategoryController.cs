using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        [AllowAnonymous]
		public IActionResult Index(int page = 1)
        {
            var values = categoryManager.GetAll().ToPagedList(page, 5);
            return View(values);
        }

		[AllowAnonymous]
		[HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

		[Area("Admin")]
		[AllowAnonymous]
		[HttpPost]
		public IActionResult AddCategory(Category category)
		{
			category.CategoryStatus = true;
			categoryManager.TAdd(category);
			return RedirectToAction("Index", "Category");
		}


	}
}
