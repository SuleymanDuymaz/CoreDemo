using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class NewsLetter : BaseEntity
    {
       
        public string EMailAdress { get; set; }
        public bool NewsLetterStatus { get; set; }


    }
}
