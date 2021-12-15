using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public class EmployeeValidation:AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Personel Adı Soyadı Boş Geçilemez");
            RuleFor(x => x.NameSurname).MinimumLength(5).MaximumLength(35).WithMessage("Personel Adı Soyadı min 5 max 35  karakter içermeli");
        }
    }
}
