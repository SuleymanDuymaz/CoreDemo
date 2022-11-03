    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
                
            RuleFor(p => p.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş bırakılamaz");
            RuleFor(p => p.WriterName).MinimumLength(2).WithMessage("Yazar adı minumum 2 karakter uzunlupunda olmalıdır.");
            RuleFor(p => p.WriterName).MaximumLength(30).WithMessage("Yazar adı maximum 30 karakter olabilir");

            RuleFor(p => p.WriterMail).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");

            RuleFor(p => p.WriterImage).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(p => p.WriterPassword).NotEmpty().WithMessage("Bu alan boş bırakılamaz");


           
        }
    }
}
