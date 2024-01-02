using EntityLayer.Concrete;

namespace CoreDemo.Models
{
	public class AddUpdateBlogModel
	{
		public int BlogID { get; set; }

		public string BlogTitle { get; set; }

		public string BlogContent { get; set; }

		public IFormFile BlogThumbnailImage { get; set; }

		public IFormFile BlogImage { get; set; }

		public bool BlogStatus { get; set; }

		public int CategoryID { get; set; }

		public int WriterID { get; set; }
	}
}
