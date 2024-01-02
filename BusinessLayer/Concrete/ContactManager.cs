﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ContactManager : IContactService
	{
		IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

		public List<Contact> GetAll()
		{
			return _contactDal.GetAll();
		}

		public Contact GetById(int Id)
		{
			return _contactDal.GetByID(Id);
		}

		public void TAdd(Contact t)
		{
			_contactDal.Insert(t);
		}

		public void TDelete(Contact t)
		{
			_contactDal.Delete(t);
		}

		public void TUpdate(Contact t)
		{
			_contactDal.Update(t);
		}

		//      public void AddContact(Contact contact)
		//{
		//	_contactDal.Insert(contact);
		//}
	}
}
