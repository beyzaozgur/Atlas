using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
	{
		public int GetCommentCountByWriter(int id)
		{
			using (var c = new Context())
			{
				var commentCount = c.Comments
									.Join(c.Blogs, comment => comment.BlogID, blog => blog.BlogID, (comment, blog) => new { comment, blog })
									.Where(result => result.blog.UserID == id)
									.Count();

				return commentCount;
			}
		}
	}
}
