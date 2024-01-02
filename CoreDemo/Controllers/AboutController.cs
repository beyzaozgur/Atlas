using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers
{
	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
			var values = aboutManager.GetAll();
			return View(values);
		}

		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
