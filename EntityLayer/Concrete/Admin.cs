using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin : BaseEntity
    {
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ShortDesription { get; set; }
        public string ImageURL { get; set; }
        public string Role { get; set; }


    }
}
