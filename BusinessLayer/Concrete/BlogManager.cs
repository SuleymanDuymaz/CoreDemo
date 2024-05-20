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
    public class BlogManager : IBlogService
    {
        IBlogDal _IblogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _IblogDal = blogDal;
        }
        public void AddBlog(Blog blog)  
        {
            _IblogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            _IblogDal.Delete(blog);
        }

        public List<Blog> GetAll()
        {
            return _IblogDal.List();
        }

        public Blog GetByID(int id)
        {
            return _IblogDal.GetById(id);
           
        }
        public List<Blog> GetBlogById(int id)
        {
            return _IblogDal.List(p=>p.Id==id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            //return _IblogDal.List(p=>p.Writer.WriterID==id);
            return _IblogDal.List(p => p.WriterID == 2);

        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _IblogDal.GetListWithCategory();
        }

        public List<Blog> GetLast3Blog()
        {
           return  _IblogDal.List().TakeLast(3).ToList();
           
        }

        public void UpdateBlog(Blog blog)
        {
            _IblogDal.Update(blog); 
        }
        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _IblogDal.GetListWithCategoryByWriter(id);
        }
        //bk vuraya

      
    }
}
