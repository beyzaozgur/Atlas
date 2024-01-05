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
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetterDal _newsLetterDal;

		public NewsLetterManager(INewsLetterDal newsLetterDal) 
		{
			_newsLetterDal = newsLetterDal;
		}

		public List<NewsLetter> GetAll()
		{
			return _newsLetterDal.GetAll();
		}

		public NewsLetter GetById(int Id)
		{
			return _newsLetterDal.GetByID(Id);
		}

		public void TAdd(NewsLetter t)
		{
			_newsLetterDal.Insert(t);
		}

		public void TDelete(NewsLetter t)
		{
			_newsLetterDal.Delete(t);
		}

		public void TUpdate(NewsLetter t)
		{
			_newsLetterDal.Update(t);
		}

	}
}
