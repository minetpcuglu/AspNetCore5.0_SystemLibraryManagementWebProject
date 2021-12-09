using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Hakkımda boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Yazar adı maks 50 karakter olmalı");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Yazar adı min 3 karakter olmalı");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Yazar şifre boş geçilemez");
            RuleFor(x => x.Password).Must(IsPasswordValidRules).WithMessage("Parolanızda en az bir küçük harf bir büyük harf ve rakamdan oluşmalıdır.");
            RuleFor(x => x.Mail).NotEmpty().EmailAddress().WithMessage("Yazar Mail boş geçilemez / E-mail formatında olmalı");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Yazar soyadı maks 50 karakter olmalı");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Yazar soyadı min 2 karakter olmalı");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Hakkımda min 50 karakter olmalı");
        }

        private bool IsPasswordValidRules(string arg)
        {
            try
            {
                Regex writerPassword = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return writerPassword.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
