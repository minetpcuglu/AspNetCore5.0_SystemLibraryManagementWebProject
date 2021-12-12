using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BookValidator:AbstractValidator<Book>
    {

        public BookValidator()
        {

            RuleFor(x => x.BookName).NotEmpty().WithMessage("Kitap adı boş geçilemez");
            RuleFor(x => x.BookDescription).NotEmpty().WithMessage("Kitap açıklaması boş geçilemez");
            RuleFor(x => x.BookName).MaximumLength(50).WithMessage("Kitap adı maks 25 karakter olmalı");
            RuleFor(x => x.BookName).MinimumLength(3).WithMessage("Kitap adı min 3 karakter olmalı");
            RuleFor(x => x.NumberPage).NotEmpty().WithMessage("Sayfa sayısı boş geçilemez");
            RuleFor(x => x.PrintDate).NotEmpty().WithMessage("Basım tarihi boş geçilemez");
           
            RuleFor(x => x.Publisher).NotEmpty().WithMessage("Yayınevi boş geçilemez");
          
        }
    }
}
