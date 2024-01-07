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
    public class RegisterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult Index(AddUpdateWriterModel writer)
		{
			Writer w = new Writer();

			w.WriterName = writer.WriterName;
			w.WriterMail = writer.WriterMail;
			w.WriterPassword = writer.WriterPassword;
			w.ConfirmPassword = writer.ConfirmPassword;
			w.WriterCity = writer.WriterCity;
			w.WriterAbout = "Hi! I am new blogger in Atlas!";
			w.WriterStatus = true;

			if (writer.WriterImage != null)
			{
				var extension = Path.GetExtension(writer.WriterImage.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				writer.WriterImage.CopyTo(stream);
				w.WriterImage = newImageName;
			}

			WriterValidator writerValidator = new WriterValidator();
			ValidationResult validationResults = writerValidator.Validate(w);

			if (validationResults.IsValid)
			{
				if (w.WriterPassword == w.ConfirmPassword)
				{
					writerManager.TAdd(w);
					return RedirectToAction("Index", "Blog");
				} else
				{
					ModelState.AddModelError("ConfirmPassword", "Şifreler eşleşmiyor!");
				}

			}
			else
			{
				foreach(var item in validationResults.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			return View();
		}

	}
}
