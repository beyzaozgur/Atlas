﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EfCommentRepository());
		NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());
		BlogManager blogManager = new BlogManager(new EfBlogRepository());	

		private readonly UserManager<User> _userManager;

		public CommentController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult AddComment()
		{
			return PartialView();
		}

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
			var commenterId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
			var commenterName = _userManager.FindByIdAsync(commenterId).Result.NameSurname;

			comment.CommentUserName = commenterName;
			comment.CommenterID = Int32.Parse(commenterId);
			comment.CommentDate = DateTime.Now;
			comment.CommentStatus = true;

			commentManager.TAdd(comment);

			var commentedBlog = blogManager.GetById(comment.BlogID);
			var commentedBlogName = commentedBlog.BlogTitle;
			var blogOwnerID = commentedBlog.UserID;

			Notification notification = new Notification();
			notification.NotificationType = "Comment";
			notification.NotificationTypeSymbol = "mdi mdi-comment-text";
			notification.NotificationTypeColor = "#0096FF";
			notification.NotificationDetails = $"{comment.CommentUserName} has commented to your blog \"{commentedBlogName}\"";
			notification.NotificationDate = DateTime.Now;
			notification.NotificationStatus = true;
			notification.NotifiedUserID = blogOwnerID;
			notification.CommentID = comment.CommentID;

			notificationManager.TAdd(notification);

			return Json(new { result = true });
        }

        public PartialViewResult CommentListByBlog(int id)
		{
			var values = commentManager.GetListByBlogId(id);
			return PartialView(values);
		}
	}
}
