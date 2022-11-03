using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void Delete(Category category);
        void UpdateCategory(Category category);
        List<Category> GetAll();
        Category GetByID(int id);

    }
}
