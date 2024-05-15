using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;


namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void AddBlog(Blog blog);
        void Delete(Blog blog);
        void UpdateBlog(Blog blog);
        List<Blog> GetAll();
        List<Blog> GetBlogListWithCategory();
        Blog GetByID(int id);
        List<Blog> GetBlogListByWriter(int id);


        List<Blog> GetLast3Blog();
        List<Blog> GetBlogById(int id);
    }
}
