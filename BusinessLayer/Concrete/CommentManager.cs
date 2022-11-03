using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;

        }
        public void AddComment(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.List();
        }

        public List<Comment> GetListByBlogId(int id)
        {
            return _commentDal.List(p=>p.BlogID==id);
        }

        public void UpdateCategory(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
