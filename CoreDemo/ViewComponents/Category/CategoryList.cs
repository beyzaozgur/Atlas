using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryList : ViewComponent
	{
		CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
		public IViewComponentResult Invoke()
		{
			var values = categoryManager.GetAll();
			return View(values);
		}
	}
}
