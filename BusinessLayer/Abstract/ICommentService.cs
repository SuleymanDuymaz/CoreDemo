using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        void Delete(Comment comment);
        void UpdateCategory(Comment comment);
        List<Comment> GetAll();
        List<Comment> GetListByBlogId(int id);

    }
}
