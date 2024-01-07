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
		public async Task<IActionResult> Index(Writer writer)
		{
			Context c = new Context();
			var dataValue = c.Users.FirstOrDefault(x => x.Email == writer.WriterMail && x.PasswordHash == writer.WriterPassword);

			if(dataValue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, writer.WriterMail)
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
