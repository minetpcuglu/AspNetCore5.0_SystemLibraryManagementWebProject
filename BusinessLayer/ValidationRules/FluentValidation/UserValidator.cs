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
   public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Kullanıcı Soyadı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage(" Adı maks 50 karakter olmalı");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage(" Adı min 3 karakter olmalı");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage(" Kullanıcı Soyadı maks 50 karakter olmalı");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Kullanıcı Soyadı min 3 karakter olmalı");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Kullanıcı soyadı boş geçilemez");
            RuleFor(x => x.Telephone).NotEmpty().WithMessage("Telefon boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Kullanıcı şifre boş geçilemez");
            RuleFor(x => x.Password).Must(IsPasswordValidRules).WithMessage("Parolanızda en az bir küçük harf bir büyük harf ve rakamdan oluşmalıdır.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Kullanıcı Mail boş geçilemez / E-mail formatında olmalı");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Yazar soyadı maks 50 karakter olmalı");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Yazar soyadı min 2 karakter olmalı");
      
        }
        private bool IsPasswordValidRules(string arg)
        {
            try
            {
                Regex userPassword = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return userPassword.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
