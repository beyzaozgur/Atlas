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
		UserManager userManager = new UserManager(new EfUserRepository());

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
			var writerData = userManager.GetById(1);

			return View(writerData);
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterEditProfile(AddUpdateWriterModel writer)
		{
			User w = new User();

			w.Id = writer.WriterID;
			w.PasswordHash = writer.WriterPassword;
			w.NameSurname = writer.WriterName;
			w.Email = writer.WriterMail;
			w.City = writer.WriterCity;
			w.About = writer.WriterAbout;
			w.Status = true;

			if(writer.WriterImage != null)
			{
				var extension = Path.GetExtension(writer.WriterImage.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				writer.WriterImage.CopyTo(stream);
				w.ImageUrl = newImageName;
			}

			UserValidator userValidator = new UserValidator();
			ValidationResult results = userValidator.Validate(w);

			if(results.IsValid)
			{
				userManager.TUpdate(w);
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
