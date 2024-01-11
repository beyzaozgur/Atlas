using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
	public interface ICommentDal: IGenericDal<Comment>
	{
		int GetCommentCountByWriter(int id);

		List<Comment> GetCommentsWithUser(int id);
	}
}
