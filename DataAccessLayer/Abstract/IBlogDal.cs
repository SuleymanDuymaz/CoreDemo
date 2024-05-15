using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {

        //List<Blog> GetAll();
        //void AddCategory(Blog blog);
        //void DeleteCategory(Blog blog);
        //void Update(Blog blog);
        //Blog GetById(int id);
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);

    }
}
