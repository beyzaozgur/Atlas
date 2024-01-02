﻿using BusinessLayer.Abstract;
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

  //      public void AddBlog(Blog blog)
		//{
		//	_blogDal.Insert(blog);
		//}

		//public void DeleteBlog(Blog blog)
		//{
		//	_blogDal.Delete(blog);
		//}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

        public List<Blog> GetBlogListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

  //      public Blog GetByID(int id)
		//{
		//	return _blogDal.GetByID(id);
		//}

		//public List<Blog> GetBlogByID(int id)
		//{
		//	return _blogDal.GetAll(x => x.BlogID == id);
		//}

		//public List<Blog> GetList()
		//{
		//	return _blogDal.GetAll();
		//}

		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetAll().Take(3).ToList();
		}

		//public void UpdateBlog(Blog blog)
		//{
		//	_blogDal.Update(blog);
		//}

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
