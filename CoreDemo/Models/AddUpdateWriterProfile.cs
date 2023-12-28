using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemo.Models
{
	public class AddUpdateWriterProfile
	{
		public int WriterID { get; set; }

		public string WriterName { get; set; }

		public string WriterAbout { get; set; }

		public IFormFile WriterImage { get; set; }

		public string WriterMail { get; set; }

		public bool WriterStatus { get; set; }

		public string WriterCity { get; set; }

		public string WriterPassword { get; set; }

		public string ConfirmPassword { get; set; }
	}
}
