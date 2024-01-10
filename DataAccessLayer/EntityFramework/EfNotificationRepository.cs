using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNotificationRepository : GenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetNotificationListWithComment(int userId)
        {
            using (var c = new Context())
            {
                var values = c.Notifications.Include(b => b.Comment).Where(x => x.NotifiedUserID == userId).OrderByDescending(x => x.NotificationDate).ToList();
                return values;
            }
        }
    }
}
