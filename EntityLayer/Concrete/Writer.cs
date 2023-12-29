using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Writer
	{
		[Key]
        public int WriterID { get; set; }

		public string WriterName { get; set; }

		public string WriterAbout { get; set; }

		public string WriterImage { get; set; }

		public string WriterMail { get; set; }

		public string WriterPassword { get; set; }

		[NotMapped] // Does not effect with your database
		//[Required(ErrorMessage = "Confirm Password required")]
		//[Compare("WriterPassword", ErrorMessage = "Password doesn't match.")]
		public string ConfirmPassword { get; set; }

		public bool WriterStatus { get; set; }

		public string WriterCity { get; set; }

		public List<Blog> Blogs { get; set; }

		public ICollection<Message> SentMessages { get; set; }

        public ICollection<Message> ReceivedMessages { get; set; }



    }
}
