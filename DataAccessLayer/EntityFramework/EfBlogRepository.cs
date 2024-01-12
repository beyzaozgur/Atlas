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
	public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
	{
		public List<Blog> GetListWithCategoryAndCommentsAndUser()
		{
			using (var c = new Context())
			{
				return c.Blogs.Include(b => b.Category).Include(b => b.Comments).Include(c => c.User).ToList();	
			}
		}

		public List<Blog> GetListWithCategory()
		{
			using (var c = new Context())
			{
				return c.Blogs.Include(b => b.Category).ToList();
			}
		}

		public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(b => b.Category).Where(x => x.UserID == id).ToList();
            }
        }

		public Blog GetBlogWithUserByBlogId(int blogId)
		{
			using (var c = new Context())
			{
				return c.Blogs.Include(b => b.User).Where(x => x.BlogID == blogId).ToList().FirstOrDefault();
			}
		}
	}
}
