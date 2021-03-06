using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
    public class LoginDTO
    {
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre Giriniz")]
        public string Password { get; set; }


        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }


        [Display(Name = "Beni Hatırla")]
        public bool Persistent { get; set; } //cookie için geçerli/aktif olup olmamasını beliler
        public bool Lock { get; set; } //belirli saydıa hatalı giriş yaptıgında hesabın kitlenip kitlenmeyecegini belirler
    }
}
