using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class MessageController : Controller
	{
		MessageManager messageManager = new MessageManager(new EfMessageRepository());

		[AllowAnonymous]
		public IActionResult Inbox()
		{
			int id = 1;
			var values = messageManager.GetInboxListByWriter(id);
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
	}
}
