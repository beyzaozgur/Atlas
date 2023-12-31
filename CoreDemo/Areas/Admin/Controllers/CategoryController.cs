using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        [AllowAnonymous]
		[Area("Admin")]
		public IActionResult Index(int page = 1)
        {
            var values = categoryManager.GetList().ToPagedList(page, 5);
            return View(values);
        }
    }
}
