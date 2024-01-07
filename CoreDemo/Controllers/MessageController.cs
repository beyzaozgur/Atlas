using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
	public class MessageController : Controller
	{
		MessageManager messageManager = new MessageManager(new EfMessageRepository());

		private readonly UserManager<User> _userManager;

		public MessageController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		[AllowAnonymous]
		public IActionResult Inbox()
		{
			var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
			var values = messageManager.GetInboxListByWriter(Int32.Parse(userId));
			return View(values);
		}

		[AllowAnonymous]
		public IActionResult MessageDetails(int id)
		{
			var values = messageManager.GetMessageByIDWithSender(id);
			return View(values);
		}

		[AllowAnonymous]
		public IActionResult MessageDelete(int id)
		{
			var values = messageManager.GetById(id);
			messageManager.TDelete(values);
			return Json(new { result = true });
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult SendMessage(int id)
		{
			var user = _userManager.FindByIdAsync(id.ToString());
			ViewBag.receiver = user.Result.NameSurname;
			ViewBag.receiverId = user.Result.Id;
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult SendMessage(Message message)
		{
			var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);

			message.MessageDate = DateTime.Today;
			message.SenderID = Int32.Parse(userId);
			message.MessageStatus = true;

			messageManager.TAdd(message);
			return RedirectToAction("Inbox", "Message");
		}
	}
}
