using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterAboutOnDashboard: ViewComponent
	{

		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		public IViewComponentResult Invoke()
		{
			var writer = writerManager.GetById(1);
			return View(writer);
		}
	}
}
