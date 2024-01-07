using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.ViewModels;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}

		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writerData = writerManager.GetById(1);

			return View(writerData);
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterEditProfile(AddUpdateWriterModel writer)
		{
			Writer w = new Writer();

			w.WriterID = writer.WriterID;
			w.WriterPassword = writer.WriterPassword;
			w.WriterName = writer.WriterName;
			w.WriterMail = writer.WriterMail;
			w.WriterCity = writer.WriterCity;
			w.WriterAbout = writer.WriterAbout;
			w.WriterStatus = true;

			if(writer.WriterImage != null)
			{
				var extension = Path.GetExtension(writer.WriterImage.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				writer.WriterImage.CopyTo(stream);
				w.WriterImage = newImageName;
			}

			WriterValidator writerValidator = new WriterValidator();
			ValidationResult results = writerValidator.Validate(w);

			if(results.IsValid)
			{
				writerManager.TUpdate(w);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				foreach(var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}
