using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }

        /*İlişkiler*/
        public ICollection<Movement> Movements { get; set; }
        /**/
    }
}
