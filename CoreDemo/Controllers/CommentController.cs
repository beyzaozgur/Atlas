using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EfCommentRepository());
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
        public IActionResult AddComment(Comment comment)
        {
			comment.CommentDate = DateTime.Now;
			comment.CommentStatus = true;
			comment.BlogID = 2;
			commentManager.CommentAdd(comment);
            return Json(new { result = true });
        }

        public PartialViewResult CommentListByBlog(int id)
		{
			var values = commentManager.GetListByBlogId(id);
			return PartialView(values);
		}
	}
}
