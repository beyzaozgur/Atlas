using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

        public List<Blog> GetBlogListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetAll().Take(3).ToList();
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetAll(x => x.WriterID == id);
		}

		public List<Blog> GetLast5BlogsWithCategory()
		{
			return _blogDal.GetListWithCategory().OrderByDescending(x => x.CreateDate).Take(5).ToList();
		}

		public void TAdd(Blog t)
		{
			_blogDal.Insert(t);
		}

		public void TDelete(Blog t)
		{
			_blogDal.Delete(t);
		}

		public void TUpdate(Blog t)
		{
			_blogDal.Update(t);
		}

		public List<Blog> GetAll()
		{
			return _blogDal.GetAll();
		}

		public Blog GetById(int Id)
		{
			return _blogDal.GetByID(Id);
		}
	}
}
