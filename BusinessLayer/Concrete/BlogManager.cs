using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{

		IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
			_blogDal = blogDal;
        }

        public void AddBlog(Blog blog)
		{
			_blogDal.Insert(blog);
		}

		public void DeleteBlog()
		{
			throw new NotImplementedException();
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		public Blog GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Blog> GetBlogByID(int id)
		{
			return _blogDal.GetAll(x => x.BlogID == id);
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetAll();
		}

		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetAll().Take(3).ToList();
		}

		public void UpdateBlog()
		{
			throw new NotImplementedException();
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetAll(x => x.WriterID == id);
		}

    }
}
