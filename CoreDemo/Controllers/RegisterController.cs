using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.ViewModels;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{

		private readonly UserManager<User> _userManager;

		public RegisterController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(RegisterViewModel u)
		{
			if (ModelState.IsValid)
			{
				User user = new User()
				{
					Email = u.Email,
					NameSurname = u.NameSurname,
					City = u.City,
					UserName = u.Email,
					About = "Hello, I'm a new blogger in Atlas!",
					Status = true
				};

				if (u.ImageUrl != null)
				{
					var extension = Path.GetExtension(u.ImageUrl.FileName);
					var newImageName = Guid.NewGuid() + extension;
					var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
					var stream = new FileStream(location, FileMode.Create);
					u.ImageUrl.CopyTo(stream);
					user.ImageUrl = newImageName;
				}

				var result = await _userManager.CreateAsync(user, u.Password);

				if(result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				} else
				{
					foreach(var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}

			return View(u);
		}

	}
}
