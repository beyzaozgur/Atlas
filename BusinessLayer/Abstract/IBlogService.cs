﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService
	{
		void AddBlog();

		void DeleteBlog();

		void UpdateBlog();

		List<Blog> GetList();

		Blog GetByID(int id);

		List<Blog> GetBlogListWithCategory();

		List<Blog> GetBlogListByWriter(int id);

	}
}
