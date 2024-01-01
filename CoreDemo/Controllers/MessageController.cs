﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
	public class MessageController : Controller
	{
		MessageManager messageManager = new MessageManager(new EfMessageRepository());
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

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

		[AllowAnonymous]
		[HttpGet]
		public IActionResult SendMessage(int id)
		{
			var writer = writerManager.GetById(id);
			ViewBag.receiver = writer.WriterName;
			ViewBag.receiverId = writer.WriterID;
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult SendMessage(Message message)
		{
			message.MessageDate = DateTime.Today;
			message.SenderID = 1;
			message.MessageStatus = true;

			messageManager.TAdd(message);
			return RedirectToAction("Inbox", "Message");
		}
	}
}