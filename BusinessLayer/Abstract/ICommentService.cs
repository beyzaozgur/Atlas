using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	internal interface ICommentService : IGenericService<Comment>
	{
		List<Comment> GetListByBlogId(int id);

		int GetCommentCountByWriterId(int id);

		List<Comment> GetCommentsWithUser(int id);
	}
}
