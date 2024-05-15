﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Repositories;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal:GenericRepository<About>,IAboutDal
    {

    }
}
