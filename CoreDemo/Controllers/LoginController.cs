using CoreDemo.ViewModels;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<User> _signInManager;

		public LoginController(SignInManager<User> signInManager)
		{
			_signInManager = signInManager;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(LoginViewModel user)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, true);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Blog");
				}
				else
				{
					return RedirectToAction("Index", "Login");
				}

			}

			return View();
		}

		[AllowAnonymous]
		public async Task<IActionResult> WriterLogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}


	}
}
