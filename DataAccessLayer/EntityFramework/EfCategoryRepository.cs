using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
	{
		public int GetBlogCountByCategoryID(int id)
		{
			using (var c = new Context())
			{
				return c.Blogs.Where(x => x.CategoryID == id).Count();
			}
		}
	}
}
