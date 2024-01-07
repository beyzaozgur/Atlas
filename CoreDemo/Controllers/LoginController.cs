using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(User user)
		{
			Context c = new Context();
			var dataValue = c.Users.FirstOrDefault(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash);

			if(dataValue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Email)
				};

				var userIdentity = new ClaimsIdentity(claims, "a");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				return View();
			}
		}


	}
}
