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
	public class NotificationManager : INotificationService
	{
		INotificationDal _notificationDal;

		public NotificationManager(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

		public List<Notification> GetAll()
		{
			return _notificationDal.GetAll();
		}

		public Notification GetById(int Id)
		{
			return _notificationDal.GetByID(Id);
		}

		public void TAdd(Notification t)
		{
			_notificationDal.Insert(t);
		}

		public void TDelete(Notification t)
		{
			_notificationDal.Delete(t);	
		}

		public void TUpdate(Notification t)
		{
			_notificationDal.Update(t);
		}
	}
}
