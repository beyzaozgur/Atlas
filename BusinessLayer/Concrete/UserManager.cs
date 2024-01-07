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
	public class UserManager : IUserService
	{
		IUserDal _UserDal;

		public UserManager(IUserDal UserDal)
		{
			_UserDal = UserDal;
		}

		public List<User> GetAll()
		{
			return _UserDal.GetAll();
		}

		public User GetById(int Id)
		{
			return _UserDal.GetByID(Id);
		}

		public void TAdd(User t)
		{
			_UserDal.Insert(t);
		}

		public void TDelete(User t)
		{
			_UserDal.Delete(t);
		}

		public void TUpdate(User t)
		{
			_UserDal.Update(t);
		}
	}
}
