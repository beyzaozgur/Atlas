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
	public class EfWriterRepository : GenericRepository<Writer>, IWriterDal
	{
		public void WriterProfileUpdate(Writer writer)
		{
			using (var c = new Context())
			{
				var w = c.Writers.Find(writer.WriterID);

				if (w != null)
				{
					w.WriterName = writer.WriterName;
					w.WriterMail = writer.WriterMail;
					w.WriterCity = writer.WriterCity;
					w.WriterAbout = writer.WriterAbout;
					w.WriterStatus = writer.WriterStatus;

					c.SaveChanges();
				}
			}

		}
	}
}
