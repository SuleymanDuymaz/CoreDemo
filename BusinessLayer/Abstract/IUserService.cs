using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {

        //void AddWriter();
        //void Delete();
        //void UpdateWriter();

        //Bu imzalar Identity kütüphnesinden gelen hazır metodlar kullanılacağı için kullanılmayacak

        AppUser GetById(int id);

     
    }
}
