using BusinessLayer.Concrete;
using CoreDemo.ViewModels;
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
			List<CategoryCountListViewModel> categoryCountList = new List<CategoryCountListViewModel>();

			var values = categoryManager.GetAll();

			foreach (var item in values)
			{
				var blogCount = categoryManager.GetBlogCountByCategory(item.CategoryID);

				CategoryCountListViewModel categoryCountListViewModel = new CategoryCountListViewModel();

				categoryCountListViewModel.CategoryName = item.CategoryName;
				categoryCountListViewModel.BlogCount = blogCount;
				categoryCountList.Add(categoryCountListViewModel);
			}

			return View(categoryCountList);
		}
	}
}
