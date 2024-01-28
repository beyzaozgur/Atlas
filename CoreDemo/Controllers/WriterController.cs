using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.ViewModels;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
	{
		private readonly UserManager<User> _userManager;

		public WriterController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

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
		public async Task<IActionResult> WriterEditProfile()
		{
			var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
			var user = _userManager.FindByIdAsync(userId).Result;

			AddUpdateWriterModel model = new AddUpdateWriterModel();
			model.WriterID = user.Id;
			model.WriterName = user.NameSurname;
			model.WriterMail = user.Email;
			model.WriterCity = user.City;
			model.WriterImageUrl = user.ImageUrl;
			model.WriterAbout = user.About;

			return View(model);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> WriterEditProfile(AddUpdateWriterModel writer)
		{
			var userToUpdate = await _userManager.FindByIdAsync((writer.WriterID).ToString());
			userToUpdate.NameSurname = writer.WriterName;
			userToUpdate.Email = writer.WriterMail;
			userToUpdate.City = writer.WriterCity;
			userToUpdate.About = writer.WriterAbout;

			if (writer.WriterImage != null)
			{
				var extension = Path.GetExtension(writer.WriterImage.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				writer.WriterImage.CopyTo(stream);
				userToUpdate.ImageUrl = newImageName;
			}

			UserValidator userValidator = new UserValidator();

			IdentityResult result = await _userManager.UpdateAsync(userToUpdate);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				return View();
			}

		}
	}
}
