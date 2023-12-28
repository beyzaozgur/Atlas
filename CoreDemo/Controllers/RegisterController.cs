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
		public IActionResult Index(Writer writer)
		{
			WriterValidator writerValidator = new WriterValidator();
			ValidationResult validationResults = writerValidator.Validate(writer);

			if (validationResults.IsValid)
			{
				if (writer.WriterPassword == writer.ConfirmPassword)
				{
					writer.WriterStatus = true;
					writer.WriterAbout = "Deneme Test";

					writerManager.TAdd(writer);
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
