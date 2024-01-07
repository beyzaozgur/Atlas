using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class User: IdentityUser<int>
	{

		public string NameSurname { get; set; }

		public string About { get; set; }

		public string ImageUrl { get; set; }

		public bool Status { get; set; }

		public string City { get; set; }

		public List<Blog> Blogs { get; set; }

		public ICollection<Message> SentMessages { get; set; }

		public ICollection<Message> ReceivedMessages { get; set; }

	}
}
