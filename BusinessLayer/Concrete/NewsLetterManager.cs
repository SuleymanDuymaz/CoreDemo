using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;


namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;
        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }
        public void AddNewsLetterSubscriber(NewsLetter newsLetter)
        {
            _newsLetterDal.Add(newsLetter);
        }

        public void DeleteNewsLetterSubscriber(NewsLetter newsLetter)
        {
            _newsLetterDal.Delete(newsLetter);
        }
    }
}
