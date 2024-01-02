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
	public class WriterManager : IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public List<Writer> GetAll()
		{
			return _writerDal.GetAll();
		}

		public Writer GetById(int Id)
		{
			return _writerDal.GetByID(Id);
		}

		public void TAdd(Writer t)
		{
			_writerDal.Insert(t);
		}

		public void TDelete(Writer t)
		{
			_writerDal.Delete(t);
		}

		public void TUpdate(Writer t)
		{
			_writerDal.Update(t);
		}

		//public void UpdateWriterProfile(Writer writer)
		//{
		//	_writerDal.WriterProfileUpdate(writer);
		//}
	}
}
