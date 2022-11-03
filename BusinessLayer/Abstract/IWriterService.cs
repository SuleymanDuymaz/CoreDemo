using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        void AddWriter(Writer writer);
        void Delete(Writer writer);
        void UpdateWriter(Writer writer);
        List<Writer> GetAll();
        Writer GetById(int id);
    }
}
