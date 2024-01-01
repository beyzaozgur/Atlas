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
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

		public Category GetById(int Id)
		{
			return _categoryDal.GetByID(Id);
		}

		public List<Category> GetAll()
		{
			return _categoryDal.GetAll();
		}

		public void TAdd(Category t)
		{
			_categoryDal.Insert(t);
		}

		public void TDelete(Category t)
		{
			_categoryDal.Delete(t);
		}

		public void TUpdate(Category t)
		{
			_categoryDal.Update(t);
		}
	}
}
