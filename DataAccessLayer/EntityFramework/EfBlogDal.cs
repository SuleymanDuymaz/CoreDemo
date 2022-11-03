using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Repositories;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using( var context=new Context())
            {
                return context.Blogs.Include(p => p.Category).ToList();
            }
        }
        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(p => p.Category).Where(p => p.WriterID == id).ToList();
            }
        }

     
    }
}
