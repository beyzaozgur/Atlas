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
	public class CommentManager : ICommentService
	{

		ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
			_commentDal = commentDal;   
        }
  //      public void CommentAdd(Comment comment)
		//{
		//	_commentDal.Insert(comment);
		//}

		public List<Comment> GetListByBlogId(int id)
		{
			return _commentDal.GetAll(x => x.BlogID == id);
		}

		public int GetCommentCountByWriterId(int id)
		{
			return _commentDal.GetCommentCountByWriter(id);
		}

		public void TAdd(Comment t)
		{
			_commentDal.Insert(t);
		}

		public void TDelete(Comment t)
		{
			_commentDal.Delete(t);
		}

		public void TUpdate(Comment t)
		{
			_commentDal.Update(t);
		}

		public List<Comment> GetAll()
		{
			return _commentDal.GetAll();
		}

		public Comment GetById(int Id)
		{
			return _commentDal.GetByID(Id);
		}
	}
}
